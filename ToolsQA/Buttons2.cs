using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA
{
    [TestFixture]
    public class Buttons
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/buttons");
            ScrollPage(400);
        }


        [Test]
        public void ClickOnDoubleClickButton()
        {
            ButtonsPath buttonpath = new ButtonsPath(driver);
            buttonpath.ClickOnDoubleClickButton();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => buttonpath.ClickOnDoubleClickButtonIsSelected());

            Assert.IsTrue(buttonpath.ClickOnDoubleClickButtonIsSelected(), "Double click button should be selected");
        }

        [Test]
        public void ClickOnRightClickButton()
        {
            ButtonsPath buttonpath = new ButtonsPath(driver);
            buttonpath.ClickOnRightClickButton();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => buttonpath.ClickOnRightClickButtonIsSelected());

            Assert.IsTrue(buttonpath.ClickOnRightClickButtonIsSelected(), "Right click button should get selected");
        }

        [Test]
        public void ClickOnClickButton()
        {
            ButtonsPath buttonpath = new ButtonsPath(driver);
            buttonpath.ClickOnClickButton();
            // // Wait for a certain condition to be true after clicking the button
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => buttonpath.ClickOnClickButtonIsSelected());

            Assert.IsTrue(buttonpath.ClickOnClickButtonIsSelected(), "Double click button should be selected");
        }


        public void ScrollPage(int yOffset)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0,{yOffset});");
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }

        /*  private IWebElement waitForElementClickable(By locator, int timeoutInSeconds = 10)
          {
              WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
              wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
          }*/
    }
    public class ButtonsPath
    {
        private IWebDriver driver;

        public ButtonsPath(IWebDriver driver)
        {
            this.driver = driver;
        }



        public void ClickOnDoubleClickButton()
        {
            IWebElement button = driver.FindElement(By.XPath("//button[@id='doubleClickBtn']"));
            //Create an instance of Action Class
            Actions action = new Actions(driver);
            //Actions class contains Doubleclcick method to Perform double click action on a button
            action.DoubleClick(button).Perform();
        }
        public bool ClickOnDoubleClickButtonIsSelected()
        {
            return driver.FindElement(By.XPath("//button[@id='doubleClickBtn']")).GetAttribute("class").Contains("btn-primary");
        }
        public void ClickOnRightClickButton()
        {
            IWebElement rightbtn = driver.FindElement(By.XPath("//button[@id='rightClickBtn']"));
            Actions action = new Actions(driver);
            action.ContextClick(rightbtn).Perform();
        }
        public bool ClickOnRightClickButtonIsSelected()
        {
            return driver.FindElement(By.XPath("//button[@id='rightClickBtn']")).GetAttribute("class").Contains("btn-primary");
        }
        public void ClickOnClickButton()
        {
            driver.FindElement(By.XPath("//button[starts-with(text(),'Click')]")).Click();
        }
        public bool ClickOnClickButtonIsSelected()
        {
            return driver.FindElement(By.XPath("//button[starts-with(text(),'Click')]")).GetAttribute("class").Contains("btn-primary");
        }
    }
}