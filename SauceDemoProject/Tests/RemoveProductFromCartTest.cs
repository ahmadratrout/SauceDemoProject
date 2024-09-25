using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SauceDemoProject.Tests
{
    public class RemoveProductFromCartTest : IAutomationExecute
    {
        private Macros.ProductPage productPage;

        public RemoveProductFromCartTest(IWebDriver driver)
        {
            productPage = new Macros.ProductPage(driver);
        }
        #region Main Function
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
        public void Teardown() { }
    }
}
