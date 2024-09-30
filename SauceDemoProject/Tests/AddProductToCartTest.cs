using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceDemoProject.Tests
{
    [TestFixture]
    public class AddProductToCartTest : IAutomationExecute
    {
        private Macros.ProductPage productPage;
        private IWebDriver _driver;
        private Macros.LoginPage loginPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "drivers"));
            InitAndTestPreprationForAddProduct();
            productPage = new Macros.ProductPage(_driver);

        }


        public AddProductToCartTest() {
            
        }
        #region Main Function
        [Test, Order(2)]
        public void Execute() {
            productPage.GoToProductPage();
            productPage.AddProductToCart("Sauce Labs Backpack");
            productPage.VerifyProductNumberInCartOnCartIcon(1);
        }
        #endregion
        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
        private void InitAndTestPreprationForAddProduct() {
            loginPage = new Macros.LoginPage(_driver);

            // Run the login test before this test
            loginPage.Login("standard_user", "secret_sauce");
        }
    }
}
