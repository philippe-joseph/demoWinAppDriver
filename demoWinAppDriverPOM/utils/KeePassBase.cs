using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace demoWinAppDriverPOM.utils
{
    public class KeePassBase
    {
        protected WindowsDriver<WindowsElement> Driver;
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string KeePassAppId = @"C:\Users\Philippe\Downloads\KeePass-2.57.1\KeePass.exe";

        //public WindowsDriver<WindowsElement> Driver { get; }
        [TestInitialize]
        public void Setup()
        {
            // Create a new session to launch Notepad application
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", KeePassAppId);
            this.Driver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            Assert.IsNotNull(Driver);
            Assert.IsNotNull(Driver.SessionId);
        }
        [TestCleanup]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
