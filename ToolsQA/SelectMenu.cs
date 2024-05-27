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
    public class SelectMenu
    {
        private IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/select-menu");
            driver.Manage().Window.Maximize();
            ScrollDown(300);
        }
        [Test]
        public void SingleDropdowns()
        {
            TestCasesMetods obj = new TestCasesMetods(driver);
            obj.FillValue();
            obj.FillOne();
            obj.FillOldOne();

        }
        [Test]
        public void MultiDropDowns()
        {
            ScrollDown(400);
            TestCasesMetods obj = new TestCasesMetods(driver);
           
            obj.FillMultiselect();
            obj.FillStandardMultiSelect();
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

    public class TestCasesMetods
    {
        private IWebDriver driver;

        public TestCasesMetods(IWebDriver driver)
        {
            this.driver = driver;
        }


        private By SelectValuePath => By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]");
        private By selectvalue => By.XPath("//div[contains(text(),'Group 2, option 1')]");
        private By SelectOnePath => By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/div[4]/div[1]/div[1]/div[1]/div[1]");
        private By selectone => By.XPath("//div[contains(text(),'Mrs.')]");
        private By selectOldSelectMenu => By.XPath("//select[@id='oldSelectMenu']");
        private By selectoldvalue => By.XPath("//option[contains(text(),'White')]");
        private By Multiselect => By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/div[7]/div[1]/div[1]/div[1]/div[1]");
        private By ColourBlue => By.XPath("//div[contains(text(),'Blue')]");
        private By ColourBlack => By.XPath("//div[contains(text(),'Black')]");
        private By ColourGreen => By.XPath("//div[contains(text(),'Green')]");
        private By CarName => By.XPath("//option[contains(text(),'Audi')]");




        public void FillValue()
        {
            ClickElement(SelectValuePath);
            ClickElement(selectvalue);

        }
        public void FillOne()
        {
            ClickElement(SelectOnePath);
            ClickElement(selectone);
        }
        public void FillOldOne()
        {
            ClickElement(selectOldSelectMenu);
            ClickElement(selectoldvalue);
        }
        public void FillMultiselect()
        {
            ClickElement(Multiselect);
            ClickElement(ColourBlue);
            ClickElement(ColourBlack);
            ClickElement(ColourGreen);
   
        }
        public void FillStandardMultiSelect()
        {
            ClickElement(CarName);
        }
        public void ClickElement(By by, int TimeOutInSeconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeOutInSeconds));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            element.Click();

        }
      
    }
}
