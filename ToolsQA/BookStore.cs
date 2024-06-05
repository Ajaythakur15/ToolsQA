using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA
{
    public class BookStore
    {
        private IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/books");
            driver.Manage().Window.Maximize();
            scrollDown(200);
        }
        [Test]
        public void SearchBox()
        {
            searchValue("Pro");
            Assert.AreEqual("Pro", searhvaluematch(), "Values are not same");
            ClickOnBook();
              
        }
        [Test]
        public void LoginBtnClick()
        {
            Assert.IsTrue(IsClickBtn(), "Button is displayed");
            ClickBtn();
        }
        public void scrollDown(int yoffset)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0,{yoffset});");
        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
        private By FillSearchBox => By.XPath("//input[@id='searchBox']");
        private By FillBook => By.XPath("//a[contains(text(),'Programming JavaScript Applications')]");
        private By LoginBtn => By.XPath("//button[contains(text(),'Login')]");

        public void searchValue(string text)
        {
            SendKeys(FillSearchBox, text);
        }
        public string searhvaluematch()
        {
            IWebElement element = driver.FindElement(FillSearchBox);
            string searchText = element.GetAttribute("value");
            return searchText;
        }
        public void ClickBtn()
        {
            ClickElement(LoginBtn);
        }
        public void ClickOnBook()
        {
            ClickElement(FillBook);
        }
        public bool IsClickBtn()
        {
            return driver.FindElement(LoginBtn).Displayed;
        }
        public void SendKeys(By by , string text , int timeOutInSeconds = 40)
        {
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(timeOutInSeconds));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            element.SendKeys(text);
            element.SendKeys(Keys.Enter);
        }
        public void ClickElement(By by , int timeOutInSeconds = 40)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            element.Click();
        }



    }
    
}
