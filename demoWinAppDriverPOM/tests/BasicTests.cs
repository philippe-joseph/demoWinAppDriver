using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demoWinAppDriverPOM.utils;
using demoWinAppDriverPOM.pages;

namespace demoWinAppDriverPOM.tests
{
    [TestClass]
    public class BasicTests : KeePassBase
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Open KeePass
            var openDB = new OpenDatabase(Driver);
            MainWindow mainWindow;
            if (openDB.OpenDBWindowPresent())
            {
                mainWindow = openDB.EnterPassword();
            } else
            {
                mainWindow = new MainWindow(Driver);
            }
            mainWindow.CheckMenuMainAccessibilityId();
        }
    }
}
