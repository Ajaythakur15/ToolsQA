using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA
{
    public class Form
    {
        private IWebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            driver.Manage().Window.Maximize();
            ScrollDown(300);
        }
        [Test]
        public void FillTextBoxValue()
        {
            TestCasesForm obj = new TestCasesForm(driver);
            obj.FillFirstName("Prachi");
            obj.FillLastName("Sharma");
            obj.FillEmail("prachi@gmail.com");
            obj.FillMobileNumber("8283283621");
            obj.FillDOB("04/05/2001");
           // obj.FillSubjects("Commerce");
           // obj.FillPicture("E:\\Automation_Testing");
            obj.FillCurrAdd("Pilkhuwa");





        }
        public void ScrollDown(int yOffset)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0,{yOffset});");
        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
    public class TestCasesForm
    {
        private IWebDriver _driver;

        public TestCasesForm(IWebDriver driver)
        {
            this._driver = driver;
        }
        public void waitForElementVisible(By by , int timeOutInSeconds = 60)
        {
            var wait = new WebDriverWait(_driver,TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
        public void SendKeys(By by , string text , int timeOutInSeconds = 60)
        {
            waitForElementVisible(by, timeOutInSeconds);
            var element = _driver.FindElement(by);
            element.Clear();
            element.SendKeys(text);
        }

        public void FillFirstName(string firstname)
        {
            SendKeys(FirstnameText,firstname);
        }
        public void FillLastName(string lastname)
        {
            SendKeys(LastNameInput, lastname);
        }
        public void FillEmail(string email)
        {
            SendKeys(EmailInput, email);
        }
        public void FillMobileNumber(string number)
        {
            SendKeys(MobileInput, number);
        }
        public void FillDOB(string dob)
        {
            ScrollDownn(400);
            var dateInput = _driver.FindElement(By.Id("dateOfBirthInput"));
            dateInput.Click();
            dateInput.SendKeys(dob);
            dateInput.SendKeys(Keys.Enter);
        }
        public void FillSubjects(string subjects)
        {
            SendKeys(SubjectsInput, subjects);
        }
        public void FillPicture(string path)
        {
            IWebElement element = _driver.FindElement(By.XPath("//input[@id='uploadPicture']"));
            element.Click();
            SendKeys(PictureInput, path);
        }
        public void FillCurrAdd(string address)
        {
            SendKeys(AddressInput, address);
        }

        private By FirstnameText => By.Id("firstName");
        private By LastNameInput => By.Id("lastName");
        private By EmailInput => By.Id("userEmail");
        private By MobileInput => By.Id("userNumber");
       // private By DOBInput => By.Id("dateOfBirthInput");
        private By SubjectsInput => By.Id("'subjectsInput");
        private By PictureInput => By.Id("uploadPicture");
        private By AddressInput => By.Id("currentAddress");





        public void ScrollDownn(int yOffset)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript($"window.scrollBy(0,{yOffset});");
        }
    }
}
