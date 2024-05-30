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
    public class Dragable
    {
        private IWebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/dragabble");
            driver.Manage().Window.Maximize();
            ScrollDown(300);
        }
        [Test]
        public void SimpleDrag()
        {
            DragMethods obj = new DragMethods(driver);
           
            Point initialLocation = obj.IsSimpleDrag();

            // Perform the drag operation
            obj.SimpleDrag();

            // Get the final location of the drag box after the drag operation
            Point finalLocation = obj.IsSimpleDrag();

            // Check if the element has moved
            Assert.AreNotEqual(initialLocation, finalLocation, "Drag operation failed.");
        
    }
        [Test]
        public void AxisRestricted()
        {
            DragMethods obj = new DragMethods(driver);
            driver.FindElement(By.Id("draggableExample-tab-axisRestriction")).Click();

            Point initialLocation = obj.IsAxisXDrag();
            Point initialLocation2 = obj.IsAxisYDrag();
            obj.AxisDrag();
            Point finalLocation = obj.IsAxisXDrag();
            Point finalLocation2 = obj.IsAxisYDrag();

            Assert.AreNotEqual(initialLocation, finalLocation, "X Drag is failed");
            Assert.AreNotEqual(initialLocation2, finalLocation2, "Y drag is failed");

        }
        [Test]
        public void ContainerRestrictedWithInBox()
        {
            DragMethods obj = new DragMethods(driver);
            driver.FindElement(By.Id("draggableExample-tab-containerRestriction")).Click();

            Point initial = obj.IsContainedWithInBoxDrag();
            obj.ContainedWithInBoxDrag();
            Point final = obj.IsContainedWithInBoxDrag();

            Assert.AreNotEqual(initial, final, "Drag operation failed");

        }
        [Test]
          public void ContainerRestrictedWithInParent()
        {
            DragMethods obj = new DragMethods(driver);
            driver.FindElement(By.Id("draggableExample-tab-containerRestriction")).Click();
            ScrollDown(400);

            Point inital = obj.IsContainedWithInParentDrag();
            obj.ContainedWithInParentDrag();
            Point final = obj.IsContainedWithInParentDrag();

            Assert.AreNotEqual(inital,final, "Drag operation failed");

        }
        [Test]
        public void CursorStyle()
        {
            DragMethods obj = new DragMethods(driver);
            driver.FindElement(By.Id("draggableExample-tab-cursorStyle")).Click();

            Point initialPoint = obj.IsCursorCenter();
            Point initialPoint2 = obj.IsCursorTop();
            obj.CursorDrag();
            Point final = obj.IsCursorCenter();
            Point final2 = obj.IsCursorTop();

            Assert.AreNotEqual(initialPoint, final, "Drag Center operation failed");
            Assert.AreNotEqual(initialPoint2, final2, "Drag Top operation failed");
        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
        public void ScrollDown(int yOffset)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0,{yOffset});");
        }


    }

    public class DragMethods
    {
        private IWebDriver driver;

        public DragMethods(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By SimpleDragId => By.Id("dragBox");
        private By AxisXId => By.Id("restrictedX");
        private By AxisYId => By.Id("restrictedY");
        private By ContainedWithInBoxId => By.XPath("//div[contains(text(),\"I'm contained within the box\")]");
        private By ContainedWithInParent => By.XPath("//span[contains(text(),\"I'm contained within my parent\")]");
        private By CursorcenterId => By.Id("cursorCenter");
        private By CursorTopId => By.Id("cursorTopLeft");

        public void SimpleDrag()
        {
            IWebElement element = driver.FindElement(SimpleDragId);
            Actions action = new Actions(driver);
            int xOffset = 510;
            int yOffset = 45;
            action.DragAndDropToOffset(element,xOffset,yOffset).Build().Perform();
        }
        public Point IsSimpleDrag()
        {
            IWebElement element = driver.FindElement(SimpleDragId);
            return element.Location;
        }
        public void AxisDrag() 
        {
            IWebElement element = driver.FindElement(AxisXId);
            IWebElement ele = driver.FindElement(AxisYId);
            Actions action = new Actions(driver);
            int xoffset = 340;
            int yoffset = 0;
            int xoffset2 = 0;
            int yoffset2 = 92;
            action.DragAndDropToOffset(element, xoffset, yoffset).Build().Perform();
            action.DragAndDropToOffset(ele, xoffset2, yoffset2).Build().Perform();

        }
        public Point IsAxisXDrag()
        {
            IWebElement element = driver.FindElement(AxisXId);
            return element.Location;
        }
        public Point IsAxisYDrag()
        {
            IWebElement element = driver.FindElement(AxisYId);
            return element.Location;
        }
        public void ContainedWithInBoxDrag()
        {
            IWebElement element = driver.FindElement(ContainedWithInBoxId);
            Actions action = new Actions(driver);
            int xoffset = 413;
            int yoffset = 57;
            action.DragAndDropToOffset(element,xoffset,yoffset).Build().Perform();
        }
        public Point IsContainedWithInBoxDrag()
        {
            IWebElement element = driver.FindElement(ContainedWithInBoxId);
            return element.Location;
        }
        public void ContainedWithInParentDrag()
        {
            IWebElement element = driver.FindElement(ContainedWithInParent);
            Actions action = new Actions(driver);
            int xoffset = 14;
            int yoffset = 86;
            action.DragAndDropToOffset(element,xoffset,yoffset).Build().Perform();
        }
        public Point IsContainedWithInParentDrag()
        {
            IWebElement element = driver.FindElement(ContainedWithInParent);
            return element.Location;
        }
        public void CursorDrag() 
        {
            IWebElement ele1 = driver.FindElement(CursorcenterId);
            IWebElement ele2 = driver.FindElement(CursorTopId);
            Actions action = new Actions(driver);
            int xoffset = 360;
            int yoffset = 101;
            int xoffset2 = 266;
            int yoffset2 = 121;
            action.DragAndDropToOffset(ele1,xoffset,yoffset).Build().Perform();
            action.DragAndDropToOffset(ele2, xoffset2, yoffset2).Build().Perform();
        }
        public Point IsCursorCenter()
        {
            IWebElement element = driver.FindElement(CursorcenterId);
            return element.Location;
        }
        public Point IsCursorTop()
        {
            IWebElement element = driver.FindElement(CursorTopId);
            return element.Location;
        }
    }
}


/*This method returns the location of the drag box as a Point object,
which contains the X and Y coordinates of the element on the page.*/
