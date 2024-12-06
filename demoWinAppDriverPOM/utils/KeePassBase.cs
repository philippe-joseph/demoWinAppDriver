using Microsoft.VisualStudio.TestTools.UnitTesting;
using demoWinAppDriverPOM.utils;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System.Drawing;
using System.Drawing.Imaging;

namespace demoWinAppDriverPOM.utils
{
    public class KeePassBase
    {
        public WindowsDriver<WindowsElement> Driver;
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string KeePassAppId = @"C:\Users\Philippe\Downloads\KeePass-2.57.1\KeePass.exe";

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Setup()
        {
            ReportingUtility.InitializeReport();
            ReportingUtility.CreateTest(TestContext.TestName);
            // Initialisiere den Driver
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", KeePassAppId);
            appCapabilities.SetCapability("language", "de-DE");
            this.Driver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            Assert.IsNotNull(Driver);
            Assert.IsNotNull(Driver.SessionId);
            ReportingUtility.LogInfo("Driver initialized successfully.");
        }

        [TestCleanup]
        public void TearDown()
        {
            try
            {
                Driver?.Quit();
                ReportingUtility.LogInfo("Driver quit successfully.");
            }
            catch (Exception ex)
            {
                ReportingUtility.LogFail($"Driver quit failed: {ex.Message}");
            }
            ReportingUtility.FinalizeReport();
        }



        public void HighlightElementAndCaptureScreenshot(WindowsElement element)
        {
            // Nimm einen Screenshot des gesamten Fensters auf
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();

            // Lade den Screenshot direkt in einen Memory Stream
            using (var memoryStream = new MemoryStream(screenshot.AsByteArray))
            {
                using (var bitmap = new Bitmap(memoryStream))
                {
                    using (var graphics = Graphics.FromImage(bitmap))
                    {
                        // Hole die Position und Größe des Elements
                        var location = element.Location;
                        var size = element.Size;

                        // Zeichne einen roten Rahmen um das Element
                        var pen = new Pen(Color.Red, 3); // 3 Pixel dick
                        graphics.DrawRectangle(pen, new Rectangle(location.X, location.Y, size.Width, size.Height));
                    }

                    // Speichere das bearbeitete Bild
                    var screenshotPath = "highlighted_screenshot.png";
                    bitmap.Save(screenshotPath, ImageFormat.Png);

                    // Füge den Screenshot dem Report hinzu
                    ReportingUtility.Test.AddScreenCaptureFromPath(screenshotPath);
                }
            }
        }
    }
}