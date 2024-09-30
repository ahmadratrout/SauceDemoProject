using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenWeatherMap;
using SauceDemoProject.Tests;

namespace SauceDemoProject.TestSets
{
    public class E2EUiTest : IAutomationTestSet
    {
        //public static IWebDriver _driver ;
        public static IWebDriver _driver = new ChromeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "drivers"));
        public E2EUiTest() 
        { 
        }

        public static IAutomationExecute[] iAutomationExecutes = new IAutomationExecute[]
        {
              new LoginWithValidCredentialsTest(),
              new AddProductToCartTest(),
              new CheckTotalPriceWhenBuyItemsTest(),
              new RemoveProductFromCartTest(),
              new SortProductByNameTest()

        };

        public void Execute()
        {
            foreach (var test in iAutomationExecutes)
            {
                test.Execute();
            }
            //Configurations.FlushReport(); // Generate the report
            _driver.Quit();
            _driver.Dispose();

        }
    }
}
