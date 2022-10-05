using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeapadToolkit.Models;
using IdeapadToolkit.Services;
using ModernWpf.Controls;
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
        public LenovoSettingsViewModel(ILenovoPowerSettingsService lenovoPowerSettingsService, IUEFISettingsService uEFISettingsService, IAdministratorPermissionService administratorPermissionService)
        {
            _lenovoPowerSettingsService = lenovoPowerSettingsService;
            _uEFISettingsService = uEFISettingsService;
            _administratorPermissionService = administratorPermissionService;
        }

        public void Refresh()
        {
            Plan = _lenovoPowerSettingsService.GetPowerPlan();
            Mode = _lenovoPowerSettingsService.GetChargingMode();
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsEfficientChecked), nameof(IsIntelligentCoolingChecked), nameof(IsExtremePerformanceChecked))]
        private PowerPlan _plan;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsConservationModeEnabled), nameof(IsNormalModeEnabled), nameof(IsRapidModeEnabled))]
        private ChargingMode _mode;
        private readonly ILenovoPowerSettingsService _lenovoPowerSettingsService;
        private readonly IUEFISettingsService _uEFISettingsService;
        private IAdministratorPermissionService _administratorPermissionService;

        #region PowerPlanProperties
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
        #endregion

        #region OtherProperties
        public bool IsFlipToBootEnabled
        {
            get
            {
                if (IsAdministrator)
                {
                    return _uEFISettingsService.GetFlipToBootStatus();
                }
                else
                {
                    return false;
                }
            }
            set
            {
                _uEFISettingsService.SetFlipToBootStatus(value);
            }
        }



        public bool IsAlwaysOnUsbEnabled
        {
            get
            {
                return _lenovoPowerSettingsService.IsAlwaysOnUsbEnabled();
            }
            set
            {
                _lenovoPowerSettingsService.SetAlwaysOnUsb(value);
                OnPropertyChanged(nameof(IsAlwaysOnUsbEnabled));
            }
        }

        public bool IsAlwaysOnUsbBatteryEnabled
        {
            get
            {
                return _lenovoPowerSettingsService.IsAlwaysOnUsbBatteryEnabled();
            }
            set
            {
                _lenovoPowerSettingsService.SetAlwaysOnUsbBattery(value);
            }
        }
        #endregion

        #region ChargingModeProperties
        public bool IsConservationModeEnabled
        {
            get
            {
                return _mode == ChargingMode.Conservation;
            }
            set
            {
            }
        }

        public bool IsNormalModeEnabled
        {
            get
            {
                return _mode == ChargingMode.Normal;
            }
            set
            {
            }
        }

        public bool IsRapidModeEnabled
        {
            get
            {
                return _mode == ChargingMode.Rapid;
            }
            set
            {
            }
        }

        #endregion
        public bool IsAdministrator => _administratorPermissionService.IsAdministrator;

        [RelayCommand]
        private void SetChargingMode(int? mode)
        {
            if (mode == null) return;
            try
            {
                _lenovoPowerSettingsService.SetChargingMode((ChargingMode)mode);
                Refresh();
            }
            catch { }
        }

        [RelayCommand]
        private async Task RestartAsAdmin()
        {
            var res = await new ContentDialog
            {
                Title = "Permission required",
                Content = "The program will now restart as administrator",
                PrimaryButtonText = "Ok",
                SecondaryButtonText = "Cancel"
            }.ShowAsync();

            if (res == ContentDialogResult.Primary)
            {
                _administratorPermissionService.RelaunchAsAdmin();
            }
        }

        [RelayCommand]
        private void SetPlan(int? plan)
        {
            if (plan == null) return;
            try
            {
                _lenovoPowerSettingsService.SetPowerPlan((PowerPlan)plan);
                Refresh();
            }
            catch { }
        }
    }


}
