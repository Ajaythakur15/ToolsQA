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
    public class DatePicker
    {
       private IWebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/date-picker");
            driver.Manage().Window.Maximize();
            ScrollDown(300);
        }
        [Test]
        public void SelectDate()
        {
            ClickOnSelectDate();
            Assert.AreEqual("06/05/2000",IsSelectDate("datePickerMonthYearInput"), "Date is incorrect");
        }
        [Test]
        public void SelectDateAnTime()
        {
            ClickOnSelectDateTime();
            Assert.AreEqual("September 15, 2029 3:00 PM", IsSelectDateAnTime("dateAndTimePickerInput"), "Date an time are not same");
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


        public void ClickElement(By by, int TimeOutInSeconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeOutInSeconds));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            element.Click();
        }

        private By ClickInputBox => By.Id("datePickerMonthYearInput");
        private By ClickOnMonth => By.XPath("//option[contains(text(),'June')]");
        private By ClickOnYear => By.XPath("//option[contains(text(),'2000')]");
        private By ClickOnDate => By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[2]/div[2]/div[1]/div[1]/div[2]/div[2]/div[2]/div[2]");
        private By ClickOnDateTimeInput => By.Id("dateAndTimePickerInput");
        private By ClickOnArrow => By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/span[1]");
       private By ClickOnDateArrow => By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/span[1]");
        private By ClickOnMonth2 => By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[9]");
        private By ClickOnYear2 => By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/div[2]");
        private By ClickOnDate2 => By.XPath("//div[contains(text(),'15')]");
        private By ClickOnTime => By.XPath("//li[contains(text(),'15:00')]");


        public void ClickOnSelectDate()
        {
            ClickElement(ClickInputBox);
            ClickElement(ClickOnMonth);
            ClickElement(ClickOnYear);
            ClickElement(ClickOnDate);
        }
        public string IsSelectDate(string id)
        {
            return driver.FindElement(By.Id(id)).GetAttribute("value");
        }

        public void ClickOnSelectDateTime()
        {
            ClickElement(ClickOnDateTimeInput);
            ClickElement(ClickOnArrow);
            ClickElement(ClickOnMonth2);
            ClickElement(ClickOnDateArrow);
            ClickElement(ClickOnYear2);
            ClickElement(ClickOnDate2);
            ClickElement(ClickOnTime);
        }
        public string IsSelectDateAnTime(string id)
        {
            return driver.FindElement(By.Id(id)).GetAttribute("value");
        }



    }
}
