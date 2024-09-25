using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SauceDemoProject.Macros
{
    public class ProductPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        public static string URL = "https://www.saucedemo.com/inventory.html";

        //Locators
        private readonly By cartBtn = By.ClassName("shopping_cart_link");
        private string productBaseXpath = "//div[@class='inventory_item'][.//div[@class='inventory_item_name' and text()='{0}']]";
        private string addToCartButtonBaseXpath = "//div[@class='inventory_item'][.//div[@class='inventory_item_name' and text()='{0}']]//button[contains(text(), 'Add to cart')]";
        private string addToCartButton = "//button[@id='add-to-cart-{0}']";
        private string removeFromCartBtn = "remove-{0}";
        private readonly By productNamesLocator = By.ClassName("inventory_item_name");
        private By sortDropdownLocator = By.ClassName("product_sort_container");
        private readonly By cartIconNumber = By.XPath("//span[@class='shopping_cart_badge']");

        public ProductPage(IWebDriver driver) { 
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        public void VerifyCurrentPageIsProductPage() {
            NUnit.Framework.Legacy.StringAssert.Equals(URL, _driver.Url); // or -> wait.Until(ExpectedConditions.UrlContains("inventory.html"));
            _wait.Until(ExpectedConditions.ElementIsVisible(cartBtn));
        }

        public void GoToProductPage()
        { 
        _driver.Navigate().GoToUrl(URL);
        }

        // Method to add product to cart based on the product name
        public void AddProductToCart(string productName)
        {
            string productNameForXpath = productName.ToLower().Replace(" ", "-");
            By addToCartButtonLocator = By.XPath(String.Format(addToCartButton, productNameForXpath));
            _wait.Until(ExpectedConditions.ElementToBeClickable(addToCartButtonLocator)).Click();
        }

        public void RemoveProductFromCart(string productName) {
            string productNameForXpath = productName.ToLower().Replace(" ", "-");
            By removeFromCartButtonLocator = By.Name(String.Format(removeFromCartBtn, productNameForXpath));
            Console.WriteLine(removeFromCartButtonLocator);
            _wait.Until(ExpectedConditions.ElementToBeClickable(removeFromCartButtonLocator)).Click();
        }



        // Method to get all product names and return a sorted list
        public List<string> GetProductNames()
        {
            // Find all product name elements
            var productElements = _driver.FindElements(productNamesLocator);

            // Extract the text of each product and store it in a list
            List<string> productNames = productElements.Select(element => element.Text).ToList();

            //// Sort the product names alphabetically
            //productNames.Sort();

            return productNames;
        }
        public void SortByNameDescending()
        {
            // Locate the dropdown element
            IWebElement sortDropdown = _driver.FindElement(sortDropdownLocator);

            // Create a SelectElement object to interact with the dropdown
            SelectElement selectElement = new SelectElement(sortDropdown);

            // Select the option "Name (Z to A)" by visible text
            selectElement.SelectByText("Name (Z to A)");

            // Wait for the page to update after selecting the sort option
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        public void VerifyProductNumberInCartOnCartIcon(int numberOfProductInCart)
        {
            string numberOnCartIcon = _driver.FindElement(cartIconNumber).Text.Trim();
            if (int.Parse(numberOnCartIcon.Trim()) == (numberOfProductInCart))
            {
                Console.WriteLine("Number of Item at cart icon as expcted");
            }
            else
            {
                Assert.Fail($"Expected cart icon to have {numberOfProductInCart} but found {numberOnCartIcon}");
            }
        }

    }
}
