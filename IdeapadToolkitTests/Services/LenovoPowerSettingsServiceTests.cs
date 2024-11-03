using IdeapadToolkit.Core.Models;
using IdeapadToolkit.Core.Services;

namespace IdeapadToolkitTests.Services
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
        public void SetChargingModeRandomTest()
        {
            _service.SetChargingMode(ChargingMode.Normal);
            Assert.IsTrue(_service.GetChargingMode() == ChargingMode.Normal);
            _service.SetChargingMode(ChargingMode.Conservation);
            Assert.IsTrue(_service.GetChargingMode() == ChargingMode.Conservation);
            _service.SetChargingMode(ChargingMode.Rapid);
            Assert.IsTrue(_service.GetChargingMode() == ChargingMode.Rapid);
            _service.SetChargingMode(ChargingMode.Normal);
            Assert.IsTrue(_service.GetChargingMode() == ChargingMode.Normal);
        }
    }
}