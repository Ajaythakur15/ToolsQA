using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA
{
    [TestFixture]
    public class ModalDialogue
    {
        private IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/modal-dialogs");
            driver.Manage().Window.Maximize();
            ScrollDown(400);
        }

        [Test]
        public void SmallModel()
        {
            HandelDialogue obj = new HandelDialogue(driver);
            obj.ClickOnSmallModal();
            Assert.IsTrue(obj.IsClickOnSmallModal(),"Small btn is not visible after click");
            obj.CloseBtn();
            Assert.IsFalse(obj.IsCloseBtn(),"Small Button is visible");

        }

        [Test]
        public void LargelModel()
        {
            HandelDialogue obj = new HandelDialogue(driver);
            obj.ClickOnLargeModal();
            Assert.IsTrue(obj.IsClickOnLargeModal(), "Large btn is not visible after click");
            obj.CloseLargeBtn();
            Assert.IsFalse(obj.IsCloseLargeBtn(), "Large Button is visible");
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
    public class HandelDialogue
    {
        private IWebDriver driver;
        public HandelDialogue(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ClickOnSmallModal()
        {
            ClickElement(By.XPath("//button[@id='showSmallModal']"));
        }
        public void ClickElement(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver , TimeSpan.FromSeconds(5));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            element.Click();

        }
        public bool IsClickOnSmallModal()
        {
            return driver.FindElement(By.XPath("//button[@id='showSmallModal']")).Displayed;
        }
        public void ClickOnLargeModal()
        {
            ClickElement(By.XPath("//button[@id='showLargeModal']"));
        }
        public bool IsClickOnLargeModal()
        {
            return driver.FindElement(By.XPath("//button[@id='showLargeModal']")).Displayed;
        }

        public void CloseLargeBtn()
        {
            ClickElement(By.XPath("//button[@id='closeLargeModal']"));
        }
        public bool IsCloseLargeBtn()
        {
            return IsElementPresent(By.XPath("//button[@id='closeLargeModal']"));
        }

        public void CloseBtn()
        {
            ClickElement(By.XPath("//button[@id='closeSmallModal']"));
        }
        public bool IsCloseBtn()
        {
            return IsElementPresent(By.XPath("//button[@id='closeSmallModal']"));
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                return driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
