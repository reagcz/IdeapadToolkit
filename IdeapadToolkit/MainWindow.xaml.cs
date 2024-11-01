using IdeapadToolkit.Services;
using IdeapadToolkit.Views;
using System;
using System.Windows;

namespace IdeapadToolkit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly INavigationService _navigationService;

        public MainWindow(INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeComponent();
            _navigationService.NavFrame = RootFrame;
            _navigationService.Navigate<MainPage>();
        }

        private void NavigationView_ItemInvoked(ModernWpf.Controls.NavigationView sender, ModernWpf.Controls.NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                _navigationService.Navigate<SettingsPage>();
            }
            else
            {
                var page = (args.InvokedItemContainer.Tag as Type);
                if (page != null)
                {
                    _navigationService.Navigate(page);
                }
            }
        }

        private void _mainwindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Settings.Default.KeepInTray)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
