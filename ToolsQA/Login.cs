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
            ScrollDown(200);
            obj.LoginClick();
            Assert.IsTrue(obj.IsLoginClick(),"Login Button is not visible");

        }
        [Test]
        public void NewUser()
        {
            LoginMethods obj = new LoginMethods(driver);
            ScrollDown(100);
            obj.NewUserClick();
            Assert.IsFalse(obj.IsNewUserClick(),"NewUser is visible");
            ScrollDown(300);
            obj.FillFirstName("ketan");
            obj.FillLastName("singh");
            obj.FillUsername("KS");
            obj.FillPassword("@Prachi1");
            ScrollDown(300);
            obj.FillCheckBox();
            obj.ClickRegisterBtn();
            Assert.IsTrue(obj.IsRegisterBtn(),"Register button is not visible");
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
            IWebElement element =  wait.Until(ExpectedConditions.ElementToBeClickable(by));
            element.Click();
        }
        public void SendKeys(By by,string text , int timeOutInSeconds = 40)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            element.SendKeys(text);
        }

        private By UsernameId => By.Id("userName");
        private By PasswordId => By.Id("password");
        private By LoginBtnId => By.XPath("//button[contains(text(),'Login')]");
        private By NewUserId => By.XPath("//button[contains(text(),'New User')]");
        private By FirstNameId => By.Id("firstname");
        private By LastNameId => By.Id("lastname");
        private By RegisterId => By.Id("register");
        private By CheckBoxId => By.XPath("//div[@id='g-recaptcha']");
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
            try
            {
                return driver.FindElement(LoginBtnId).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public void NewUserClick()
        {
            ClickElement(NewUserId);
        }
        public bool IsNewUserClick()
        {
            try
            {
                return driver.FindElement(NewUserId).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public void FillFirstName(string text)
        {
            SendKeys(FirstNameId,text);
        }
        public void FillLastName(string text)
        {
            SendKeys(LastNameId, text);
        }
        public void ClickRegisterBtn()
        {
            ClickElement(RegisterId);
        }
        public bool IsRegisterBtn()
        {
            try
            {
                return driver.FindElement(RegisterId).Displayed;
            }
            catch (NoSuchElementException)
            {
                return true; 
            }
        }
        public void FillCheckBox()
        {
            ClickElement(CheckBoxId);
        }

    }

}
