using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemoProject.Macros;


namespace SauceDemoProject.Tests
{
    [TestFixture]
    public class LoginWithValidCredentialsTest : IAutomationExecute
    {
        Macros.LoginPage loginPage;
        IWebDriver _driver;

        private const string username = "standard_user";
        private const string pwd = "secret_sauce";

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "drivers"));
            loginPage = new Macros.LoginPage(_driver);
        }

        public LoginWithValidCredentialsTest() {
        }
        [Test, Order(1)]
        public void  Execute() {
            loginPage.Login(username, pwd);
        }
        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
