# AutoCore

Single-project Avalonia 12 desktop app on .NET 10 (`AutoCore/AutoCore.csproj`), using CommunityToolkit.Mvvm and the Fluent theme.

## Commands

- Build: `dotnet build AutoCore.slnx` (the solution is `.slnx`, not `.sln`; bare `dotnet build` also works).
- Run: `dotnet run --project AutoCore` — launches a desktop GUI, so it needs a display; there is no headless run harness.
- No test project or CI/lint gate exists yet. `dotnet test` runs nothing.
- `dotnet format AutoCore.slnx --verify-no-changes` works but currently flags pre-existing usings/whitespace in `Program.cs`, `App.axaml.cs`, and `ViewLocator.cs`; don't treat those as new regressions.

## Local database

- `docker-compose.yaml` runs `postgres:18` as container `autocore-db` with `restart: on-failure`, published on host port 5432 (`"5432:5432"`, all interfaces), with `POSTGRES_PASSWORD`/`POSTGRES_DB` read from the repo-root `.env` that Compose auto-loads. Data persists in the named volume `autocore_data`.
- `restart: on-failure` only revives the container after a non-zero exit; `docker compose stop` / `down` leaves it stopped, so a local DB that "won't come back" usually just needs `docker compose up -d`. Because the port is bound on all interfaces, anything on the LAN can reach this dev database — restrict the mapping to `127.0.0.1:5432:5432` if that matters.
- `setup-local-db-environment.sh` is the one-time bootstrap: it generates a random password (via `openssl`), writes `.env` (`DB_NAME=autocore`, `DB_PASSWORD=...`), and stores the matching connection string as the user secret `ConnectionStrings:DefaultConnection` in `AutoCore/` (`UserSecretsId` is already in `AutoCore.csproj`).
- First run: `./setup-local-db-environment.sh` then `docker compose up -d`.
- Connection string shape: `Host=127.0.0.1;Port=5432;Database=autocore;Username=postgres;Password=<from .env>;`.
- `.env` is gitignored. Each script run generates a fresh password, which only takes effect in `initdb` on an empty data directory — after re-running the script against an existing volume, recreate the database with `docker compose down -v` or connections will be rejected.
- No data-access package (Npgsql/EF Core) or DB code exists yet — nothing reads `ConnectionStrings:DefaultConnection` today. Add the provider before wiring a `DbContext`.
- `autocore_data` is mounted at the `postgres:18` `PGDATA` path, `/var/lib/postgresql/18/docker`, so the database survives `docker compose down` / `up`. The path is major-version specific: bumping the image to `postgres:19` needs a fresh volume or an explicit `pg_upgrade`/dump-restore (mounting the parent `/var/lib/postgresql` instead would allow the faster `--link` upgrade path).
- Inspect the DB with `docker compose exec db psql -U postgres -d autocore`; open a shell with `docker compose exec db bash`. `docker compose down` stops it, `docker compose down -v` also deletes the data volume.

## Wiring

- Startup: `Program.cs` → `App.axaml.cs`. `App` creates `MainWindow` directly and assigns a `MainViewModel` DataContext; the `ViewLocator` is not used for the main window.
- `ViewLocator` maps `FooViewModel` to `FooView` by replacing `ViewModel` with `View` in the full type name. Name new navigable screens `*View` (not `*Window`).
- Views declare `x:DataType` plus `Design.DataContext` for the previewer; the runtime DataContext is set in code in `App.axaml.cs`.
- Bindings are reflection-based at runtime: `x:DataType` alone is set, but neither `x:CompileBindings` nor `AvaloniaUseCompiledBindingsByDefault` is enabled. Add one if you need compile-time binding validation.

## Conventions

- `[ObservableProperty]` uses CommunityToolkit 8.4 partial-property syntax:
  `[ObservableProperty] public partial string Greeting { get; set; }`
  Do not fall back to the older `_field` pattern.
- `.editorconfig` (the only style config): 4 spaces, Allman braces, file-scoped namespaces, explicit types (no `var`), `_camelCase` private fields, `System` usings first in a separate group. C# files have no trailing newline.

## Avalonia 12 notes

- This targets Avalonia **12**, not 11; APIs and XAML differ from most model training data. Use the configured `avalonia-docs` MCP server and the vendored skills under `.opencode/skills/avalonia/` rather than guessing.
- `.opencode/skills/**` is pinned by `skills-lock.json`; don't hand-edit vendored skills.
- `AvaloniaUI.DiagnosticsSupport` (DevTools) is Debug-only via csproj conditions; keep it excluded from Release.
- Files under `AutoCore/Assets/` are included as `AvaloniaResource` by glob; reference them as `/Assets/<file>` (e.g. window `Icon`).
