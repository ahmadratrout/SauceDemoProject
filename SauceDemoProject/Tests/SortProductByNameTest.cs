using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SauceDemoProject.Macros;

namespace SauceDemoProject.Tests
{
    public class SortProductByNameTest : IAutomationExecute
    {
        private Macros.ProductPage productPage;
        private List<string> DescProductsName;
        private List<string> AsecProductsName;
        public SortProductByNameTest(IWebDriver driver) {
            productPage = new Macros.ProductPage(driver);
        }
        #region Main Function
        public void Execute() {
            AsecProductsName = productPage.GetProductNames();
            productPage.SortByNameDescending();
            DescProductsName = productPage.GetProductNames();
            VerifySortedLists();
        }
        #endregion

        public void Teardown() { 
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
        #endregion
    }
}
