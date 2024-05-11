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
        private readonly string _baseUrl = Constants.BaseUrl;

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(_baseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
