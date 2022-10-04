using Hardcodet.Wpf.TaskbarNotification;
using IdeapadToolkit.Models;
using IdeapadToolkit.Services;
using IdeapadToolkit.ViewModels;
using IdeapadToolkit.Views;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace IdeapadToolkit
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Container _container;

        public static void ConfigureServices(Container container)
        {
            container.RegisterSingleton<INavigationService, NavigationService>();
            container.RegisterSingleton<ILenovoPowerSettingsService, LenovoPowerSettingsService>();
            container.RegisterSingleton<IUEFISettingsService, UEFISettingsService>();
            container.RegisterSingleton<IRunOnStartupService, RunOnStartupService>();
            container.RegisterSingleton<TrayIconView>();

            container.Register<MainWindow>();

            container.Register<MainPage>();
            container.Register<SettingsPage>();

            container.Register<SettingsViewModel>();
            container.Register<MainViewModel>();
            container.RegisterSingleton<LenovoSettingsViewModel>();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Container container = _container = new Container();
            ConfigureServices(container);
            bool exists = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly()?.Location)).Length > 1;
            if (exists)
            {
                MessageBox.Show("Already running!", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                Application.Current.Shutdown();
                return;
            }
            else
            {
                base.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            }

            if(!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PowerBattery.dll")))
            {
                MessageBox.Show("PowerBattery.dll has to be present in the same folder as IdeapadToolkit.exe", "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                Application.Current.Shutdown();
            }

            var iconview = _container.GetInstance<TrayIconView>();
            iconview.MakeVisible();
            iconview.TrayIconClicked += ShowMainWindow;
        }

        public void ShowMainWindow(object? sender, EventArgs e)
        {
            if (App.Current.MainWindow == null)
            {
                App.Current.MainWindow = _container.GetInstance<MainWindow>();
            }
            App.Current.MainWindow.Show();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
