using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoProject.Macros
{

    public class CheckoutPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        //Locators
        private readonly By cartBtn = By.ClassName("shopping_cart_link");
        private readonly By checkoutBtn = By.Name("checkout");
        private readonly By FNameTextField = By.Name("firstName");
        private readonly By LNameTextField = By.Name("lastName"); 
        private readonly By postalCodeTextField = By.Name("postalCode");
        private readonly By totalPrice = By.XPath("//div[@class='summary_subtotal_label']");
        private readonly By continueBtn = By.Name("continue");

        public CheckoutPage(IWebDriver driver) {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        public void BuyItems(string fName, string lName, string postalCode) {
            new Common.UserAction().ClickElement(checkoutBtn, _driver);
            new Common.UserAction().EnterText(FNameTextField, fName, _driver);
            new Common.UserAction().EnterText(LNameTextField, lName, _driver);
            new Common.UserAction().EnterText(postalCodeTextField, postalCode, _driver);
            new Common.UserAction().ClickElement(continueBtn, _driver);
        }

        public double GetTotalPrice() {
            string price = _driver.FindElement(totalPrice).Text;
            Console.WriteLine(price);
            double totalPriceNumber = double.Parse(price.Replace("Item total: $", "").Trim());
            return totalPriceNumber;
        }

        public void GoToCart()
        {
            new Common.UserAction().ClickElement(cartBtn, _driver);
        }
    }
}
