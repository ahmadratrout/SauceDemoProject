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
    public class CheckTotalPriceWhenBuyItemsTest : IAutomationExecute
    {
        private const double expectedPrice = 29.99;
        private CheckoutPage checkoutPage;
        private IWebDriver _driver;
        private LoginPage loginPage;
        private ProductPage productPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "drivers"));
            checkoutPage = new CheckoutPage(_driver);
            InitForCheckTotalPrice();

        }
        public CheckTotalPriceWhenBuyItemsTest() {
            
        }
        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
        #region Main Function
        [Test, Order(3)]
        public void Execute() {
            checkoutPage.GoToCart();
            checkoutPage.BuyItems("wrg", "rg", "erf");
            double  totalPrice = (checkoutPage.GetTotalPrice());
            VerifyTotalPriceAsExpected(totalPrice);

        }
        #endregion
        #region Fucntions
        private void VerifyTotalPriceAsExpected(double totalPrice) {
            //Assert.LessOrEqual(Math.Abs(totalPrice - expectedPrice), 0, $"The decimals {totalPrice} and {expectedPrice} are not equal within the tolerance.");
            if (totalPrice - expectedPrice != 0) {
                throw new Exception("");
            }
        }
        private void InitForCheckTotalPrice() {
            loginPage = new Macros.LoginPage(_driver);
            productPage = new ProductPage(_driver);
            loginPage.Login("standard_user", "secret_sauce");
            productPage.GoToProductPage();
            productPage.AddProductToCart("Sauce Labs Backpack");

        }
        #endregion
    }
}
