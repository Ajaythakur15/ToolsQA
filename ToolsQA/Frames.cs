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
    public class Frames
    {
        private IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/frames");
            driver.Manage().Window.Maximize();
            ScrollDown(600);
        }
        [Test]
        public void VerifyFrameAndScroll()
        {
            // Switch to the iframe
            driver.SwitchTo().Frame("frame2"); // Assuming "frame2" is the ID of the iframe

          
            IWebElement element =  driver.FindElement(By.XPath("//h1[@id='sampleHeading']"));
            ScrollElementDown(element);
            //ScrollElementUp(element);
            //driver.SwitchTo().DefaultContent();
        }
        public void ScrollElementDown(IWebElement element)
        {
           
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollBy(0,100);", element);
        }
        public void ScrollElementUp(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollBy(0,-100);", element);
        }
        /*public bool IsElementVisible(By by)
        {
            try
            {
                return driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }*/
        public void ScrollDown(int yOffset)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0,{yOffset});");
        }
       /* [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }*/
    }
}
