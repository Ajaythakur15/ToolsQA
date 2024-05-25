using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ToolsQA
{
    public class Slider
    {
        private IWebDriver driver;
        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/slider");
            driver.Manage().Window.Maximize();
            ScrollDown(300);

        }
        [Test]
        public void SliderRight()
        {
            ScrollRight();
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


        public void ScrollRight()
        {
            IWebElement element = driver.FindElement(By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/form[1]/div[1]/div[1]/span[1]/div[1]"));
           
            string newStyle = "left: calc(75% - 5px)";

            ((IJavaScriptExecutor)driver).ExecuteScript($"arguments[0].setAttribute('style','{newStyle}')",element);
            System.Threading.Thread.Sleep(10000);
            string updatedStyle = element.GetAttribute("style");
           // Assert.IsTrue(updatedStyle.Contains("left: calc(75% - 5px)"), "Slider handle not scrolled to the left as expected.");
        }
    }

}

