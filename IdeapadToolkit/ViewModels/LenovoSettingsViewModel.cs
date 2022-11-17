using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeapadToolkit.Models;
using IdeapadToolkit.Services;
using ModernWpf.Controls;
using Serilog;
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
        public LenovoSettingsViewModel(ILenovoPowerSettingsService lenovoPowerSettingsService, IUEFISettingsService uEFISettingsService, IAdministratorPermissionService administratorPermissionService, ILogger logger)
        {
            _lenovoPowerSettingsService = lenovoPowerSettingsService;
            _uEFISettingsService = uEFISettingsService;
            _administratorPermissionService = administratorPermissionService;
            _logger = logger;
        }

        private readonly ILenovoPowerSettingsService _lenovoPowerSettingsService;
        private readonly IUEFISettingsService _uEFISettingsService;
        private IAdministratorPermissionService _administratorPermissionService;
        private readonly ILogger _logger;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsEfficientChecked), nameof(IsIntelligentCoolingChecked), nameof(IsExtremePerformanceChecked))]
        private PowerPlan _plan;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsConservationModeEnabled), nameof(IsNormalModeEnabled), nameof(IsRapidModeEnabled))]
        private ChargingMode _mode;
        public void Refresh()
        {
            try
            {
                Plan = _lenovoPowerSettingsService.GetPowerPlan();
                Mode = _lenovoPowerSettingsService.GetChargingMode();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Exception while fetching current settings");
            }
        }

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
                    bool res = false;
                    try
                    {
                        _uEFISettingsService.GetFlipToBootStatus();
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex, "Exception while getting FlipToBoot status");
                    }
                    return res;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                try
                {
                    _uEFISettingsService.SetFlipToBootStatus(value);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Exception while setting FlipToBoot status");
                }
            }
        }

        public bool IsAlwaysOnUsbEnabled
        {
            get
            {
                try
                {
                    return _lenovoPowerSettingsService.IsAlwaysOnUsbEnabled();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Error while getting Always on usb setting");
                    return false;
                }
            }
            set
            {
                try
                {
                    _lenovoPowerSettingsService.SetAlwaysOnUsb(value);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Error while setting Always on usb setting");
                }
                OnPropertyChanged(nameof(IsAlwaysOnUsbEnabled));
            }
        }

        public bool IsAlwaysOnUsbBatteryEnabled
        {
            get
            {
                try
                {
                    return _lenovoPowerSettingsService.IsAlwaysOnUsbBatteryEnabled();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Error while getting Always on usb battery setting");
                    return false;
                }
            }
            set
            {
                try
                {
                    _lenovoPowerSettingsService.SetAlwaysOnUsbBattery(value);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Error while setting Always on usb battery setting");
                }
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
            catch (Exception ex)
            {
                _logger.Error(ex, "Error while setting charging mode");
            }
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
            catch (Exception ex)
            {
                _logger.Error(ex, "Exception while setting power plan");
            }
        }
    }


}
