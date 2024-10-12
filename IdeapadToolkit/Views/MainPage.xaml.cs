using IdeapadToolkit.ViewModels;
using System.Windows;

namespace IdeapadToolkit.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainPage : ModernWpf.Controls.Page
    {
        private readonly LenovoSettingsViewModel _vm;

        public MainPage(LenovoSettingsViewModel vm)
        {
            this.DataContext = vm;
            InitializeComponent();
            this._vm = vm;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _vm.Refresh();
        }
    }
}
