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
        private TaskbarIcon NotifyIcon;

        public void ConfigureServices(Container container)
        {
            container.RegisterSingleton<INavigationService, NavigationService>();
            container.RegisterSingleton<ILenovoPowerSettingsService, LenovoPowerSettingsService>();
            container.RegisterSingleton<IUEFISettingsService, UEFISettingsService>();
            container.RegisterSingleton<TrayIconView>();

            container.Register<MainWindow>();

            container.Register<MainPage>();
            container.Register<SettingsPage>();
            
            container.Register<MainViewModel>();
            container.RegisterSingleton<LenovoSettingsViewModel>();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Container container = _container = new Container();
            this.ConfigureServices(container);
            bool exists = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)).Count<Process>() > 1;
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

            var iconview = _container.GetInstance<TrayIconView>();
            iconview.MakeVisible();
            var mainWindow = _container.GetInstance<MainWindow>();

            mainWindow.Show();
        }


        
        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
