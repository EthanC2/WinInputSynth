using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


using WinInputSynth.Views;
using WinInputSynth.Models;
using WinInputSynth.ViewModels;
using WinInputSynth.Activation;
using WinInputSynth.Contracts.Services;
using WinInputSynth.Services;
using WinInputSynth.Helpers;
using WinInputSynth.Core.Contracts.Services;
using WinInputSynth.Core.Services;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WinInputSynth;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : Application
{
    private static readonly IHost _host = Host
        .CreateDefaultBuilder()
        .ConfigureServices((context, services) => 
        {
            //Default Activation Handler
            services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

            //Services
            services.AddSingleton<ILocalSettingsService, LocalSettingsServicePackaged>();
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            services.AddSingleton<IActivationService, ActivationService>();
            services.AddSingleton<IPageService, PageService>(); 
            services.AddSingleton<INavigationService, NavigationService>();

            //Core Services
            services.AddSingleton<IFileService, FileService>();

            //Views and ViewModels
            services.AddTransient<ShellViewModel>();
            services.AddTransient<ShellPage>();
            services.AddTransient<MouseViewModel>();
            services.AddTransient<MousePage>();
            services.AddTransient<KeyboardViewModel>();
            services.AddTransient<KeyboardPage>();
            services.AddTransient<MouseAndKeyboardViewModel>();
            services.AddTransient<MouseAndKeyboardPage>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<SettingsPage>();

            //Configuration
            services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));
        }).Build();

    public static T GetService<T>() where T : class
    {
        return _host.Services.GetService(typeof(T)) as T;
    }


    public static Window MainWindow { get; set; } = new Window();

    public App()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Invoked when the application is launched normally by the end user.  Other entry points
    /// will be used such as when the application is launched to open a specific file.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);
        var activationService = GetService<IActivationService>();
        await activationService.ActivateAsync(args);
    }
}
