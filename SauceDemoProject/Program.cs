using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace SauceDemoProject
{
    public class Program
    {
        static void Main(string[] args)
        {

            #region Web Driver
            IWebDriver driver = new ChromeDriver("C:\\Users\\AhmadRA\\source\\repos\\SauceDemoProject\\SauceDemoProject\\drivers");
            Configurations conf = new Configurations();
            #endregion

            #region Ui Test
            var testSet = new TestSets.E2EUiTest(driver);
            testSet.Execute();
            #endregion
        }
    }
}
