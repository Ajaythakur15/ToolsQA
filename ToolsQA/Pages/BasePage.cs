using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace ToolsQA.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver _driver;

        protected BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        protected void WaitUntilElementVisible(By by, int timeoutInSeconds = 60)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        protected IWebElement GetElement(By by, int timeoutInSeconds = 60)
        {
            WaitUntilElementVisible(by, timeoutInSeconds);
            return _driver.FindElement(by);
        }

        protected void Click(By by, int timeoutInSeconds = 60)
        {
            WaitUntilElementVisible(by, timeoutInSeconds);
            _driver.FindElement(by).Click();
        }

        protected void SendKeys(By by, string text, int timeoutInSeconds = 60)
        {
            WaitUntilElementVisible(by, timeoutInSeconds);
            var element = _driver.FindElement(by);
            element.Clear();
            element.SendKeys(text);
        }

        protected void SelectDropdown(By by, string value, int timeoutInSeconds = 60)
        {
            WaitUntilElementVisible(by, timeoutInSeconds);
            var dropdown = new SelectElement(_driver.FindElement(by));
            dropdown.SelectByText(value);
        }

        protected void SelectRadioButton(By by, int timeoutInSeconds = 60)
        {
            WaitUntilElementVisible(by, timeoutInSeconds);
            _driver.FindElement(by).Click();
        }

        public void ScrollDown(int yOffset)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript($"window.scrollBy(0, {yOffset});");
        }
        private void HandleUnexpectedAlert(Action testAction)
        {
            try
            {
                testAction.Invoke();
            }
            catch (UnhandledAlertException alertException)
            {
                try
                {
                    IAlert alert = _driver.SwitchTo().Alert();
                    alert.Accept(); // or alert.Dismiss();
                    Console.WriteLine($"Alert handled: {alertException.Message}");
                }
                catch (NoAlertPresentException)
                {
                    // Handle the case where no alert is present
                    Console.WriteLine("No alert present.");
                }
            }
        }
    }
}