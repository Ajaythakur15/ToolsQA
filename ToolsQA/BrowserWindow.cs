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
    [TestFixture]
    public class BrowserWindow
    {
        private IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/alertsWindows");
            driver.Manage().Window.Maximize();
            ScrollDown(500);
        }
        [Test]
        public void ClicKOnBrowserWindow()
        {
            BrowserTestCases testcase = new BrowserTestCases(driver);
            testcase.ClickBrowser();
        }
        [Test]
        public void ClickOnNewTab()
        {
            BrowserTestCases testcase = new BrowserTestCases(driver);
            testcase.ClickBrowser();
            ScrollDown(200);
            testcase.ClickNewTab();
            Assert.IsTrue(testcase.IsNewTabVisible(), "New tab is visible");
        }
        [Test]
        public void ClickOnNewWin()
        {
            BrowserTestCases testcase = new BrowserTestCases(driver);
            testcase.ClickBrowser();
            ScrollDown(200);
            testcase.ClickNewWin();
            Assert.IsTrue(testcase.IsNewWinVisible(), "New tab is visible");
        }
        [Test]
        public void ClickOnNewWinMessage()
        {
            BrowserTestCases testcase = new BrowserTestCases(driver);
            testcase.ClickBrowser();
            ScrollDown(300);
            testcase.ClickNewWinMessage();
            Assert.IsTrue(testcase.IsNewWinMessageVisible(), "New tab is visible");
        }


        public void ScrollDown(int yOffset)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0,{yOffset});");
        }

        [TearDown]
        public void CloseWindow()
        {
            driver.Quit();
        }
    }

    public class BrowserTestCases
    {
        private IWebDriver driver;
        public BrowserTestCases(IWebDriver driver)
        {
             this.driver = driver;
        }

        private void ClickElement(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            element.Click();
        }
            public void ClickBrowser()
        {
            ClickElement(By.XPath("//span[contains(text(),'Browser Windows')]"));
        }
        public void ClickNewTab()
        {
             driver.FindElement(By.XPath("//button[@id='tabButton']")).Click();
        }
        public bool IsNewTabVisible()
        {
         return driver.FindElement(By.XPath("//button[@id='tabButton']")).Displayed;
        }
        public void ClickNewWin()
        {
            driver.FindElement(By.XPath("//button[@id='windowButton']")).Click();

        }
        public bool IsNewWinVisible()
        {
            return driver.FindElement(By.XPath("//button[@id='windowButton']")).Displayed;
        }
        public void ClickNewWinMessage()
        {
            driver.FindElement(By.XPath("//button[@id='messageWindowButton']")).Click();

        }
        public bool IsNewWinMessageVisible()
        { 
            return driver.FindElement(By.XPath("//button[@id='messageWindowButton']")).Displayed;
        }

    }
}
