using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V122.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA
{
    [TestFixture]
    public class Links
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/links");
            driver.Manage().Window.Maximize();
            ScrollPage(300);
            
        }
        [Test]
        public void ClickHome()
        {
            LinksPath linksPath = new LinksPath(driver);
            linksPath.ClickHome();
            /*ScrollPage(400);
            linksPath.BackToLinkPage();
            ScrollPage(400);
            IWebElement element = driver.FindElement(By.XPath("//span[contains(text(),'Links')"));
            element.Click();*/



        }
        public void ClickNextHome()
        {
            LinksPath linksPath = new LinksPath(driver);
            linksPath.ClickNextHome();
        }
            

        public void ScrollPage(int yOffset)
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
    public class LinksPath
    {
        IWebDriver driver;
        public LinksPath(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ClickHome()
        {
            ClickElememnt(By.XPath("//a[@id='simpleLink']"));
        }
       
        public void ClickNextHome()
        {
            ClickElememnt(By.XPath("//a[@id='dynamicLink']"));
        }
       
        public void ClickElememnt(By locators)
        {
            driver.FindElement(locators).Click();
        }

      /*  public void BackToLinkPage()
        {
            IWebElement ele = driver.FindElement(By.XPath("//h5[contains(text(),'Elements')]"));
            ele.Click();
        }*/

    }
}
