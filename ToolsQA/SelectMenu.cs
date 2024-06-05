using Microsoft.Office.Interop.Excel;
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
using static Microsoft.IO.RecyclableMemoryStreamManager;

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

            Assert.AreEqual("Group 2, option 1", obj.GetSelectedText(obj.SelectValuePath),"Value not matched");
            Assert.AreEqual("Mrs.", obj.GetSelectedText(obj.SelectOnePath),"One not matched");
            Assert.AreEqual("White", obj.GetSelectedText(obj.selectoldvalue),"OldOne not matched");
        }

    
        [Test]
        public void MultiDropDowns()
        {
            ScrollDown(400);
            TestCasesMetods obj = new TestCasesMetods(driver);
           
            obj.FillMultiselect();
            Assert.AreEqual("Blue,Black,Green,",obj.GetMultiselect(),"colors does not matched");
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
         public string GetSelectedText(By Path)
         {
            IWebElement element = driver.FindElement(Path);
            return element.Text;
         }
        public void FillMultiselect()
        { 
            ClickElement(Multiselect);
            ClickElement(ColourBlue);
            ClickElement(ColourBlack);
            ClickElement(ColourGreen);
   
        }
        public string GetMultiselect()
        {
            IWebElement element = driver.FindElement(Multiselect);
            IList<IWebElement> selectedOptions = new List<IWebElement>();
            IList<IWebElement> options = element.FindElements(By.XPath(".//div[@class='css-12jo7m5']"));
            foreach (IWebElement option in options)
            {
                selectedOptions.Add(option);
            }
            // Build a comma-separated string of the text of selected options
            StringBuilder selectedText = new StringBuilder();
            foreach (IWebElement option in selectedOptions)
            {
                selectedText.Append(option.Text).Append(",");
            }
            return selectedText.ToString();

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
