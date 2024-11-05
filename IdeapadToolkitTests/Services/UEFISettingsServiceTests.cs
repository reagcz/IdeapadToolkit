using IdeapadToolkit.Core.Services;
using Moq;
using Serilog;

namespace IdeapadToolkitTests.Services
{
    [TestClass()]
    public class UEFISettingsServiceTests
    {
        IUEFISettingsService _service;
        [TestInitialize]
        public void TestInitialize()
        {
            var loggerMock = new Mock<ILogger>();
            _service = new UEFISettingsService(loggerMock.Object);
        }

        [TestMethod()]
        public void IsFlipToBootOnTest()
        {
            var res = _service.GetFlipToBootStatus();
            Assert.IsNotNull(res);
        }

        [TestMethod()]
        public void FlipToBootSettingTest()
        {
            var original = _service.GetFlipToBootStatus();
            _service.SetFlipToBootStatus(true);
            Assert.IsTrue(_service.GetFlipToBootStatus());
            _service.SetFlipToBootStatus(false);
            Assert.IsFalse(_service.GetFlipToBootStatus());
            _service.SetFlipToBootStatus(true);
            Assert.IsTrue(_service.GetFlipToBootStatus());
            _service.SetFlipToBootStatus(false);
            Assert.IsFalse(_service.GetFlipToBootStatus());
            _service.SetFlipToBootStatus(Convert.ToBoolean(original));
        }
    }
}