using AventStack.ExtentReports;
using OpenQA.Selenium;


namespace SauceDemoProject.Tests
{
    public class LoginWithValidCredentialsTest : IAutomationExecute
    {
        Macros.LoginPage loginPage;
        IWebDriver _driver;

        private const string username = "standard_user";
        private const string pwd = "secret_sauce";

        public LoginWithValidCredentialsTest(IWebDriver driver) {
            _driver = driver;
            loginPage = new Macros.LoginPage(_driver);
        }
        public void  Execute() {
            Configurations._test.Log(Status.Info, "Starting test: CheckTotalPriceForProductsInCart");
            loginPage.Login(username, pwd);
        }
        public void Teardown()
        {

        }
    }
}
