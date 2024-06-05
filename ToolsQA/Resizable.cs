

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA
{
   public class Resizable
    {
        private IWebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/resizable");
            driver.Manage().Window.Maximize();
            ScrollDown(300);
        }
        [Test]
        public void ResizeBox1()
        {
            var testCase = new TestCaseOfResize(driver);
            var initializesize = testCase.GetResizeElement();
            // Call the method to perform the resize action
            testCase.ResizeElement();
            var finalsize = testCase.GetResizeElement();
            Assert.AreEqual(initializesize,finalsize,"Resizeable element size did not change ");
        }
        public void ScrollDown(int yOffset)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0,{yOffset});");
        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
    public class TestCaseOfResize
    {
        private IWebDriver driver;

        public TestCaseOfResize(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By DragArrow => By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/span[1]");

        public void ResizeElement()
        {
            IWebElement resizeHandle = driver.FindElement(DragArrow);
            Actions action = new Actions(driver);
            int xoffset = 500;
            int yoffset = 300;
            action.MoveToElement(resizeHandle).ClickAndHold().MoveByOffset(xoffset, yoffset).Release().Build().Perform();
            //action.ClickAndHold(RezieHandel).MoveByOffset(xoffset, yoffset).Release().Build().Perform();

        }

       public Size GetResizeElement()
        {
            IWebElement resizeElement = driver.FindElement(DragArrow);
            return resizeElement.Size;
        }
    }
}

/*//action.MoveToElement(resizeHandle).ClickAndHold().MoveByOffset(xoffset, yoffset).Release().Build().Perform();
//Here, the MoveToElement method moves the mouse cursor to the center of the resizeHandle element.
//Then, ClickAndHold is called to press and hold the mouse button at the current cursor position.
//Finally, MoveByOffset is used to move the cursor by the specified pixel offsets relative to its current position.
//This means that the resizing action will be relative to the center of the resizeHandle element.*/


/*action.ClickAndHold(RezieHandel).MoveByOffset(xoffset, yoffset).Release().Build().Perform();
In this case, ClickAndHold is called directly on the RezieHandel element without first moving the cursor to a specific position.
This means that the resizing action will be relative to wherever the cursor is located when ClickAndHold is called.*/