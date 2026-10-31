using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AutoCore.Data;

public sealed class AutoCoreDbContextFactory : IDesignTimeDbContextFactory<AutoCoreDbContext>
{
    private const string ConnectionStringName = "ConnectionStrings:DefaultConnection";
    private const string ConnectionStringEnvironmentVariable = "ConnectionStrings__DefaultConnection";

    public AutoCoreDbContext CreateDbContext(string[] args)
    {
        string? connectionString = Environment.GetEnvironmentVariable(ConnectionStringEnvironmentVariable);

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            connectionString = new ConfigurationBuilder()
                .AddUserSecrets(typeof(AutoCoreDbContextFactory).Assembly)
                .Build()[ConnectionStringName];
        }

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                $"No se encontró la cadena '{ConnectionStringName}'. Configúrala con " +
                "`dotnet user-secrets set \"ConnectionStrings:DefaultConnection\" \"...\"` " +
                $"o con la variable de entorno '{ConnectionStringEnvironmentVariable}'.");
        }

        DbContextOptions<AutoCoreDbContext> options = new DbContextOptionsBuilder<AutoCoreDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        return new AutoCoreDbContext(options);
    }
}