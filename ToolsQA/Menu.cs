using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA
{
    public class Menu
    {
        private IWebDriver driver;
        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/menu#");
            driver.Manage().Window.Maximize();
            ScrollDown(300);
        }
        [Test]
        public void MenuItem1()
        {
            HoveranClickMenu1();
            IsHoveranClickMenu1();
        }
        [Test]
        public void MenuItem2()
        {
            HoveranClickMenu2();
            IsHoveranClickMenu2();
        }
        [Test]
        public void MenuItem3()
        {
            HoveranClickMenu3();
            IsHoveranClickMenu3();
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


        private By MenuId1 => By.XPath("//a[contains(text(),'Main Item 1')]");
        private By MenuId2 => By.XPath("//a[contains(text(),'Main Item 2')]");
        private By MenuId2Sublist => By.XPath("//a[contains(text(),'SUB SUB LIST »')]");
        private By MenuId2SubListItem => By.XPath("//a[contains(text(),'Sub Sub Item 1')]");
        private By MenuId3 => By.XPath("//a[contains(text(),'Main Item 3')]");


        public void HoveranClickMenu1()
        {
            IWebElement element = driver.FindElement(MenuId1);
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            ClickElement(MenuId1);

        }
        public bool IsHoveranClickMenu1()
        {
            return driver.FindElement(MenuId1).Selected;
        }
        public void HoveranClickMenu2()
        {
            IWebElement element = driver.FindElement(MenuId2);
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            IWebElement ele2 = driver.FindElement(MenuId2Sublist);
            Actions actions = new Actions(driver);
            actions.MoveToElement(ele2).Perform();

            IWebElement ele3 = driver.FindElement(MenuId2SubListItem);
            Actions act = new Actions(driver);
            act.MoveToElement(ele3).Perform();
            ClickElement(MenuId2SubListItem);
        }
        public bool IsHoveranClickMenu2()
        {
            return driver.FindElement(MenuId2SubListItem).Selected;
        }
        public void HoveranClickMenu3()
        {
            IWebElement element = driver.FindElement(MenuId3);
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            ClickElement(MenuId3);

        }
        public bool IsHoveranClickMenu3()
        {
            return driver.FindElement(MenuId3).Selected;
        }

        public void ClickElement(By by , int TimeOutInSeconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(TimeOutInSeconds));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            element.Click();

        }
    }
}
