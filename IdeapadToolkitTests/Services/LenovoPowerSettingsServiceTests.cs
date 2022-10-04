using Microsoft.VisualStudio.TestTools.UnitTesting;
using IdeapadToolkit.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeapadToolkit.Services.Tests
{
    [TestClass()]
    public class LenovoPowerSettingsServiceTests
    {
        private ILenovoPowerSettingsService _service;
        [TestInitialize]
        public void TestInitialize()
        {
            _service = new LenovoPowerSettingsService();
        }

        [TestMethod()]
        public void IsAlwaysOnUsbEnabledTest()
        {
            var res = _service.IsAlwaysOnUsbEnabled();
            Assert.IsTrue(res);
        }

        [TestMethod()]
        public void IsAlwaysOnUsbBattryEnabledTest()
        {
            var res = _service.IsAlwaysOnUsbBatteryEnabled();
            Assert.IsTrue(res);
        }


        [TestMethod()]
        public void AlwaysOnUsbRandomTest()
        {
            var res = _service.IsAlwaysOnUsbEnabled();
            _service.SetAlwaysOnUsb(!res);
            var res2 = _service.IsAlwaysOnUsbEnabled();
            Assert.AreEqual(!res, res2);
            _service.SetAlwaysOnUsb(res);
            var res3 = _service.IsAlwaysOnUsbEnabled();
            Assert.AreEqual(res, res3);
        }

        [TestMethod()]
        public void AlwaysOnUsbBattryRandomTest()
        {
            var res = _service.IsAlwaysOnUsbBatteryEnabled();
            _service.SetAlwaysOnUsbBattery(!res);
            var res2 = _service.IsAlwaysOnUsbBatteryEnabled();
            Assert.AreEqual(!res, res2);
            _service.SetAlwaysOnUsbBattery(res);
            var res3 = _service.IsAlwaysOnUsbBatteryEnabled();
            Assert.AreEqual(res, res3);
        }

        [TestMethod()]
        private void SetChargingModeRandomTest()
        {
            _service.SetChargingMode(Models.ChargingMode.Normal);
            Assert.IsTrue(_service.GetChargingMode() == Models.ChargingMode.Normal);
            _service.SetChargingMode(Models.ChargingMode.Conservation);
            Assert.IsTrue(_service.GetChargingMode() == Models.ChargingMode.Conservation);
            _service.SetChargingMode(Models.ChargingMode.Rapid);
            Assert.IsTrue(_service.GetChargingMode() == Models.ChargingMode.Rapid);
            _service.SetChargingMode(Models.ChargingMode.Normal);
            Assert.IsTrue(_service.GetChargingMode() == Models.ChargingMode.Normal);
        }
    }
}