using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using static System.Collections.Specialized.BitVector32;

namespace TestProject2
{
    public class Keepass_basics
    {
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string KeePassAppId = @"C:\Users\Philippe\Downloads\KeePass-2.57.1\KeePass.exe";

        public WindowsDriver<WindowsElement> Session { get; }
        public WindowsElement KeePassMainWindow { get; private set; }

        public Keepass_basics()
        {
            // Create a new session to launch Notepad application
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", KeePassAppId);
            this.Session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            Assert.IsNotNull(Session);
            Assert.IsNotNull(Session.SessionId);
            //AutomationId	m_tbPassword
            try
            {
                var element = Session.FindElementByAccessibilityId("m_tbPassword");
                element.SendKeys("123abCD!#");
                element = Session.FindElementByAccessibilityId("m_btnOK");
                element.Click();
            }
            catch
            {
                Assert.Fail("Element with AccessibilityId m_tbPassword could not be found.");
            }
            Task.Delay(3000).Wait();
            var wait = new WebDriverWait(Session, TimeSpan.FromSeconds(20));
            var handles = Session.WindowHandles;
            Session.SwitchTo().Window(handles[0]);

            KeePassMainWindow = Session.FindElement(OpenQA.Selenium.By.XPath("//*[contains(@Name, 'KeePass')]"));
        }

        public void Dispose()
        {
            // Close the application and delete the session
            if (Session != null)
            {

                KeePassMainWindow = null;
                Session.Close();
                try
                {
                    // Dismiss Save dialog if it is blocking the exit
                    Session.FindElementByName("Discard changes").Click();
                }
                catch { }
                Session.Quit();
            }
        }
    }
}
