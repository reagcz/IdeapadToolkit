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
    public class BackgroundSettingServiceTests
    {
        IUEFISettingsService service;
        [TestInitialize]
        public void TestInitialize()
        {
            service = new UEFISettingsService();
        }

        [TestMethod()]
        public void IsFlipToBootOnTest()
        {
            var res = service.GetFlipToBootStatus();
            Assert.IsTrue(res>=0);
        }


        [TestMethod()]
        public void FlipToBootSettingTest()
        {
            var original = service.GetFlipToBootStatus();
            service.SetFlipToBootStatus(true);
            Assert.IsTrue(service.GetFlipToBootStatus() == 1);
            service.SetFlipToBootStatus(false);
            Assert.IsTrue(service.GetFlipToBootStatus() == 0);
            service.SetFlipToBootStatus(true);
            Assert.IsTrue(service.GetFlipToBootStatus() == 1);
            service.SetFlipToBootStatus(false);
            Assert.IsTrue(service.GetFlipToBootStatus() == 0);
            service.SetFlipToBootStatus(Convert.ToBoolean(original));

        }

    }
}