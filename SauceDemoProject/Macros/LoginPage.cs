using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoProject.Macros
{
    public class LoginPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        // Locators
        private readonly By _usernameTextField = By.Name("user-name");
        private readonly By _passwordTextField = By.Name("password");
        private readonly By _loginBtn = By.Id("login-button");

        private const string URL = "https://www.saucedemo.com/";

        public LoginPage(IWebDriver driver) {
            _driver = driver;
  
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void Login(string username, string password) {
            _driver.Navigate().GoToUrl(URL);
            new Common.UserAction().EnterText(_usernameTextField, username, _driver);
            new Common.UserAction().EnterText(_passwordTextField, password, _driver);
            new Common.UserAction().ClickElement(_loginBtn, _driver);
            new Common.UserAction().VerifyCurrentUrl(ProductPage.URL, _driver);
        }
    }
}
