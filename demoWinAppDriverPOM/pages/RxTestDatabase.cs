using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;

namespace demoWinAppDriverPOM.pages
{
    internal class RxTestDatabase
    {
        private readonly WindowsDriver<WindowsElement> _driver;
        private const string FirstNameLabel = "lblFirstName";
        private const string LastNameLabel = "lblLastName";
        private const string FirstNameEdit = "txtFirstName";
        private const string LastNameEdit = "txtLastName";
        public RxTestDatabase(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }
        public void EnterFirstName(string firstName)
        {
            _driver.FindElementByAccessibilityId(FirstNameEdit).Clear();
            _driver.FindElementByAccessibilityId(FirstNameEdit).SendKeys(firstName);
        }
        public void EnterLastName(string lastName)
        {
            _driver.FindElementByAccessibilityId(LastNameEdit).Clear();
            _driver.FindElementByAccessibilityId(LastNameEdit).SendKeys(lastName);
        }
    }
}
