using Hardcodet.Wpf.TaskbarNotification;
using IdeapadToolkit.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
    }
}
