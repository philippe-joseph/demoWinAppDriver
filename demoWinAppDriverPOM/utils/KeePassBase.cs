using Microsoft.VisualStudio.TestTools.UnitTesting;
using demoWinAppDriverPOM.utils;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace demoWinAppDriverPOM.utils
{
    public class KeePassBase
    {
        protected WindowsDriver<WindowsElement> Driver;
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string KeePassAppId = @"C:\Users\Philippe\Downloads\KeePass-2.57.1\KeePass.exe";

        public TestContext TestContext { get; set; }
        //[ClassInitialize]
        //public static void AssemblyInit(TestContext context)
        //{
        //    ReportingUtility.InitializeReport();
        //}

        //public WindowsDriver<WindowsElement> Driver { get; }
        [TestInitialize]
        public void Setup()
        {
            ReportingUtility.InitializeReport();
            ReportingUtility.CreateTest(TestContext.TestName);

            // Create a new session to launch Notepad application
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", KeePassAppId);
            this.Driver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            Assert.IsNotNull(Driver);
            Assert.IsNotNull(Driver.SessionId);
            ReportingUtility.LogInfo("Driver initialized successfully.");
        }
        [TestCleanup]
        public void TearDown()
        {
            try
            {
                Driver?.Quit();
                ReportingUtility.LogInfo("Driver quit successfully.");
            }
            catch (Exception ex)
            {
                ReportingUtility.LogFail($"Driver quit failed: {ex.Message}");
            }
            ReportingUtility.FinalizeReport();
        }
        //[ClassCleanup]
        //public static void AssemblyCleanup()
        //{
        //    ReportingUtility.FinalizeReport();
        //}
    }
}
