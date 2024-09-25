using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SauceDemoProject.Tests
{
    public class AddProductToCartTest : IAutomationExecute
    {
        private Macros.ProductPage productPage;
        private IWebDriver _driver;
        public AddProductToCartTest(IWebDriver driver) {
            _driver = driver;
            productPage = new Macros.ProductPage(driver);
        }
        #region Main Function
        public void Execute() {
            productPage.GoToProductPage();
            productPage.AddProductToCart("Sauce Labs Backpack");
            productPage.VerifyProductNumberInCartOnCartIcon(1);
        }
        #endregion
        public void Teardown() {
        }
    }
}
