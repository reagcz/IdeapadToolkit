using IdeapadToolkit.Core.Models;
using System.Runtime.InteropServices;

namespace IdeapadToolkit.Core.Services
{
    public partial class LenovoPowerSettingsService : ILenovoPowerSettingsService
    {
        [LibraryImport("PowerBattery.dll", EntryPoint = "?SetITSMode@CIntelligentCooling@PowerBattery@@QEAAHAEAW4ITSMode@12@@Z", SetLastError = true)]
        [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        internal static partial int SetITSMode(ref CIntelligentCooling var1, ref PowerPlan var2);

        [LibraryImport("PowerBattery.dll", EntryPoint = "??0CIntelligentCooling@PowerBattery@@QEAA@XZ", SetLastError = true)]
        [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        internal static partial CIntelligentCooling CIntelligentCooling(ref CIntelligentCooling var1);

        [LibraryImport("PowerBattery.dll", EntryPoint = "?GetITSMode@CIntelligentCooling@PowerBattery@@QEAAHAEAHAEAW4ITSMode@12@@Z", SetLastError = true)]
        [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        internal static partial int GetITSMode(ref CIntelligentCooling var1, ref int var2, ref PowerPlan var3);

        [LibraryImport("PowerBattery.dll", EntryPoint = "??0CChargingMode@PowerBattery@@QEAA@XZ", SetLastError = true)]
        [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        internal static partial CChargingMode CChargingMode(ref CChargingMode var1);

        [LibraryImport("PowerBattery.dll", EntryPoint = "?GetChargingMode@CChargingMode@PowerBattery@@QEBAHXZ", SetLastError = true)]
        [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        internal static partial int GetChargingMode(ref CChargingMode var1);

        [LibraryImport("PowerBattery.dll", EntryPoint = "?SetChargingMode@CChargingMode@PowerBattery@@QEBAHH@Z", SetLastError = true)]
        [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        internal static partial int SetChargingMode(ref CChargingMode var1, int var2);

        [LibraryImport("PowerBattery.dll", EntryPoint = "?SetChargingMode@CChargingMode@PowerBattery@@QEBAHH_N@Z", SetLastError = true)]
        [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        // I don't know what the newly added boolean does, but it doesn't seem to matter
        internal static partial int SetChargingModeFallBack(ref CChargingMode var1, int var2, [MarshalAs(UnmanagedType.Bool)] bool var3);

        [LibraryImport("PowerBattery.dll", EntryPoint = "??0CUSBCharger@PowerBattery@@QEAA@XZ", SetLastError = true)]
        [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        internal static partial CUSBCharger CUSBCharger(ref CUSBCharger var1);

        [LibraryImport("PowerBattery.dll", EntryPoint = "??0CUSBBatteryCharger@PowerBattery@@QEAA@XZ", SetLastError = true)]
        [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        internal static partial CUSBBatteryCharger CUSBBatteryCharger(ref CUSBBatteryCharger var1);

        [LibraryImport("PowerBattery.dll", EntryPoint = "?OpenOrClose@CUSBBatteryCharger@PowerBattery@@UEAAHXZ", SetLastError = true)]
        [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        internal static partial int OpenOrClose(ref CUSBBatteryCharger var1);

        [LibraryImport("PowerBattery.dll", EntryPoint = "?OpenOrClose@CUSBCharger@PowerBattery@@UEAAHXZ", SetLastError = true)]
        [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        internal static partial int OpenOrClose(ref CUSBCharger var1);

        [LibraryImport("PowerBattery.dll", EntryPoint = "?OpenFeature@CUSBCharger@PowerBattery@@UEAAHXZ", SetLastError = true)]
        [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        internal static partial int OpenFeature(ref CUSBCharger var1);

        [LibraryImport("PowerBattery.dll", EntryPoint = "?OpenFeature@CUSBBatteryCharger@PowerBattery@@UEAAHXZ", SetLastError = true)]
        [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        internal static partial int OpenFeature(ref CUSBBatteryCharger var1);

        [LibraryImport("PowerBattery.dll", EntryPoint = "?CloseFeature@CUSBCharger@PowerBattery@@UEAAHXZ", SetLastError = true)]
        [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        internal static partial int CloseFeature(ref CUSBCharger var1);

        [LibraryImport("PowerBattery.dll", EntryPoint = "?CloseFeature@CUSBBatteryCharger@PowerBattery@@UEAAHXZ", SetLastError = true)]
        [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        internal static partial int CloseFeature(ref CUSBBatteryCharger var1);

        public PowerPlan GetPowerPlan()
        {
            CIntelligentCooling instance = new();
            instance = CIntelligentCooling(ref instance);
            PowerPlan newmode = new();
            int trash = 0;
            _ = GetITSMode(ref instance, ref trash, ref newmode);
            return newmode;
        }

        public void SetPowerPlan(PowerPlan plan)
        {
            CIntelligentCooling instance = new();
            instance = CIntelligentCooling(ref instance);
            _ = SetITSMode(ref instance, ref plan);
        }

        public ChargingMode GetChargingMode()
        {
            CChargingMode instance = new();
            instance = CChargingMode(ref instance);
            ChargingMode mode = (ChargingMode)GetChargingMode(ref instance);
            return mode;
        }

        public void SetChargingMode(ChargingMode chargingMode)
        {
            CChargingMode instance = new();
            instance = CChargingMode(ref instance);
            try
            {
                _ = SetChargingMode(ref instance, (int)chargingMode);
            }
            catch (SystemException)
            {
                _ = SetChargingModeFallBack(ref instance, (int)chargingMode, false);
            }
        }

        public bool IsAlwaysOnUsbEnabled()
        {
            CUSBCharger instance = new();
            instance = CUSBCharger(ref instance);
            var res = OpenOrClose(ref instance);
            return res switch
            {
                2 => false,
                1 => true,
                _ => false
            };
        }

        public void SetAlwaysOnUsb(bool alwaysOnUsbEnabled)
        {
            CUSBCharger instance = new();
            instance = CUSBCharger(ref instance);
            switch (alwaysOnUsbEnabled)
            {
                case true:
                    _ = OpenFeature(ref instance);
                    break;
                case false:
                    _ = CloseFeature(ref instance);
                    break;
            }
        }

        public bool IsAlwaysOnUsbBatteryEnabled()
        {
            CUSBBatteryCharger instance = new();
            instance = CUSBBatteryCharger(ref instance);
            var res = OpenOrClose(ref instance);
            return res switch
            {
                2 => false,
                1 => true,
                _ => false
            };
        }

        public void SetAlwaysOnUsbBattery(bool alwaysOnUsbBattryEnabled)
        {
            CUSBBatteryCharger instance = new();
            instance = CUSBBatteryCharger(ref instance);
            switch (alwaysOnUsbBattryEnabled)
            {
                case true:
                    _ = OpenFeature(ref instance);
                    break;
                case false:
                    _ = CloseFeature(ref instance);
                    break;
            }
        }
    }
}
