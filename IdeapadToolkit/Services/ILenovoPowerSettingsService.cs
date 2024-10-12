using IdeapadToolkit.Models;

namespace IdeapadToolkit.Services
{
    public interface ILenovoPowerSettingsService
    {
        public PowerPlan GetPowerPlan();
        public void SetPowerPlan(PowerPlan plan);

        public ChargingMode GetChargingMode();
        public void SetChargingMode(ChargingMode chargingMode);

        public bool IsAlwaysOnUsbEnabled();
        public void SetAlwaysOnUsb(bool alwaysOnUsbEnabled);

        public bool IsAlwaysOnUsbBatteryEnabled();
        public void SetAlwaysOnUsbBattery(bool alwaysOnUsbBattryEnabled);
    }
}
