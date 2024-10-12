using CommunityToolkit.Mvvm.ComponentModel;
using IdeapadToolkit.Services;
using ModernWpf.Controls;
using System;

namespace IdeapadToolkit.ViewModels
{

    [INotifyPropertyChanged]
    public partial class SettingsViewModel
    {
        private readonly IRunOnStartupService _runOnStartupService;

        public SettingsViewModel(IRunOnStartupService runOnStartupService)
        {
            _runOnStartupService = runOnStartupService;
        }

        public bool IsRunOnStartupEnabled
        {
            get
            {
                return _runOnStartupService.IsRunOnStartupEnabled();
            }
            set
            {
                try
                {
                    _runOnStartupService.ToggleRunOnStartup();
                }
                catch (Exception ex)
                {
                    var dialog = new ContentDialog
                    {
                        Title = "Error",
                        Content = ex.Message,
                        CloseButtonText = "Ok"
                    }.ShowAsync();
                    
                }
            }
        }
    }
}
