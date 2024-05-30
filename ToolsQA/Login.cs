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
    public class Login
    {
        private IWebDriver driver;
        [SetUp]
        public void OpeBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/login");
            driver.Manage().Window.Maximize();
            ScrollDown(300);
        }
        [Test]
        public void InputBoxes()
        {
            LoginMethods obj = new LoginMethods(driver);
            obj.FillUsername("Prachi");
            obj.FillPassword("1234");
            obj.LoginClick();
            Assert.IsTrue(obj.IsLoginClick(),"Login Button is not visible");

        }
        [Test]
        public void NewUser()
        {
            LoginMethods obj = new LoginMethods(driver);
            obj.NewUserClick();
            Assert.IsFalse(obj.IsNewUserClick(),"NewUser is visible");
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
    public class LoginMethods
    {
        private IWebDriver driver;

        public LoginMethods(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickElement(By by , int timeOutInSeconds = 40)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            IWebElement element =  wait.Until(ExpectedConditions.ElementIsVisible(by));
            element.Click();
        }
        public void SendKeys(By by,string text , int timeOutInSeconds = 40)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            element.SendKeys(text);
        }

        private By UsernameId => By.Id("userName");
        public By PasswordId => By.Id("password");
        public By LoginBtnId => By.Id("login");
        private By NewUserId => By.Id("newUser");
        public void FillUsername(string text)
        { 
            SendKeys(UsernameId, text);
        }
        public void FillPassword(string text)
        {
           SendKeys(PasswordId,text);
        }
        public void LoginClick()
        {
            ClickElement(LoginBtnId);
        }
        public bool IsLoginClick()
        {
            return driver.FindElement(By.Id("login")).Displayed;
        }
        public void NewUserClick()
        {
            ClickElement(NewUserId);
        }
        public bool IsNewUserClick()
        {
            return driver.FindElement(By.Id("newUser")).Displayed;
        }

    }

}
