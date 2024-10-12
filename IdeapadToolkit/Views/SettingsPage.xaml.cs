using IdeapadToolkit.ViewModels;

namespace IdeapadToolkit.Views
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : ModernWpf.Controls.Page
    {
        public SettingsPage(SettingsViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
        }
    }
}
