using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA
{
    [TestFixture]
    public class Upload_Download
    {
        private IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/upload-download");
            driver.Manage().Window.Maximize();
            ScrollDown(400);
        }
        [Test]
        public void ClickDownloadBtn()
        {
            Assert.IsTrue(IsBtnVisible(),"Button is not displayed");
            ClickBtn();   
        }
        [Test]
        public void ClickChooseFile()
        {
            // Assert.IsTrue(IsChooseVisible(), "ChooseFilebtn is not displayed");
            ClickChooseFileBtn();

        }

        public void ScrollDown(int yOffset)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0, {yOffset});");
        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }

        public void ClickBtn()
        {
            ClickElement(By.XPath("//a[@id='downloadButton']"));
        }
        public bool IsBtnVisible()
        {
            return driver.FindElement(By.XPath("//a[@id='downloadButton']")).Displayed;
        }
        public void ClickChooseFileBtn()
        {
            driver.FindElement(By.CssSelector("#uploadFile")).Click();
            
        }
        public bool IsChooseVisible()
        {
            return driver.FindElement(By.XPath("//input[@id='uploadFile']")).Displayed;
        }
        public void ClickElement(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            element.Click();
        }


    }
}
