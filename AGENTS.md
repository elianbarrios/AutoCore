# AutoCore

Single-project Avalonia 12 desktop app on .NET 10 (`AutoCore/AutoCore.csproj`), using CommunityToolkit.Mvvm and the Fluent theme.

## Commands

- Build: `dotnet build AutoCore.slnx` (the solution is `.slnx`, not `.sln`; bare `dotnet build` also works).
- Run: `dotnet run --project AutoCore` — launches a desktop GUI, so it needs a display; there is no headless run harness.
- No test project or CI/lint gate exists yet. `dotnet test` runs nothing.
- `dotnet format AutoCore.slnx --verify-no-changes` works but currently flags pre-existing usings/whitespace in `Program.cs`, `App.axaml.cs`, and `ViewLocator.cs`; don't treat those as new regressions.

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
