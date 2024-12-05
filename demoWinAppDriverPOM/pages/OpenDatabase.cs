using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;

namespace demoWinAppDriverPOM.pages
{
    internal class OpenDatabase
    {
        private readonly WindowsDriver<WindowsElement> _driver;
        private string mainFormAutId = "KeyPromptForm";
        private string enterPasswordField = "m_tbPassword";
        private string password = "123abCD!#";
        private string openDBButton = "m_btnOK";
        //public WindowsElement KeePassOpenDBWindow { get; private set; }

        public WindowsElement KeePassOpenDBWindow()
        {
            return _driver.FindElementByAccessibilityId(mainFormAutId);
        }
        public OpenDatabase(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }
        public Boolean OpenDBWindowPresent()
        {
            try
            {
                _driver.FindElementByAccessibilityId(mainFormAutId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public MainWindow EnterPassword()
        {
            _driver.FindElementByAccessibilityId(enterPasswordField).SendKeys(password);
            _driver.FindElementByAccessibilityId(openDBButton).Click();
            var mainWindow = new MainWindow(_driver);
            var counter = 0;
            while (!mainWindow.MainFormPresent())
            {
                try
                {
                    var handles = _driver.WindowHandles;
                    _driver.SwitchTo().Window(handles[0]);
                }
                catch (Exception)
                {
                    Console.WriteLine("Main form not found - retry");
                }
                counter++;
                if (counter > 5)
                {
                    break;
                }
            }
            
            return mainWindow;
        }   
    }
}
