using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using ToolsQA.BasePage;
using static ToolsQA.WebTablesPage;
using static ToolsQA.webTableValues;

namespace ToolsQA
{
    [TestFixture]
    public class WebtablesUsingDD
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/webtables");
            ScrollPage(500);
        }

        [Test]
        public void FillInputBoxValues()
        {
            webTableValues webvalue = new webTableValues(driver);
            webvalue.ClickAddbtn();
            webvalue.FillInputValues();


        }
        [Test]
        public void VerifyHeader()
        {
            webTableValues web = new webTableValues(driver);
            var headers = web.GetTableHeader();

            List<string> expectedHeaders = new List<string>
            {
                "First Name",
                "Last Name",
                "Age",
                "Email",
                "Salary",
                "Department",
                "Action"
            };
            Assert.AreEqual(expectedHeaders.Count,headers.Count,"Headers are not matched");

            foreach(var eh in expectedHeaders )
            {
                Assert.IsTrue(headers.Contains(eh),$"{eh} is missing");
            }
            
        }

        [Test]
        public void VerifyTableRowData()
        {
            webTableValues web = new webTableValues(driver);
            var rowData = web.RowDataValue();

            Assert.AreEqual("Cierra", rowData.FirstName, "Incorrect FirstName");
            Assert.AreEqual("Vega", rowData.LastName, "Incorrect LastName");
            Assert.AreEqual("39", rowData.Age, "Incorrect Email");
            Assert.AreEqual("cierra@example.com", rowData.Email, "Incorrect Age");
            Assert.AreEqual("10000", rowData.Salary, "Incorrect Salary");
            Assert.AreEqual("Insurance", rowData.Department, "Incorrect Department");

        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }

        private void ScrollPage(int yOffset)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0, {yOffset});");
        }
    }

    public class webTableValues
    {
        private IWebDriver driver;
        
        public webTableValues(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ClickAddbtn()
        {
            driver.FindElement(By.XPath("//button[@id='addNewRecordButton']")).Click();
        }

        public void FillInputValues()
        {
            InputValues testdata = new InputValues
            {
                FirstName = "Prachi",
                LastName = "Sharma",
                Email = "prachi@gmail.com",
                Age = "22",
                Salary = "50000",
                Department = "IT"
            };
            FillInputBoxes(driver, testdata);
            driver.FindElement(By.XPath("//button[@id='submit']")).Click();
        }
        public void FillInputBoxes(IWebDriver driver, InputValues testData)
        {
            driver.FindElement(By.Id("firstName")).SendKeys(testData.FirstName);
            driver.FindElement(By.Id("lastName")).SendKeys(testData.LastName);
            driver.FindElement(By.Id("userEmail")).SendKeys(testData.Email);
            driver.FindElement(By.Id("age")).SendKeys(testData.Age);
            driver.FindElement(By.Id("salary")).SendKeys(testData.Salary);
            driver.FindElement(By.Id("department")).SendKeys(testData.Department);
        }

        public class InputValues
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Age { get; set; }
            public string Email { get; set; }
            public string Salary { get; set; }
            public string Department { get; set; }
        }

        public IReadOnlyList<string> GetTableHeader()
        {
            var headers = driver.FindElements(By.CssSelector("div.rt-th"));
            return headers.Select(header => header.Text).ToList();
        }

        /*        public TableRowData RowDataValue()
                {
                    var cells = driver.FindElements(By.CssSelector("div.rt-td"));
                    if(cells.Count >= 6)
                    {
                        return new TableRowData
                        {
                            FirstName = cells[0].Text,
                            LastName = cells[1].Text,
                            Age = cells[2].Text,
                            Email = cells[3].Text,
                            Salary = cells[4].Text,
                            Department = cells[5].Text
                        };
                    }
                    else
                    {
                        return new TableRowData();
                    }

                }
        */
        public InputValues RowDataValue()
        {
            var cells = driver.FindElements(By.CssSelector("div.rt-td"));
            if (cells.Count >= 6)
            {
                return new InputValues
                {
                    FirstName = cells[0].Text,
                    LastName = cells[1].Text,
                    Age = cells[2].Text,
                    Email = cells[3].Text,
                    Salary = cells[4].Text,
                    Department = cells[5].Text
                };
            }
            else
            {
                return new InputValues();
            }

        }


    }
}
