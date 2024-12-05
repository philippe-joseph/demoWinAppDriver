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
            ReportingUtility.LogInfo("Start KeePass.");
            var openDB = new OpenDatabase(Driver);
            MainWindow mainWindow;
            if (openDB.OpenDBWindowPresent())
            {
                ReportingUtility.LogInfo("Login to last DB");
                //HighlightElementAndCaptureScreenshot(openDB.KeePassOpenDBWindow());
                mainWindow = openDB.EnterPassword();
            } else
            {
                mainWindow = new MainWindow(Driver);
            }
            mainWindow.CheckMenuMainAccessibilityId();
            mainWindow.FocusWindow();
            mainWindow.CheckTreeViewClassName();
        }

        [TestMethod]
        public void AddNewEntryToKPDB()
        {
            // Open KeePass
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
            mainWindow.CheckMenuMainAccessibilityId();
            ReportingUtility.LogInfo("Everything looks good");
            //var addEntry = mainWindow.AddNewEntry();
            var addEntry = mainWindow.AddNewEntryThroughContext();
            addEntry.AddEntryWindowPresent();
            addEntry.SetKeyName("myTestKey");
            mainWindow = addEntry.ClickOK();
        }
    }
}
