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
    
    public class Alerts
    {
        private IWebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");
            driver.Manage().Window.Maximize();
            ScrollDown(300);   
        }

        [Test]
        public void ClickForAlert()
        {
            MethodsForButtons obj = new MethodsForButtons(driver);
            obj.ClickOnAlertBtn();
            obj.HandelAlert();
            Assert.IsTrue(obj.IsClickOnAlertVisible(),"Alert Button is not visible after click ");
        }
        [Test]
        public void ClickForSecondAlert()
        {
            MethodsForButtons obj = new MethodsForButtons(driver);
            obj.ClickOnSecondAlertBtn();
            obj.HandelAlert();
            Assert.IsTrue(obj.IsClickOnAlertVisible(), "Alert Button is not visible after click ");

        }
        [Test]
        public void ClickForConfirmBox()
        {
            MethodsForButtons obj = new MethodsForButtons(driver);
            obj.ClickOnConfirmBtn();
            obj.HandelConfirmBox(true);
            Assert.IsTrue(obj.IsClickOnAlertVisible(), "Confirm button is not visible after click");
        }
        [Test]
        public void ClickForPromptBox()
        {
            MethodsForButtons obj = new MethodsForButtons(driver);
            obj.ClickOnPromtBtn();
            obj.HandelPromtBox( "I am Prachi Sharma");
            Assert.IsTrue(obj.IsClickOnAlertVisible(), "prompt button is not visible after click");
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
     
    public class MethodsForButtons
    {
        private IWebDriver driver;

        public MethodsForButtons(IWebDriver driver)
        {
            this.driver = driver;
        }


        public void ClickOnAlertBtn()
        {
            ClickElement(By.XPath("//button[@id='alertButton']"));
        }
        public void HandelAlert()
        {
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(5));
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
        }
        public bool IsClickOnAlertVisible()
        {
            return driver.FindElement(By.XPath("//button[@id='alertButton']")).Displayed;
        }
        public void ClickOnSecondAlertBtn()
        {
            ClickElement(By.XPath("//button[@id='timerAlertButton']"));
        }
        public void ClickElement(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(10));
            IWebElement element =  wait.Until(ExpectedConditions.ElementIsVisible(by));
            element.Click();
            
        }
        public void ClickOnConfirmBtn()
        {
            ClickElement(By.XPath("//button[@id='confirmButton']"));
        }
        public void HandelConfirmBox(bool accept)
        {
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(5));
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
            if(accept)
            {
                alert.Accept();
            }
            else
            {
                alert.Dismiss();
            }
        }
        public void ClickOnPromtBtn()
        {
            ClickElement(By.XPath("//button[@id='promtButton']"));
        }
        public void HandelPromtBox( string promtext)
        {
            WebDriverWait wait = new WebDriverWait(driver , TimeSpan.FromSeconds(5));
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
            if(promtext != null)
            {
                alert.SendKeys(promtext);
                alert.Accept();
            }
            else
            {
                alert.Dismiss();
            }

        }


    }
}
