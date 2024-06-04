
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA
{
    public class ToolTips
    {
        private IWebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/tool-tips");
            driver.Manage().Window.Maximize();
            ScrollDown(300);
        }

        [Test]
        public void Hoverhere()
        {
            HoverElement();
            Assert.IsTrue(IsHoverVisible(),"Hover here is not visible");
        }
        [Test]
        public void InputBoxHover()
        {
            HoverInputElement();
            Assert.IsTrue(IsHoverInput(), "Hover here is not visible");
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


        private By HovermeId => By.Id("toolTipButton");
        private By HoverInput => By.Id("toolTipTextField");

        public void HoverElement()
        {
            IWebElement element = driver.FindElement(HovermeId);
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
           
        }
        public bool  IsHoverVisible()
        {
            return driver.FindElement(HovermeId).Displayed;
        }

        public void HoverInputElement()
        {
            IWebElement ele = driver.FindElement(HoverInput);
            Actions action = new Actions(driver);
            action.MoveToElement(ele).Perform();
        }
        public bool IsHoverInput()
        {
            return driver.FindElement(HoverInput).Displayed;
        }
    }
}
