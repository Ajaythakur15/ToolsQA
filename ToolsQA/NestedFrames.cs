using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA
{
    [TestFixture]
    public class NestedFrames
    {
        private IWebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/nestedframes");
            driver.Manage().Window.Maximize();
            ScrollDown(300);

        }
        [Test]
        public void VerifyOuterFrame()
        {
            Assert.IsTrue(IsOutertFrame(),"This is not outer Iframe");
        }
        [Test]
        public void VerifyInnerFrame()
        {
            Assert.IsTrue(IsInnerFrame(), "This is outer Iframe");
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

        public bool IsOutertFrame()
        {
            return driver.FindElement(By.XPath("//iframe[@id='frame1']")).Displayed;
        }
        public bool IsInnerFrame()
        {
            return driver.FindElement(By.XPath("//iframe[@id='frame1']")).Displayed;
        }
    }
}
