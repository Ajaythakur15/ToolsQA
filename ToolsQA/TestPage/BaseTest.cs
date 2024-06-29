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
        //private readonly string _baseUrl3 = Constants.BaseUrl3;
        /*private readonly string _baseUrl4 = Constants.BaseUrl4;*/
       // private readonly string _baseUrl5 = Constants.BaseUrl5;
       // private readonly string _baseUrl6 = Constants.BaseUrl6;
        private readonly string _baseUrl8 = Constants.BaseUrl8;

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            //Driver.Navigate().GoToUrl(_baseUrl);
            // Driver.Navigate().GoToUrl(_baseUrl2);
            //Driver.Navigate().GoToUrl(_baseUrl3);
            /*Driver.Navigate().GoToUrl(_baseUrl4);*/
           // Driver.Navigate().GoToUrl(_baseUrl5);
           // Driver.Navigate().GoToUrl(_baseUrl6);
            Driver.Navigate().GoToUrl(_baseUrl8);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
