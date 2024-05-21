using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ToolsQA
{
    [TestFixture]
    public class DynamicProperties
    {
        private IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/dynamic-properties");
            driver.Manage().Window.Maximize();
            ScrollDown(400);
        }
        [Test]
        public void CheckForVisibility()
        {
            Assert.IsTrue(CheckVisibility(), "This button is not visivle after 5 seconds");

            Assert.IsTrue(CheckVisibleAfter(), "Visible After button is not visibile");

            Assert.IsTrue(CheckColorChangeVisibility(), "Color change button is not visibile");
        }
        public void ScrollDown(int yOffset)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0, {yOffset});");
        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }

        /* public bool CheckVisibitily()
         {
             WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
             IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='enableAfter']")));
             return element.Displayed;
         }*/
        public bool CheckVisibility()
        {
            return driver.FindElement(By.XPath("//button[@id='enableAfter']")).Displayed;
        }
        public bool CheckVisibleAfter()
        {
            return driver.FindElement(By.XPath("//button[@id='visibleAfter']")).Displayed;
        }
        public bool CheckColorChangeVisibility()
        {
            return driver.FindElement(By.XPath("//button[contains(text(),'Color Change')]")).Displayed;
        }

    }
}
