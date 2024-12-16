using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using OpenQA.Selenium.Appium.Windows;

namespace demoWinAppDriverPOM.pages
{
    internal class OpenDatabaseFileSelect
    {
        private readonly WindowsDriver<WindowsElement> _driver;

        // Name Open Database File
        private const string mainDialog = "Open Database File";

        public OpenDatabaseFileSelect(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }

        public Boolean IsMainDialogPresent()
        {
            try
            {
                _driver.FindElementByName(mainDialog);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void OpenDatabaseByName(string dbName)
        {
            //Name	Open Database File
            var window = _driver.FindElementByName(mainDialog);
            var element = window.FindElementByName(dbName);
            Assert.IsNotNull(element);
            element.Click();
            var buttons = _driver.FindElementsByClassName("Button");
            foreach (var button in buttons)
            {
                if (button.Text == "Öffnen")
                {
                    button.Click();
                    break;
                }
            }
        }
    }
}
