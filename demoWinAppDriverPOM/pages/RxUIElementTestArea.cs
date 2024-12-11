using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;

namespace demoWinAppDriverPOM.pages
{
    internal class RxUIElementTestArea
    {
        private readonly WindowsDriver<WindowsElement> _driver;
        //Name	UI-element test area
        private string tabName = "UI-element test area";

        public RxUIElementTestArea(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }
        public WindowsElement GetTabElement()
        {
            return _driver.FindElementByName(tabName);
        }
        public string FindeUserByFirstName()
        {
            //ValuePattern.Value	FirstName
            return _driver.FindElementByXPath("//*[@ValuePattern.Value = 'FirstName']").Text;
        }
        public string FindeUserEntryByFirstAndLastName(string firstName, string lastName)
        {
            //Name	FirstName
            //Name	LastName
            return _driver.FindElementByXPath($"//*[@ValuePattern.Value>'{firstName},{lastName}']").Text;
        }
    }
}
