using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using ToolsQA.BaseConstantPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.TestPage
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver Driver;
       // private readonly string _baseUrl = Constants.BaseUrl;
       // private readonly string _baseUrl2 = Constants.BaseUrl2;
       // private readonly string _baseUrl3 = Constants.BaseUrl3;

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            //Driver.Navigate().GoToUrl(_baseUrl);
            // Driver.Navigate().GoToUrl(_baseUrl2);
            // Driver.Navigate().GoToUrl(_baseUrl3);
            Driver.Navigate().GoToUrl("https://demoqa.com/checkbox");
            ScrollDown(300);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
        public void ScrollDown(int yOffset)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript($"window.scrollBy(0,{yOffset})");
        }
    }
}
