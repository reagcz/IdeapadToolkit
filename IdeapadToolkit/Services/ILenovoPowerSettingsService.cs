using IdeapadToolkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeapadToolkit.Services
{
    public interface ILenovoPowerSettingsService
    {
        public PowerPlan GetPowerPlan();
        public void SetPowerPlan(PowerPlan plan);

        public ChargingMode GetChargingMode();
        public void SetChargingMode(ChargingMode chargingMode);
    }
}
