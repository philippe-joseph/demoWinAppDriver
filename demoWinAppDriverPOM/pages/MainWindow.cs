using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace demoWinAppDriverPOM.pages
{
    internal class MainWindow
    {
        private const string MainFormAutId = "";
        private const string MenuMainAccessibilityId = "MainForm";
        private const string OpenDatabaseElementName = "Open Database";
        private const string MainToolBarLoc = "m_toolMain";
        private const string MainToolBarButtonAddEntry = "Add Entry";
        private const string EntryListWindow = "m_lvEntries";
        //Name	Add Entry...
        private const string ContextAddEntry = "Add Entry...";
        private const string KeyEntryElement = "ListViewItem-";
        // ClassName	WindowsForms10.SysTreeView32.app.0.2bf8098_r6_ad1

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
                _driver.FindElementByAccessibilityId(MenuMainAccessibilityId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void FocusWindow()
        {
            var handles = _driver.WindowHandles;
            _driver.SwitchTo().Window(handles[0]);
        }

        public WindowsElement CheckMenuMainAccessibilityId()
        {
            var element = _driver.FindElementByAccessibilityId(MenuMainAccessibilityId);
            Assert.IsNotNull(element);
            return element;
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
                var element = _driver.FindElementByClassName(TreeViewClassName);
                Assert.IsNotNull(element);
                Console.WriteLine(DateTime.Now.ToString());
                Console.WriteLine($" Element with ClassName {TreeViewClassName} found.");
            }
            catch (Exception)
            {
                Assert.Fail($"Element with ClassName '{TreeViewClassName}' could not be found.");
            }
        }

        public AddEntry AddNewEntry()
        {
            var mainToolBar = _driver.FindElementByAccessibilityId(MainToolBarLoc);
            var addEntryButton = mainToolBar.FindElementByName(MainToolBarButtonAddEntry);
            addEntryButton.Click();
            return new AddEntry(_driver);
        }
        public AddEntry AddNewEntryThroughContext()
        {
            var entrylist = _driver.FindElementByAccessibilityId(EntryListWindow);
            // Rechtsklick auf das Element
            Actions actions = new Actions(_driver);
            actions.ContextClick(entrylist).Perform();
            _driver.FindElementByName(ContextAddEntry).Click();
            // wait for 5 seconds
            System.Threading.Thread.Sleep(5000);
            return new AddEntry(_driver);
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
        public Boolean ValidateListItemExists(int index)
        {
            try
            {
                _driver.FindElementByAccessibilityId(KeyEntryElement + index);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetListItemUsername(int index)
        {
            var kpWindow = _driver.FindElementByAccessibilityId(EntryListWindow);
            kpWindow.Click();
            var entry = _driver.FindElementByAccessibilityId(KeyEntryElement + index);
            return entry.FindElementByAccessibilityId("ListViewSubItem-1").Text;
        }
        public string GetListItemPassword(int index)
        {
            var entry = _driver.FindElementByAccessibilityId(KeyEntryElement + index);
            // Verwende Actions, um den Doppelklick auszuführen
            var actions = new Actions(_driver);
            actions.DoubleClick(entry).Perform(); // Doppelklick auf das Passwortfeld

            Thread.Sleep(500);

            // Passwort aus der Zwischenablage abrufen
            string password = Clipboard.GetText();
            return password;
        }
    }
}
