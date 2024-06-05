using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace ToolsQA
{
    public class AutoComplete
    {
        private IWebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/auto-complete");
            driver.Manage().Window.Maximize();
            ScrollDown(300);
        }
        [Test]
        public void MultiColorNames()
        {
            MethodsForMulticolour obj = new MethodsForMulticolour(driver);
            obj.Input1("P","G","B");
        }
        [Test]
        public void SingleColorNmae()
        {
            MethodsForMulticolour obj = new MethodsForMulticolour(driver);
            obj.Input2("y");
            
            Assert.AreEqual("y",obj.IsInput2(), "Value does not matched");
        }

        public void ScrollDown(int yOffset)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0,{yOffset});");
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }

    public class MethodsForMulticolour
    {
        private IWebDriver driver;

        public MethodsForMulticolour(IWebDriver driver)
        {
            this.driver = driver;
        }

         private By FillInput2 => By.Id("autoCompleteSingleInput");

        public void Input2(string color)
        {
            ClickElement(FillInput2);
            SendKeys(FillInput2,color);
            
        }
        public string IsInput2()
        {
            IWebElement element = driver.FindElement(FillInput2);
            return element.Text;
        }

        public void Input1(params string[] text)
        {
            IWebElement multiColorInput = driver.FindElement(By.Id("autoCompleteMultipleInput"));

            //ClickElement(FillInput1);
            multiColorInput.Click();
            foreach(string color in text)
            {
               
                multiColorInput.SendKeys(color);
                multiColorInput.SendKeys(Keys.Enter);

                // Wait for the autocomplete suggestion to appear
               // WebDriverWait wait  = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
               // var suggestionXpath = By.XPath($"//div[@id='autoCompleteMultiple']//div[text()='{text}']");
               // wait.Until(ExpectedConditions.ElementExists(suggestionXpath));
                // Click on the suggestion
                ////IWebElement suggestion = driver.FindElement(suggestionXpath);
               // suggestion.Click();

            }
          
        }

        public void ClickElement(By by, int TimeOutInSeconds = 60)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeOutInSeconds));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            element.Click();
        }
        public void SendKeys(By by ,string text)
        {
            var element = driver.FindElement(by);
           
            element.SendKeys(text);
            element.SendKeys(Keys.Enter);
        }
    }

}
