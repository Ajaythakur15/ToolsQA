using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace ToolQAPOC
{
    [TestFixture]
    public class DemoQATextBoxTestCases
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/");
            ScrollPage(600);
        }

        [Test]
        public void TestElementVisibility()
        {
            ClickElementsTab();

            // Check if Text Box is visible
            Assert.IsTrue(WaitForElementDisplayed(By.Id("item-0")), "Text Box is not visible.");

            // Check if Check Box is visible
            Assert.IsTrue(WaitForElementDisplayed(By.Id("item-1")), "Check Box is not visible.");
        }

        [Test]
        public void TestTextBoxInput()
        {
            ClickElementsTab();
            ClickSubTextElementsTab();

            // Enter text into Text Box
            EnterTextIntoTextBox("userName", "Ajay");
            EnterTextIntoTextBox("userEmail", "ajay@yopmail.com");
            EnterTextIntoTextBox("currentAddress", "558, Phase-3");
            EnterTextIntoTextBox("permanentAddress", "Bartouli");
            ScrollPage(300);

            // Click submit button
            IWebElement submitButton = WaitForElementClickable(By.XPath("//button[@id='submit']"));
            submitButton.Click();

            // Verify the entered text
            Assert.AreEqual("Ajay", GetTextBoxValue("userName"), "User name input does not match.");
            Assert.AreEqual("ajay@yopmail.com", GetTextBoxValue("userEmail"), "Email input does not match.");
            Assert.AreEqual("558, Phase-3", GetTextBoxValue("currentAddress"), "Current address input does not match.");
            Assert.AreEqual("Bartouli", GetTextBoxValue("permanentAddress"), "Permanent address input does not match.");
        }

        [Test]
        public void TestCheckBoxSelection()
        {
            ClickElementsTab();

            // Select the Check Box
            IWebElement checkBox = driver.FindElement(By.Id("item-1"));
            checkBox.Click();

            // Verify if the Check Box is selected
            Assert.IsFalse(checkBox.Selected, "Check Box is not selected.");
        }

        private void ClickElementsTab()
        {
            ClickElement(By.XPath("//h5[contains(text(),'Elements')]"));
        }

        private void ClickSubTextElementsTab()
        {
            ClickElement(By.XPath("//span[contains(text(),'Text Box')]"));
        }

        //private void ClickSubCheckElementsTab()
        //{
        //    ClickElement(By.XPath("//span[contains(text(),'Check Box')]"));
        //}
        private void ClickElement(By locator)
        {
            driver.FindElement(locator).Click();
        }

        private void EnterTextIntoTextBox(string id, string text)
        {
            IWebElement textBox = driver.FindElement(By.Id(id));
            textBox.Clear();
            textBox.SendKeys(text);
        }

        private string GetTextBoxValue(string id)
        {
            return driver.FindElement(By.Id(id)).GetAttribute("value");
        }

        private IWebElement WaitForElementClickable(By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        private bool WaitForElementDisplayed(By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            try
            {
                return wait.Until(driver => driver.FindElement(locator).Displayed);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private void ScrollPage(int yOffset)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0, {yOffset});");
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
