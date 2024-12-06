using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace demoWinAppDriverPOM.utils
{
    public class SecondAppBase
    {
        //protected WindowsDriver<WindowsElement> Driver;
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string RanorexDemo = @"C:\Users\Philippe\Downloads\RxDemoApp\RxDemoApp.exe";
        public WindowsDriver<WindowsElement> SecondAppDriver;
        //public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Setup()
        {
            //ReportingUtility.InitializeReport();
            //ReportingUtility.CreateTest(TestContext.TestName);
            // Initialisiere den Driver
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", RanorexDemo);
            this.SecondAppDriver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            Assert.IsNotNull(SecondAppDriver);
            Assert.IsNotNull(SecondAppDriver.SessionId);
            ReportingUtility.LogInfo("SecondAppDriver initialized successfully.");
        }

        [TestCleanup]
        public void CleanupSecondApp()
        {
            SecondAppDriver?.Quit();
        }
    }
}
