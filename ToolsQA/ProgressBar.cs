using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA
{
   public class ProgressBar
    {
        private IWebDriver driver;
        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/progress-bar");
            driver.Manage().Window.Maximize();
            ScrollDown(300);

        }
        [Test]
        public void StartBtn()
        {
            TestCasesBtn obj = new TestCasesBtn(driver);
            Assert.IsTrue(obj.IsBtnVisible(), "Button is not visible");
            obj.Start();
            obj.Stop();


        }
        public void StopBtn()
        {
            TestCasesBtn obj = new TestCasesBtn(driver);
            obj.Stop();
            Assert.IsTrue(obj.IsBtnVisible(), "Button is not visible");
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
    public class TestCasesBtn
    {
        private IWebDriver driver;

        public TestCasesBtn(IWebDriver driver)
        {
            this.driver = driver;
        }


        private By ClickStartInput => By.Id("startStopButton");
        public void Start()
        {
            ClickElement(ClickStartInput);
        }
        public void Stop()
        {
            ClickElement(ClickStartInput);
        }
        public bool IsBtnVisible()
        {
            return driver.FindElement(By.Id("startStopButton")).Displayed;
        }


        public void ClickElement(By by, int TimeOutInSeconds = 60)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeOutInSeconds));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            element.Click();
        }

    }
}
