using System;

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using AutoCore.Data;
using AutoCore.ViewModels;
using AutoCore.Views;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutoCore;

public partial class App : Application
{
    private ServiceProvider? _services;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            string connectionString = new ConfigurationBuilder()
                .AddUserSecrets(typeof(App).Assembly)
                .Build()
                .GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "No se encontró la cadena 'ConnectionStrings:DefaultConnection' en los user secrets.");

            ServiceCollection services = new();
            services.AddAutoCoreData(connectionString);
            _services = services.BuildServiceProvider();

            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(),
            };

            desktop.Exit += (_, _) => _services?.Dispose();
        }

        base.OnFrameworkInitializationCompleted();
    }
}