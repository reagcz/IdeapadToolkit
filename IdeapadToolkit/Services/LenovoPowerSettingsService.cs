using IdeapadToolkit.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeapadToolkit.Services
{
    public class LenovoPowerSettingsService : ILenovoPowerSettingsService
    {
        [DllImport("PowerBattery.dll", EntryPoint = "#142", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        internal static extern int SetITSMode(ref CIntelligentCooling var1, ref PowerPlan var2);


        [DllImport("PowerBattery.dll", EntryPoint = "#8", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        internal static extern CIntelligentCooling CIntelligentCooling(ref CIntelligentCooling var1);


        [DllImport("PowerBattery.dll", EntryPoint = "#82", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        internal static extern int GetITSMode(ref CIntelligentCooling var1, ref int var2, ref PowerPlan var3);


        [DllImport("PowerBattery.dll", EntryPoint = "#6", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        internal static extern CChargingMode CChargingMode(ref CChargingMode var1);


        [DllImport("PowerBattery.dll", EntryPoint = "#74", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        internal static extern int GetChargingMode(ref CChargingMode var1);


        [DllImport("PowerBattery.dll", EntryPoint = "#139", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        internal static extern int SetChargingMode(ref CChargingMode var1, int var2);



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
            ChargingMode mode = (ChargingMode)(GetChargingMode(ref instance));
            return mode;
        }

        public void SetChargingMode(ChargingMode chargingMode)
        {
            CChargingMode instance = new();
            instance = CChargingMode(ref instance);
            SetChargingMode(ref instance, (int)chargingMode);
        }
    }
}
