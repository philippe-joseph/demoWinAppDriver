using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;

namespace demoWinAppDriverPOM.pages
{
    internal class MainWindow
    {
        private const string MainFormAutId = "";
        private const string MenuMainAccessibilityId = "MainForm";
        private const string FileElementName = "File";
        private const string OpenDatabaseElementName = "Open Database";
        private const string TreeViewClassName = "WindowsForms10.SysTreeView32.app.0.2bf8098_r6_ad1";
        private const string DocumentXPath = "//*[@LocalizedControlType='Dokument']";

        private readonly WindowsDriver<WindowsElement> _driver;
        private readonly WebDriverWait wait;

        public MainWindow(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }
        public Boolean MainFormPresent()
        {
            try
            {
                _driver.FindElementByAccessibilityId(MainFormAutId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public WindowsElement CheckMenuMainAccessibilityId()
        {
            var element = _driver.FindElementByAccessibilityId(MenuMainAccessibilityId);
            Assert.IsNotNull(element);
            return element;
        }

        public void CheckFileElementName()
        {
            try
            {
                var element = wait.Until(drv => _driver.FindElementByName(FileElementName));
                Assert.IsNotNull(element);
                Console.WriteLine(DateTime.Now.ToString());
                Console.WriteLine($" Element with Name {FileElementName} found.");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Element with Name {FileElementName} could not be found.");
            }
        }

        public void CheckOpenDatabaseElementName()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementExists(By.Name(OpenDatabaseElementName)));
                var element = _driver.FindElementByName(OpenDatabaseElementName);
                Assert.IsNotNull(element);
                Console.WriteLine(DateTime.Now.ToString());
                Console.WriteLine($" Element with Name {OpenDatabaseElementName} found.");
            }
            catch (Exception)
            {
                Assert.Fail($"Element with Name {OpenDatabaseElementName} could not be found.");
            }
        }

        public void CheckTreeViewClassName()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementExists(By.ClassName(TreeViewClassName)));
                var element = _driver.FindElementByClassName(TreeViewClassName);
                var multipleElements = _driver.FindElementsByClassName(TreeViewClassName);
                if (multipleElements.Count > 1)
                {
                    Console.WriteLine("Multiple elements found.");
                }
                Assert.IsNotNull(element);
                Console.WriteLine(DateTime.Now.ToString());
                Console.WriteLine($" Element with ClassName {TreeViewClassName} found.");
            }
            catch (Exception)
            {
                Assert.Fail($"Element with ClassName '{TreeViewClassName}' could not be found.");
            }
        }

        public void CheckDocumentXPath()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementExists(By.XPath(DocumentXPath)));
                var element = _driver.FindElementByXPath(DocumentXPath);
                Assert.IsNotNull(element);
                Console.WriteLine(DateTime.Now.ToString());
                Console.WriteLine($" Element with XPath {DocumentXPath} found.");
            }
            catch (Exception)
            {
                Assert.Fail($"Element with XPath {DocumentXPath} could not be found.");
            }
        }
    }
}
