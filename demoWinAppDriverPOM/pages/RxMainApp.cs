using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;

namespace demoWinAppDriverPOM.pages
{
    internal class RxMainApp
    {
        private readonly WindowsDriver<WindowsElement> _driver;
        //AutomationId	RxMainFrame
        private string mainFormAutId = "RxMainFrame";

        public RxMainApp(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }

        public Boolean MainFormPresent()
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
    }
}
