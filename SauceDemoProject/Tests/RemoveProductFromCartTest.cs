using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemoProject.Macros;

namespace SauceDemoProject.Tests
{
    [TestFixture]
    public class RemoveProductFromCartTest : IAutomationExecute
    {
        private Macros.ProductPage productPage;
        private IWebDriver _driver;
        LoginPage loginPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "drivers"));
            productPage = new Macros.ProductPage(_driver);
            InitForCheckTotalPriceRemoveItemFromCart();
        }
        public RemoveProductFromCartTest()
        {
        }
        #region Main Function
        [Test, Order(4)]
        public void Execute()
        {
            productPage.GoToProductPage();
            productPage.RemoveProductFromCart("Sauce Labs Backpack");
            try {
                productPage.VerifyProductNumberInCartOnCartIcon(0);
            } catch (Exception exc) {
                if (!exc.Message.Contains("no such element: Unable to locate element")) {
                    Assert.Fail($"It should fail on no elemnt to read since cart is empty and it shouldn't have a number while error was {exc.Message}");
                }
            }
            
        }
        #endregion
        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        private void InitForCheckTotalPriceRemoveItemFromCart()
        {
            loginPage = new Macros.LoginPage(_driver);
            loginPage.Login("standard_user", "secret_sauce");
            productPage.GoToProductPage();
            productPage.AddProductToCart("Sauce Labs Backpack");
        }
        
    }
}
