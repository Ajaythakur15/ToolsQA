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
            Assert.IsTrue(linksPath.IsClickHome(), "Home Link should be clicked");



        }
        [Test]
        public void ClickNextHome()
        {
            LinksPath linksPath = new LinksPath(driver);
            linksPath.ClickNextHome();
            Assert.IsTrue(linksPath.IsClickNextHome(), "Home Link should be clicked");
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
        public bool IsClickHome()
        {
            return driver.FindElement(By.XPath("//a[@id='simpleLink']")).Displayed;
        }


        public void ClickNextHome()
        {
            ClickElememnt(By.XPath("//a[@id='dynamicLink']"));
        }

        public bool IsClickNextHome()
        {
            return driver.FindElement(By.XPath("//a[@id='dynamicLink']")).Displayed;
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
