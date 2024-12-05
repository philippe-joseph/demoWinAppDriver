using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace demoWinAppDriverPOM.utils
{
    public static class ReportingUtility
    {
        private static ExtentReports _extent;
        private static ExtentTest _currentTest;
        public static ExtentTest Test => _currentTest;

        private static readonly object LockObject = new object();

        public static void InitializeReport()
        {
            if (_extent == null)
            {
                lock (LockObject)
                {
                    if (_extent == null) // Doppelte Prüfung
                    {
                        var htmlReporter = new ExtentSparkReporter("TestReport.html");
                        htmlReporter.Config.DocumentTitle = "KeePass Test Report";
                        htmlReporter.Config.ReportName = "KeePass Automation Tests";
                        htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Standard;

                        _extent = new ExtentReports();
                        _extent.AttachReporter(htmlReporter);
                    }
                }
            }
        }

        public static ExtentReports GetReportInstance()
        {
            if (_extent == null)
            {
                InitializeReport();
            }
            return _extent;
        }

        public static void FinalizeReport()
        {
            _extent?.Flush();
        }

        public static bool IsReportInitialized()
        {
            return _extent != null;
        }

        public static void CreateTest(string testName)
        {
            if (_extent == null)
            {
                throw new NullReferenceException("ExtentReports instance is null. Ensure InitializeReport() was called.");
            }
            _currentTest = _extent.CreateTest(testName);
        }

        public static void LogPass(string message)
        {
            _currentTest?.Pass(message);
        }

        public static void LogFail(string message)
        {
            _currentTest?.Fail(message);
        }

        public static void LogInfo(string message)
        {
            _currentTest?.Info(message);
        }
    }
}