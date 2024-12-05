using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;

namespace demoWinAppDriverPOM.pages
{
    internal class AddEntry
    {
        private readonly WindowsDriver<WindowsElement> _driver;
        private string mainFormAutId = "PwEntryForm";
        private string newKeyTitleEdit = "m_tbTitle";
        private string dialogOKButton = "m_btnOK";

        public AddEntry(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }

        public Boolean AddEntryWindowPresent()
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
        public void SetKeyName(string keyName)
        {
            _driver.FindElementByAccessibilityId(newKeyTitleEdit).SendKeys(keyName);
        }
        public MainWindow ClickOK()
        {
            _driver.FindElementByAccessibilityId(dialogOKButton).Click();
            return new MainWindow(_driver);
        }
    }
}
