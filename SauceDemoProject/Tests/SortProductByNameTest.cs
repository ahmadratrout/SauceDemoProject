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
    public class SortProductByNameTest : IAutomationExecute
    {
        IWebDriver _driver;
        private Macros.ProductPage productPage;
        private LoginPage loginPage;
        private List<string> DescProductsName;
        private List<string> AsecProductsName;


        public SortProductByNameTest() {
        }
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "drivers"));
            productPage = new Macros.ProductPage(_driver);
            InitAndTestPreprationForAddProduct();
        }
        #region Main Function
        [Test, Order(5)]
        public void Execute() {
            AsecProductsName = productPage.GetProductNames();
            productPage.SortByNameDescending();
            DescProductsName = productPage.GetProductNames();
            VerifySortedLists();
        }
        #endregion

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
        #region Functions
        public void VerifySortedLists() {
            if (DescProductsName.SequenceEqual(AsecProductsName.OrderByDescending(name => name).ToList())) // It checks that both lists have the same length and that the elements are in the same order.
            {
                Console.WriteLine("Sorting functionality is working as expected");
            }
            else
            {
                Assert.Fail("Asc and Desc functionaity are not working as expected");
            }
        }
        private void InitAndTestPreprationForAddProduct()
        {
            loginPage = new Macros.LoginPage(_driver);

            // Run the login test before this test
            loginPage.Login("standard_user", "secret_sauce");
        }
        #endregion
    }
}
