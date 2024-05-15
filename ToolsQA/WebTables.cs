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
        public void CheckSubmitBtnDisplayed()
        {
            ClickAddButton();
            Assert.IsTrue(SubmitButtonDisplayed(),"Submit button is not Displayed");
        }

        [Test]
        public void TestTextBoxValues()
        {
            ClickAddButton();

            Dictionary<string, string> inputvalues = new Dictionary<string, string>
            {
                {"firstName" , "Prachi" },
                { "lastName", "Sharma"},
                {"userEmail", "prachi@gmail.com" },
                { "age", "22"},
                { "salary", "2200"},
                 { "department", "MCA" }
            };
            int repeatCount = 5;
            for(int i=0;i< repeatCount; i++)
            {

            
            foreach (var values in inputvalues)
            {
                EnterValuesIntoTextbox(values.Key, values.Value);
                Assert.AreEqual(values.Value, GetTextBoxValue(values.Key),$"{values.Key} does not match");
            }
            }
            /* EnterValuesIntoTextbox("firstName", "Prachi");
             EnterValuesIntoTextbox("lastName", "Sharma");
             EnterValuesIntoTextbox("userEmail", "prachi@gmail.com");
             EnterValuesIntoTextbox("age", "22");
             EnterValuesIntoTextbox("salary", "2200");
             EnterValuesIntoTextbox("department", "MCA");


             Assert.AreEqual("Prachi", GetTextBoxValue("firstName"), "Firstname value does not match");
             Assert.AreEqual("Sharma", GetTextBoxValue("lastName"), "Lastname value does not match");
             Assert.AreEqual("prachi@gmail.com", GetTextBoxValue("userEmail"), "UserEmail value does not match");
             Assert.AreEqual("22", GetTextBoxValue("age"), "Age value does not match");
             Assert.AreEqual("2200", GetTextBoxValue("salary"), "Salary value does not match");
             Assert.AreEqual("MCA", GetTextBoxValue("department"), "Department value does not match");
 */

            //Clicl on submit button
            ClickOnSubmitButton();
             Assert.IsFalse(SubmitButtonDisplayed(), "Submit button should be hidden after submit");

        }


        [Test]
        public void SearchBox()
        {
            EnterValuesIntoTextbox("searchBox", "Al");
           
            ClickElement(By.XPath("//span[@id='basic-addon2']"));
            
        }

        [Test]
        public void DeleteButton()
        {

            Assert.IsTrue(IsElementDisplayed(By.XPath("//span[@id='delete-record-1']")),"Delete button should be displayed");
            //ClickElement(By.XPath("//span[@id='delete-record-2']"));
        }

        [Test]
        public void EditButton()
        {
            ClickElement(By.XPath("//span[@id='edit-record-1']"));
            Assert.IsTrue(IsElementDisplayed(By.XPath("//span[@id='edit-record-1']")), "Button should edit the records");

            EnterValuesIntoTextbox("age", "44");
            EnterValuesIntoTextbox("department", "BCA");

            Assert.AreEqual("44", GetTextBoxValue("age"), "Age value does not match");
            Assert.AreEqual("BCA", GetTextBoxValue("department"), "Department value does not match");
        
           
            Assert.IsTrue(SubmitButtonDisplayed(), "Submit is not Displayed");
            ClickElement(By.XPath("//button[contains(text(), 'Submit')]"));


        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }

        public void ClickElement(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            element.Click();
        }

        public void ClickOnSubmitButton()
        {
            ClickElement(By.XPath("//button[contains(text(), 'Submit')]"));
        }
        public void ClickAddButton()
        {
            ClickElement(By.XPath("//button[@id='addNewRecordButton']"));
        }

        public void EnterValuesIntoTextbox(string Id, string text)
        {
            IWebElement element = driver.FindElement(By.Id(Id));
            element.Clear();
            element.SendKeys(text);
        }

        private string GetTextBoxValue(string Id)
        {
            /*IWebElement element = driver.FindElement(By.Id(Id));
            return element.GetAttribute("value");*/
            return driver.FindElement(By.Id(Id)).GetAttribute("value");
        }

        public bool SubmitButtonDisplayed()
        {
            try
            {
                return driver.FindElement(By.XPath("//button[@id='submit']")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

       
        private IWebElement WaitUntilElementIsVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
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
