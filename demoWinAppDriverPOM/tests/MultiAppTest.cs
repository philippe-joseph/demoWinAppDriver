﻿using System;
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
                mainWindow = openDB.EnterPassword();
            }
            else
            {
                mainWindow = new MainWindow(Driver);
            }
            mainWindow.CheckMenuMainAccessibilityId();
            RxMainApp rxMainApp = new RxMainApp(SecondAppDriver);
            if (rxMainApp.MainFormPresent())
            {
                ReportingUtility.LogInfo("RxMainApp is present");
            }
            else
            {
                ReportingUtility.LogInfo("RxMainApp is not present");
            }
            rxMainApp.SwitchToDataBase();
            mainWindow.ValidateListItemExists(1);
            var username = mainWindow.GetListItemUsername(1);
            var password = mainWindow.GetListItemPassword(1);
            ReportingUtility.LogInfo("Username: " + username);
            ReportingUtility.LogInfo("Password: " + password);
            RxTestDatabase rxTestDatabase = new RxTestDatabase(SecondAppDriver);
            rxTestDatabase.EnterFirstName(username);
            rxTestDatabase.EnterLastName(password);

        }
        [TestMethod]
        public void TestRxUiElemnts()
        {
            RxMainApp rxMainApp = new RxMainApp(SecondAppDriver);
            if (rxMainApp.MainFormPresent())
            {
                ReportingUtility.LogInfo("RxMainApp is present");
            }
            else
            {
                ReportingUtility.LogInfo("RxMainApp is not present");
            }
            var uiElemArea = new RxUIElementTestArea(SecondAppDriver);
            uiElemArea.GetTabElement().Click();
            var response = uiElemArea.FindeUserEntryByFirstAndLastName("Nicole", "Wallace");
            ReportingUtility.LogInfo("Response: " + response);
        }
    }
}