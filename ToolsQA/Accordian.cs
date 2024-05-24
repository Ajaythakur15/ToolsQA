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
    public class Accordian
    {
        private IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/accordian");
            driver.Manage().Window.Maximize();
            ScrollDown(300);
        }
        [Test]
        public void Section1Heading()
        {
            SectionsTestCases obj = new SectionsTestCases(driver);
            obj.ClickHeading1();
            Assert.IsTrue(obj.IsHeading1Visible(), "Heading1 is not visible after click");
        }
        [Test]       
        public void Section2Heading()
        {
            SectionsTestCases obj = new SectionsTestCases(driver);
            ScrollDown(300);
            obj.ClickHeading2();
            Assert.IsTrue(obj.IsHeading1Visible(), "Heading2 is not visible");

        }
        [Test]
        public void Section3Heading()
        {
            SectionsTestCases obj = new SectionsTestCases(driver);
            ScrollDown(300);
            obj.ClickHeading3();
            Assert.IsTrue(obj.IsHeading2Visible(), "Heading3 is not visible");
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

    public class SectionsTestCases
    {
        private IWebDriver driver;

        public SectionsTestCases(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By section1headingInput => By.Id("section1Heading");
        private By section2headingInput => By.Id("section2Heading");
        private By section3headingInput => By.Id("section3Heading");


        public void ClickHeading1()
        {
            ClickElement(section1headingInput);
        }
        public bool IsHeading1Visible()
        {
            return driver.FindElement(By.Id("section1Heading")).Displayed;
        }

        public void ClickHeading2()
        {
            ClickElement(section2headingInput);
        }
        public bool IsHeading2Visible()
        {
            return driver.FindElement(By.Id("section2Heading")).Displayed;
        }
        public void ClickHeading3()
        {
            ClickElement(section3headingInput);
        }
        public bool IsHeading3Visible()
        {
            return driver.FindElement(By.Id("section3Heading")).Displayed;
        }

        public void ClickElement(By by , int TimeOutInSeconds = 60 )
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeOutInSeconds));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            element.Click();
        }
    }
}
