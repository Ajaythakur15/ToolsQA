using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;
using System;
using System.IO;

namespace ToolsQA
{
    [TestFixture]
    public class Upload_Download
    {
        private IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("download.default_directory", Path.GetFullPath("Downloads"));
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("disable-popup-blocking", "true");

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://demoqa.com/upload-download");
            driver.Manage().Window.Maximize();
            ScrollDown(500);
        }

        [Test]
        public void ClickDownloadBtn()
        {
            Assert.IsTrue(IsBtnVisible(), "Download button is not displayed");
            ClickBtn();
        }

        [Test]
        public void ClickChooseFile()
        {
            Assert.IsTrue(IsChooseVisible(), "Choose file button is not displayed");
            ClickChooseBtn();
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
            return IsElementVisible(By.XPath("//a[@id='downloadButton']"));
        }

        public void ClickChooseBtn()
        {
            var uploadElement = driver.FindElement(By.Id("uploadFile"));
            uploadElement.SendKeys(Path.GetFullPath("C:/QA/Test/File.txt")); // Update the path to your file

        }

        public bool IsChooseVisible()
        {
            return IsElementVisible(By.XPath("//input[@id='uploadFile']"));
        }

        public void ClickElement(By locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                element.Click();
            }
            catch (WebDriverTimeoutException e)
            {
                throw new Exception($"Element with locator: {locator} was not clickable after 10 seconds.", e);
            }
            catch (NoSuchElementException e)
            {
                throw new Exception($"Element with locator: {locator} was not found.", e);
            }
            catch (Exception e)
            {
                throw new Exception($"Unexpected error occurred while clicking element with locator: {locator}.", e);
            }
        }

    public bool IsElementVisible(By locator)
        {
            try
            {
                return driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void ScrollDown(int yOffset)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0, {yOffset});");
        }
    }
}
