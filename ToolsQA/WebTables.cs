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

        //[Test]
        //public void ClickAddButton()
        //{
        //    ClickElement(By.XPath("//button[@id='addNewRecordButton']"));
        //    Assert.IsTrue(IsElementDisplayed(By.XPath("//button[contains(text(),'Add')]")), "Add button should be clicked");
        //}

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
            SubmitButtonDisplayed();
            //ClickOnClickButton();
            Assert.IsTrue(SubmitButtonDisplayed(), "Submit button should be hidden after submit");

            Assert.AreEqual("Prachi", GetTextBoxValue("firstName"), "Firstname value does not match");
            Assert.AreEqual("Sharma", GetTextBoxValue("lastName"), "Lastname value does not match");
            Assert.AreEqual("prachi@gmail.com", GetTextBoxValue("userEmail"), "UserEmail value does not match");
            Assert.AreEqual("22", GetTextBoxValue("age"), "Age value does not match");
            Assert.AreEqual("2200", GetTextBoxValue("salary"), "Salary value does not match");
            Assert.AreEqual("MCA", GetTextBoxValue("department"), "Department value does not match");
        }
        [Test]
        public void TestAddButtonSubmit()
        {
            ClickAddButton();
            EnterValuesIntoTextbox("firstName", "Prachi");
            // Add explicit wait before interacting with the firstName element
            WaitForElement(By.CssSelector("#firstName"));
            EnterValuesIntoTextbox("lastName", "Sharma");
            EnterValuesIntoTextbox("userEmail", "prachi@gmail.com");
            EnterValuesIntoTextbox("age", "22");
            EnterValuesIntoTextbox("salary", "2200");
            EnterValuesIntoTextbox("department", "MCA");
            ClickOnSubmitButton();
            //Assert.IsTrue(SubmitButtonDisplayed(), "Submit button should be hidden after submit");

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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            element.Click();
        }

        public void ClickOnSubmitButton()
        {
            ClickElement(By.XPath("//button[@id='submit']"));
        }
        public void ClickAddButton()
        {
            ClickElement(By.XPath("//button[@id='addNewRecordButton']"));
        }

        public void EnterValuesIntoTextbox(string name, string text)
        {
            IWebElement element = WaitUntilElementIsVisible(By.Id(name));
            element.Clear();
            element.SendKeys(text);
        }

        private string GetTextBoxValue(string name)
        {
            IWebElement element = WaitUntilElementIsVisible(By.Id(name));
            return element.GetAttribute("value");
        }

        public bool SubmitButtonDisplayed()
        {
            try
            {
                return driver.FindElement(By.CssSelector("#submit")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private IWebElement WaitForElementClickable(By locator, int timeoutInSeconds = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
        private void WaitForElement(By locator, int timeoutInSeconds = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementExists(locator));
        }
        private IWebElement WaitUntilElementIsVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        private bool IsElementDisplayed(By locator)
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

        private void ScrollPage(int yOffset)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0, {yOffset});");
        }
    }
}
