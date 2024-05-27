using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA
{
    public class Selectable
    {
        private IWebDriver driver;
        [SetUp]
        public void OpenBrowser()
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/selectable");
            driver.Manage().Window.Maximize();
            ScrollDown(300);

        }
        [Test]
        public void Selectablelements()
        {
            ClickGrid();
            ClickList();
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

        private By ClickOnGrid => By.XPath("//a[@id='demo-tab-grid']");
        private By GridTwo => By.XPath("//li[contains(text(),'Two')]");
        private By GridFour => By.XPath("//li[contains(text(),'Four')]");
        private By ClickOnList => By.XPath("//a[@id='demo-tab-list']");
        private By ListThree => By.XPath("//li[contains(text(),'Morbi leo risus')]");
        private By ListFour => By.XPath("//li[contains(text(),'Porta ac consectetur ac')]");


        public void ClickElement(By by, int TimeOutInSeconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeOutInSeconds));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            element.Click();
        }

        public void ClickGrid()
        {
            ClickElement(ClickOnGrid);
            ClickElement(GridTwo);
            ClickElement(GridFour);
        }

        public void ClickList()
        {
            ClickElement(ClickOnList);
            ClickElement(ListThree);
            ClickElement(ListFour);
        }

    }


}
