using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace demoWinAppDriverPOM.utils
{
    internal class ReportingUtility
    {
        public static ExtentReports Extent;
        public static ExtentTest Test;

        public static void InitializeReport()
        {
            var htmlReporter = new ExtentSparkReporter("TestReport.html");
            htmlReporter.Config.DocumentTitle = "Automation Test Report";
            htmlReporter.Config.ReportName = "My WinAppDriver Tests";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Standard;

            Extent = new ExtentReports();
            Extent.AttachReporter(htmlReporter);
        }

        public static void FinalizeReport()
        {
            Extent.Flush();
        }

        public static void CreateTest(string testName)
        {
            Test = Extent.CreateTest(testName);
        }

        public static void LogPass(string message)
        {
            Test.Pass(message);
        }

        public static void LogFail(string message)
        {
            Test.Fail(message);
        }

        public static void LogInfo(string message)
        {
            Test.Info(message);
        }
    }
}
