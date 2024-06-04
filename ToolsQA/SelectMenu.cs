﻿using NUnit.Framework;
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

            Assert.AreEqual("Group 2, option 1", obj.GetSelectedText(obj.SelectValuePath),"not matched");
            Assert.AreEqual("Mrs.", obj.GetSelectedText(obj.SelectOnePath),"not matched");
            Assert.AreEqual("White", obj.GetSelectedText(obj.selectOldSelectMenu),"not matched");
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


        public By SelectValuePath => By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]");
        public By selectvalue => By.XPath("//div[contains(text(),'Group 2, option 1')]");
        public By SelectOnePath => By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/div[4]/div[1]/div[1]/div[1]/div[1]");
        public By selectone => By.XPath("//div[contains(text(),'Mrs.')]");
        public By selectOldSelectMenu => By.XPath("//select[@id='oldSelectMenu']");
        public By selectoldvalue => By.XPath("//option[contains(text(),'White')]");
        public By Multiselect => By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/div[7]/div[1]/div[1]/div[1]/div[1]");
        public By ColourBlue => By.XPath("//div[contains(text(),'Blue')]");
        public By ColourBlack => By.XPath("//div[contains(text(),'Black')]");
        public By ColourGreen => By.XPath("//div[contains(text(),'Green')]");
        public By CarName => By.XPath("//option[contains(text(),'Audi')]");




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
         public string GetSelectedText(By path)
         {
            return driver.FindElement(path).GetAttribute("value");
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
