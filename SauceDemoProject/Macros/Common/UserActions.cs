using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SauceDemoProject.Macros.Common
{
    public class UserAction
    {
        //Locators
        

        private WebDriverWait _webDriverWait;
        /// <summary>
        /// This method is to click on any elemnt
        /// </summary>
        /// <param name="locator">web locator for the element to be clicked</param>
        /// <param name="driver"> driver that test run on it </param>
        public void ClickElement(By locator, IWebDriver driver) {
            _webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            _webDriverWait.Until(ExpectedConditions.ElementIsVisible(locator)).Click();
        }
        /// <summary>
        /// This method is to enter text to an textfield
        /// </summary>
        /// <param name="locator">web locator for the element to fill with text</param>
        /// <param name="text">text to be filled in the textfield</param>
        /// <param name="driver">driver that test run on it</param>
        public void EnterText(By locator, string text, IWebDriver driver)
        {
            _webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            _webDriverWait.Until(ExpectedConditions.ElementIsVisible(locator)).Clear();
            driver.FindElement(locator).SendKeys(text);
        }

        public void VerifyCurrentUrl(string expectedUrl, IWebDriver driver) {
            NUnit.Framework.Legacy.StringAssert.AreEqualIgnoringCase(expectedUrl, driver.Url);
        }

    }
}
