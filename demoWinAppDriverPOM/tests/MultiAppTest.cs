using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demoWinAppDriverPOM.pages;
using demoWinAppDriverPOM.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;

namespace demoWinAppDriverPOM.tests
{
    [TestClass]
    public class MultiAppTests
    {
        private KeePassBase keePassBase;
        private SecondAppBase secondAppBase;
        WindowsDriver<WindowsElement> Driver => keePassBase.Driver;
        WindowsDriver<WindowsElement> SecondAppDriver => secondAppBase.SecondAppDriver;
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Setup()
        {
            keePassBase = new KeePassBase();
            secondAppBase = new SecondAppBase();
            secondAppBase.Setup();
            keePassBase.TestContext = TestContext;
            keePassBase.Setup();

            //keePassBase.InitializeKeePass();
            //secondAppBase.InitializeSecondApp();
        }

        [TestCleanup]
        public void TearDown()
        {
            keePassBase.TearDown();
            secondAppBase.CleanupSecondApp();
        }

        [TestMethod]
        public void TestBothApplications()
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
            }
            else
            {
                mainWindow = new MainWindow(Driver);
            }
            mainWindow.CheckMenuMainAccessibilityId();
            //var secondApp = new SecondAppBase();
            //secondApp.Setup();
            // Zugriff auf SecondAppDriver
            //secondAppBase.SecondAppDriver.FindElementByAccessibilityId("OtherElementId").Click();
        }
    }
}