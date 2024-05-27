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
   public class Sortable
    {
        private IWebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://demoqa.com/sortable");
                driver.Manage().Window.Maximize();
                ScrollDown(300);
            
        }
        [Test]
        public void SortableElements()
        {
            Grid();
            List();
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


        public void ClickElement(By by, int TimeOutInSeconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeOutInSeconds));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            element.Click();
        }

        private By ClickGrid => By.XPath("//a[@id='demo-tab-grid']");
        private By ClickGridValue => By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[5]");
        private By ClickList => By.XPath("//a[@id='demo-tab-list']");
        private By ClickListValue => By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[4]");

        public void Grid()
        {
            ClickElement(ClickGrid);
            ClickElement(ClickGridValue);
        }
        public void List()
        {
            ClickElement(ClickList);
            ClickElement(ClickListValue);
        }
    }
}
