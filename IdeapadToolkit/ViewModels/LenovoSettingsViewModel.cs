using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeapadToolkit.Models;
using IdeapadToolkit.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeapadToolkit.ViewModels
{
    [CommunityToolkit.Mvvm.ComponentModel.INotifyPropertyChanged]
    public partial class LenovoSettingsViewModel
    {
        public LenovoSettingsViewModel(ILenovoPowerSettingsService lenovoPowerSettingsService)
        {
            _lenovoPowerSettingsService = lenovoPowerSettingsService;
        }

        public void Refresh()
        {
            Plan = _lenovoPowerSettingsService.GetPowerPlan();

        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsEfficientChecked), nameof(IsIntelligentCoolingChecked), nameof(IsExtremePerformanceChecked))]
        private PowerPlan _plan;
        private readonly ILenovoPowerSettingsService _lenovoPowerSettingsService;
        public bool IsEfficientChecked
        {
            get
            {
                return _plan == PowerPlan.EfficiencyMode;
            }
            set { }
        }

        public bool IsIntelligentCoolingChecked
        {
            get
            {
                return _plan == PowerPlan.IntelligentCooling;
            }
            set { }
        }

        public bool IsExtremePerformanceChecked
        {
            get
            {
                return _plan == PowerPlan.ExtremePerformance;
            }
            set { }
        }

        [RelayCommand]
        private void SetPlan(int? plan)
        {
            if(plan == null) return;
            try
            {
                _lenovoPowerSettingsService.SetPowerPlan((PowerPlan)plan);
                Refresh();
            }
            catch { }
        }
    }


}
