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
    public class Profile
    {
        private IWebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/profile");
            driver.Manage().Window.Maximize();
            scrollDown(300);
        }
        [Test]
        public void RegisterClick()
        {
            ProfileMethods obj = new ProfileMethods(driver);
            Assert.IsTrue(obj.IsRegisterClick(),"Register link is not visible");
            obj.RegisterClick();
        }
        [Test]
        public void LoginClick()
        {
            ProfileMethods obj = new ProfileMethods(driver);
            Assert.IsTrue(obj.IsLoginClick(), "Register link is not visible");
            obj.LoginClick();
        }
        public void scrollDown(int yoffset)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0,{yoffset});");
        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
    public class ProfileMethods
    {
        private IWebDriver driver;
        public ProfileMethods(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By RegisterId => By.XPath("//a[contains(text(),'register')]");
        private By LoginId => By.XPath("//a[contains(text(),'login')]");

        public void RegisterClick() 
        {
            ClickElement(RegisterId);
        }
        public bool IsRegisterClick()
        {
            return driver.FindElement(RegisterId).Displayed;
        }
        public void LoginClick()
        {
            ClickElement(LoginId);
        }
        public bool IsLoginClick()
        {
            return driver.FindElement(LoginId).Displayed;
        }
        public void ClickElement(By by , int TimeOutInSeconds = 40)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeOutInSeconds));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            element.Click();
        }

    }
}
