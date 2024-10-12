using IdeapadToolkit.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace IdeapadToolkit.Views
{
    /// <summary>
    /// Interaction logic for TrayIconView.xaml
    /// </summary>
    public partial class TrayIconView : Page
    {
        private readonly LenovoSettingsViewModel _vm;

        public TrayIconView(LenovoSettingsViewModel vm)
        {
            this.DataContext = vm;
            InitializeComponent();
            this._vm = vm;
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        public void MakeVisible()
        {
            {
                TrayIcon.Visibility = Visibility.Visible;
            }
        }

        private void ContextMenu_Loaded(object sender, RoutedEventArgs e)
        {
            _vm.Refresh();
        }

        public EventHandler TrayIconClicked;
        private void TrayIcon_TrayMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            TrayIconClicked?.Invoke(this, e);
        }
    }
}
