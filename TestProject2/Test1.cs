using System.Data;
using System.Xml.Linq;
using NotepadCalculatorTest;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;


// c6Gah4FQ
namespace TestProject2
{
    [TestClass]
    public sealed class Test1
    {
        private static Keepass_basics keepass_basics;
        private WindowsDriver<WindowsElement> session => keepass_basics.Session;
        [TestMethod]
        public void BasicTestKeePass()
        {
            keepass_basics.Session.SwitchTo();

            var wait = new WebDriverWait(session, TimeSpan.FromSeconds(20));
            var element = session.FindElementByAccessibilityId("m_menuMain");
            Assert.IsNotNull(element);

            var elementName = "File";
            try
            {
                element = wait.Until(drv => session.FindElementByName(elementName));
                Assert.IsNotNull(element);
                Console.WriteLine(DateTime.Now.ToString());
                Console.WriteLine($" Element with Name {elementName} found.");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Element with Name {elementName} could not be found.");
            }
            elementName = "Open Database";
            try
            {
                wait.Until(ExpectedConditions.ElementExists( By.Name(elementName)));
                element = session.FindElementByName(elementName);
                Assert.IsNotNull(element);
                Console.WriteLine(DateTime.Now.ToString());
                Console.WriteLine($" Element with Name {elementName} found.");
            }
            catch (Exception)
            {
                Assert.Fail($"Element with Name {elementName} could not be found.");
            }
            // ClassName	WindowsForms10.SysTreeView32.app.0.2bf8098_r6_ad1
            var className = "WindowsForms10.SysTreeView32.app.0.2bf8098_r6_ad1";
            try
            {
                wait.Until(ExpectedConditions.ElementExists(By.ClassName(className)));
                element = session.FindElementByClassName(className);
                var multipleElements = session.FindElementsByClassName(className);
                if (multipleElements.Count > 1)
                {
                    Console.WriteLine("Multiple elements found.");
                }
                Assert.IsNotNull(element);
                Console.WriteLine(DateTime.Now.ToString());
                Console.WriteLine($" Element with ClassName {className} found.");
            }
            catch (Exception)
            {
                Assert.Fail("Element with ClassName 'WindowsForms10.SysTreeView32.app.0.2bf8098_r6_ad1e' could not be found.");
            }

            var xPathString = "//*[@LocalizedControlType='Dokument']";
            try
            {
                // ControlType	Document(50030)
                wait.Until(ExpectedConditions.ElementExists(By.XPath(xPathString)));
                element = session.FindElementByXPath(xPathString);
                Assert.IsNotNull(element);
                Console.WriteLine(DateTime.Now.ToString());
                Console.WriteLine($" Element with XPath {xPathString} found.");
            }
            catch (Exception)
            {
                Assert.Fail($"Element with XPath {xPathString} could not be found.");
            }

        }
        [TestMethod]
        public void UsePasswordGenerator()
        {
            //keepass_basics.Session.SwitchTo();
            var element = session.FindElementByAccessibilityId("m_menuMain");
            Assert.IsNotNull(element);
            element = session.FindElementByName("Tools");
            Assert.IsNotNull(element);
            element.Click();
            element = session.FindElementByName("Generate Password...");
            Assert.IsNotNull(element);
            element.Click();
            // wait for 1 seconds
            Task.Delay(1000).Wait();
            element = session.FindElementByName("Password Generator");
            Assert.IsNotNull(element);

            //AutomationId	m_cbUpperCase
            element = session.FindElementByAccessibilityId("m_cbUpperCase");
            Assert.IsNotNull(element);
            //element.Click();
            Assert.IsTrue(element.Selected, "Expected UpperCase to be selected but it was not");
            element = session.FindElementByAccessibilityId("m_btnOK");
            Assert.IsNotNull(element);
            element.Click();
            Task.Delay(1000).Wait();
            // AutomationId	ListViewItem-2
            element = session.FindElementByAccessibilityId("ListViewItem-2");
            Assert.IsNotNull(element);
            element.Click();
            element = session.FindElementByName("Entry");
            Assert.IsNotNull(element);
            element.Click();
            element = session.FindElementByName("Delete Entry");
            Assert.IsNotNull(element);
            element.Click();
            element = session.FindElementByAccessibilityId("CommandButton_1");
            Assert.IsNotNull(element);
            element.Click();
            
        }



        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            keepass_basics = new Keepass_basics();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            keepass_basics.Dispose();
        }
    }
}
