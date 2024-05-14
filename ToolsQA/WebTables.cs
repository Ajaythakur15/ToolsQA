using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace ToolQAPOC
{
    [TestFixture]
    public class WebTablesButtonTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/webtables");
            ScrollPage(500);
        }

        [Test]
        public void ClickAddButton()
        {
            ClickElement(By.XPath("//button[contains(text(),'Add')]"));
            Assert.IsTrue(IsElementDisplayed(By.XPath("//button[contains(text(),'Add')]")), "Add button should be clicked");
        }

        [Test]
        public void TestTextBoxValues()
        {
            ClickAddButton();
            EnterValuesIntoTextbox("firstName", "Prachi");
            EnterValuesIntoTextbox("lastName", "Sharma");
            EnterValuesIntoTextbox("userEmail", "prachi@gmail.com");
            EnterValuesIntoTextbox("age", "22");
            EnterValuesIntoTextbox("salary", "2200");
            EnterValuesIntoTextbox("department", "MCA");
            ClickElement(By.CssSelector("#submit"));
            Assert.IsTrue(SubmitButtonDisplayed(), "Submit button is not displayed");

            Assert.AreEqual("Prachi", GetTextBoxValue("firstName"), "Firstname value does not match");
            Assert.AreEqual("Sharma", GetTextBoxValue("lastName"), "Lastname value does not match");
            Assert.AreEqual("prachi@gmail.com", GetTextBoxValue("userEmail"), "UserEmail value does not match");
            Assert.AreEqual("22", GetTextBoxValue("age"), "Age value does not match");
            Assert.AreEqual("2200", GetTextBoxValue("salary"), "Salary value does not match");
            Assert.AreEqual("MCA", GetTextBoxValue("department"), "Department value does not match");
        }

        [Test]
        public void SearchBox()
        {
            EnterValuesIntoTextbox("searchBox", "Al");
            ClickElement(By.XPath("//span[@id='basic-addon2']"));
            Assert.IsTrue(IsElementDisplayed(By.XPath("//span[@id='basic-addon2']")), "Search is not happening");
        }

        [Test]
        public void DeleteButton()
        {
            ClickElement(By.XPath("//span[@id='delete-record-2']"));
            Assert.IsTrue(IsElementDisplayed(By.XPath("//span[@id='delete-record-1']")), "Button should delete");
        }

        [Test]
        public void EditButton()
        {
            ClickElement(By.XPath("//span[@id='edit-record-1']"));
            Assert.IsTrue(IsElementDisplayed(By.XPath("//span[@id='edit-record-1']")), "Button should edit the records");

            EnterValuesIntoTextbox("age", "44");
            EnterValuesIntoTextbox("department", "BCA");
            ClickElement(By.XPath("//button[@type='submit']"));
            Assert.IsTrue(SubmitButtonDisplayed(), "Submit is not done");

            Assert.AreEqual("44", GetTextBoxValue("age"), "Age value does not match");
            Assert.AreEqual("BCA", GetTextBoxValue("department"), "Department value does not match");
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }

        public void ClickElement(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
        }

        public bool IsElementDisplayed(By locator)
        {
            try
            {
                return driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void EnterValuesIntoTextbox(string id, string text)
        {
            IWebElement element = driver.FindElement(By.Id(id));
            element.Clear();
            element.SendKeys(text);
        }

        private string GetTextBoxValue(string id)
        {
            return driver.FindElement(By.Id(id)).GetAttribute("value");
        }

        public bool SubmitButtonDisplayed()
        {
            return driver.FindElement(By.XPath("//button[@id='submit']")).Displayed;
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
    }
}