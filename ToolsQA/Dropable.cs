﻿using NUnit.Framework;
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
    public class Dropable
    {
        private IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/droppable");
            driver.Manage().Window.Maximize();
            ScrollDown(300);
        }
        [Test]
        public void DragAndDropElement()
        {
            var dropableMethods = new DropableMethods(driver);
            dropableMethods.DragElement();
            Assert.IsTrue(dropableMethods.IsElementDraged(), "Element is not Dragged");
        }
        [Test]
        public void AcceptDragandDrop()
        {
            var dropableMethods = new DropableMethods(driver);
            dropableMethods.ClickElement();
            
            dropableMethods.DragNotAcceptElement();
            Assert.IsFalse(dropableMethods.IsElementDragedOfNotAccept(), "Element is  NotAccept Dragged");

            dropableMethods.DragAcceptElement();
            Assert.IsTrue(dropableMethods.IsElementDraged(), "Element is not Dragged");


        }
        [Test]
        public void PreventPropogationDrag()
        {
            var dropableMethods = new DropableMethods(driver);
            driver.FindElement(By.Id("droppableExample-tab-preventPropogation")).Click();
            dropableMethods.DragPropogation();

            dropableMethods.DragPropogationGreedy();
            Assert.IsTrue(dropableMethods.IsthisofGreedy(),"This is not greedy");

        }
        [Test]
        public void RevertDragableCheck()
        {
            var dropableMethods = new DropableMethods(driver);
            driver.FindElement(By.Id("droppableExample-tab-revertable")).Click();
            var initialLocation = dropableMethods.GetDragableLocation();

            dropableMethods.RevertDragable();
            var finalLocation = dropableMethods.GetDragableLocation();
            Assert.AreEqual(initialLocation, finalLocation, "Dragged element should revert to initial position");
            
        }
        [Test]
        public void NotRevertCheck()
        {
            var dropableMethods = new DropableMethods(driver);
            driver.FindElement(By.Id("droppableExample-tab-revertable")).Click();
            var initialLocation = dropableMethods.GetDragableLocation2();

            dropableMethods.NotRevertDragable();
            var finalLocation = dropableMethods.GetDragableLocation2();
            Assert.AreNotEqual(initialLocation, finalLocation, "Dragged element should stay in the new position");



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
    }

    public class DropableMethods
    {
        private IWebDriver driver;
        public DropableMethods(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By SimpleDrag => By.XPath("//div[@id='draggable']");
        private By DropTarget => By.XPath("//div[@id='simpleDropContainer']//div[@id='droppable']");
        private By AcceptDrag => By.XPath("//div[@id='acceptable']");
        private By AcceptNotDrag => By.XPath("//div[@id='notAcceptable']");
        private By DropAccept => By.XPath("//div[@id='acceptDropContainer']//div[@id='droppable']");
        private By DragBox => By.Id("dragBox");
        private By InnerBox => By.Id("notGreedyInnerDropBox");
        private By OuterBox => By.Id("notGreedyDropBox");
        private By Revert => By.Id("revertable");
        private By RevertNot => By.Id("notRevertable");
        private By DragRevert => By.Id("droppable");

        public void DragElement()
        {
            IWebElement Dragable = driver.FindElement(SimpleDrag);
            IWebElement Dropable = driver.FindElement(DropTarget);
            Actions action = new Actions(driver);
            action.DragAndDrop(Dragable,Dropable).Build().Perform();
        }
        public bool IsElementDraged()
        {
            return driver.FindElement(By.XPath("//p[contains(text(),'Dropped')]")).Displayed;
        }
        public bool IsElementDragedOfNotAccept()
        {
            return driver.FindElement(By.XPath("//p[contains(text(),'Drop here')]")).Displayed;
        }
        public bool IsthisofGreedy()
        {
            return driver.FindElement(By.XPath("//p[contains(text(),'Outer droppable')]")).Displayed;
        }

        public void DragAcceptElement()
        {
            IWebElement Dragable2 = driver.FindElement(AcceptDrag);
            IWebElement Dropable2 = driver.FindElement(DropAccept);
            Actions action = new Actions(driver);
            action.DragAndDrop(Dragable2, Dropable2).Build().Perform();
        }
        public void DragNotAcceptElement()
        {
            IWebElement Dragable3 = driver.FindElement(AcceptNotDrag);
            IWebElement Dropable3 = driver.FindElement(DropAccept);
            Actions action = new Actions(driver);
            action.DragAndDrop(Dragable3, Dropable3).Build().Perform();
        }
        public void ClickElement()
        {
            driver.FindElement(By.Id("droppableExample-tab-accept")).Click();
        }

        public void DragPropogation()
        {
            IWebElement Dragable4 = driver.FindElement(DragBox);
            IWebElement Dropable4 = driver.FindElement(InnerBox);
            Actions action = new Actions(driver);
            action.DragAndDrop(Dragable4, Dropable4).Build().Perform();
        }
        public void DragPropogationGreedy()
        {
            IWebElement Dragable5 = driver.FindElement(DragBox);
            IWebElement Dropable5 = driver.FindElement(OuterBox);
            Actions action = new Actions(driver);
            action.DragAndDrop(Dragable5, Dropable5).Build().Perform();
        }
        public void RevertDragable()
        {
            IWebElement Dragable6 = driver.FindElement(Revert);
            IWebElement Dropable6 = driver.FindElement(DragRevert);
            Actions action = new Actions(driver);
            action.DragAndDrop(Dragable6, Dropable6).Build().Perform();
        }
        public Point GetDragableLocation()
        {
            IWebElement draggableElement = driver.FindElement(Revert);
            return draggableElement.Location;
        }
        public void NotRevertDragable()
        {
            IWebElement Dragable7 = driver.FindElement(RevertNot);
            IWebElement Dropable7 = driver.FindElement(DragRevert);
            Actions action = new Actions(driver);
            action.DragAndDrop(Dragable7, Dropable7).Build().Perform();
        }

        public Point GetDragableLocation2()
        {
            IWebElement draggableElement = driver.FindElement(RevertNot);
            return draggableElement.Location;
        }

    }
}
