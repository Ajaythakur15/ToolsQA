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
   public class Tabs
    {
        private IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/tabs");
            driver.Manage().Window.Maximize();
            ScrollDown(300);
        }
        [Test]
        public void Origin()
        {
            ClickOrigin();
        }
        [Test]
        public void Use()
        {
            ClickUse();
        }
        [Test]
        public void What()
        {
            ClickWhat();
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
        private By OriginId => By.Id("demo-tab-origin");
        private By UseId => By.Id("demo-tab-use");
        private By WhatId => By.Id("demo-tab-what");

        public void ClickOrigin()
        {
            ClickElement(OriginId);
        }
        public void ClickUse()
        {
            ClickElement(UseId);
        }
        public void ClickWhat()
        {
            ClickElement(WhatId);
        }

        public void ClickElement(By by, int TimeOutInSeconds = 60)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeOutInSeconds));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            element.Click();
        }
    }
}
