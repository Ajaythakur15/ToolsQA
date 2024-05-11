using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.Pages
{
    public class BasePage
    {
        private readonly IWebDriver _driver;

        protected BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        protected void WaitUntilElementVisible(By by)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        protected IWebElement GetElement(By by)
        {
            WaitUntilElementVisible(by);
            return _driver.FindElement(by);
        }

        protected void Click(By by)
        {
            WaitUntilElementVisible(by);
            _driver.FindElement(by).Click();
        }

        protected void SendKeys(By by, string text)
        {
            WaitUntilElementVisible(by);
            _driver.FindElement(by).SendKeys(text);
        }

        protected void SelectDropdown(By by, string value)
        {
            WaitUntilElementVisible(by);
            var dropdown = new SelectElement(_driver.FindElement(by));
            dropdown.SelectByText(value);
        }

        protected void SelectRadioButton(By by)
        {
            WaitUntilElementVisible(by);
            _driver.FindElement(by).Click();
            // Add any additional logic if needed after clicking the radio button.
        }
    }
}
