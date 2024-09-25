using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SauceDemoProject.Macros;

namespace SauceDemoProject.Tests
{
    public class CheckTotalPriceWhenBuyItemsTest : IAutomationExecute
    {
        private const double expectedPrice = 29.99;
        private CheckoutPage checkoutPage;
        public CheckTotalPriceWhenBuyItemsTest(IWebDriver driver) {
            checkoutPage = new CheckoutPage(driver);
        }
        public void Teardown() {
        }
        #region Main Function
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
        #endregion
    }
}
