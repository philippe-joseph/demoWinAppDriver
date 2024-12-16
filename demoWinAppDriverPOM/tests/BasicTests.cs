using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demoWinAppDriverPOM.utils;
using demoWinAppDriverPOM.pages;
using OpenQA.Selenium;

namespace demoWinAppDriverPOM.tests
{
    [TestClass]
    public class BasicTests : KeePassBase
    {

        [TestMethod]
        public void OpenKPwithLastDB()
        {
            // Open KeePass
            var mainWindow = StartKeePass();
            mainWindow.CheckMenuMainAccessibilityId();
            mainWindow.FocusWindow();
            mainWindow.CheckTreeViewClassName();
        }

        [TestMethod]
        public void AddNewEntryToKPDB()
        {
            // Open KeePass
            var mainWindow = StartKeePass();
            mainWindow.CheckMenuMainAccessibilityId();
            ReportingUtility.LogInfo("Everything looks good");
            //var addEntry = mainWindow.AddNewEntry();
            var addEntry = mainWindow.AddNewEntryThroughContext();
            addEntry.AddEntryWindowPresent();
            addEntry.SetKeyName("myTestKey");
            mainWindow = addEntry.ClickOK();
        }

        [TestMethod]
        public void OpenDataBaseThroughFileSelect()
        {
            // Open KeePass
            var mainWindow = StartKeePass();
            var fileSelect = mainWindow.OpenDatabaseFileSelect();
            mainWindow = SwitchDatabaseByName("SecondDB.kdbx", fileSelect);
            // and switch back
            fileSelect = mainWindow.OpenDatabaseFileSelect();
            mainWindow = SwitchDatabaseByName("Database.kdbx", fileSelect);
        }

        private MainWindow StartKeePass()
        {
            ReportingUtility.LogInfo("Start KeePass.");
            var openDB = new OpenDatabase(Driver);
            MainWindow mainWindow;
            if (openDB.OpenDBWindowPresent())
            {
                var screenshotPath = "screenshot.png";
                ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(screenshotPath);
                ReportingUtility.Test.AddScreenCaptureFromPath(screenshotPath);
                mainWindow = openDB.EnterPassword();
            }
            else
            {
                mainWindow = new MainWindow(Driver);
            }
            return mainWindow;
        }

        private MainWindow SwitchDatabaseByName(String dbName, OpenDatabaseFileSelect fileSelect)
        {
            if (fileSelect.IsMainDialogPresent())
            {
                ReportingUtility.LogInfo("Open Database File dialog is present");
            }
            else
            {
                ReportingUtility.LogFail("Open Database File dialog is not present");
                AssertFailedException e = new AssertFailedException("Open Database File dialog is not present");
            }
            fileSelect.OpenDatabaseByName("SecondDB.kdbx");
            var openDB = new OpenDatabase(Driver);
            if (openDB.OpenDBWindowPresent())
            {
                var screenshotPath = "screenshot.png";
                ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(screenshotPath);
                ReportingUtility.Test.AddScreenCaptureFromPath(screenshotPath);
                return openDB.EnterPassword();
            }
            return null;
        }
    }
}
