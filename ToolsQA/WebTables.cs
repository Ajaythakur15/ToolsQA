using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolQAPOC
{
    [TestFixture]
    public class WebTablesButtonTests
    {
        private IWebDriver driver;

        ////SetUp Method
        //1: This method is executed before each test case.
        //2: It initializes the ChromeDriver, maximizes the window, navigates to the specified URL(https://demoqa.com/radio-button), and scrolls the page down by 600 pixels.
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/radio-button");
            //ScrollPage(600);
        }
    }
}
