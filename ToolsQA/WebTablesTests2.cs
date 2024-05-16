using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ToolsQA
{
    [TestFixture]
    public class WebTablesTests2
    {
        private IWebDriver driver;
        private const string baseUrl = "https://demoqa.com/webtables";
        private const int yOffset = 400;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseUrl);
            ScrollPage(yOffset);
        }

        [Test]
        public void VerifyTableHeaders()
        {
            var webTablesPage = new WebTablesPage(driver);
            var headers = webTablesPage.GetTableHeaders();

            Assert.AreEqual(7, headers.Count, "Incorrect number of table headers");
            Assert.IsFalse(headers.All(h => h.Contains("Firstname") || h.Contains("Lastname") || h.Contains("Email") || h.Contains("Age") || h.Contains("Salary") || h.Contains("Department")), "Some headers are missing or incorrect");
        }

        [Test]
        public void VerifyTableRowData()
        {
            var webTablesPage = new WebTablesPage(driver);
            var rowData = webTablesPage.GetTableRowData(1);

            Assert.AreEqual("Cierra", rowData.FirstName, "Incorrect firstname");
            Assert.AreEqual("Vega", rowData.LastName, "Incorrect lastname");
            Assert.AreEqual("cierra@example.com", rowData.Email, "Incorrect email");
            Assert.AreEqual("39", rowData.Age, "Incorrect age");
            Assert.AreEqual("Insurance", rowData.Department, "Incorrect department");
        }

        [Test]
        public void AddNewEmployee()
        {
            var webTablesPage = new WebTablesPage(driver);
            webTablesPage.AddNewEmployee("John", "Doe", "john@example.com", "35", "$80,000", "IT");

            var rowData = webTablesPage.GetTableRowData(11);
            Assert.AreEqual("John", rowData.FirstName, "Incorrect firstname for newly added employee");
            Assert.AreEqual("Doe", rowData.LastName, "Incorrect lastname for newly added employee");
            Assert.AreEqual("john@example.com", rowData.Email, "Incorrect email for newly added employee");
            Assert.AreEqual("35", rowData.Age, "Incorrect age for newly added employee");
            Assert.AreEqual("$80,000", rowData.Salary, "Incorrect salary for newly added employee");
            Assert.AreEqual("IT", rowData.Department, "Incorrect department for newly added employee");
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }

        private void ScrollPage(int yOffset)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0, {yOffset});");
        }
    }

    public class WebTablesPage
    {
        private IWebDriver driver;
        private readonly By addNewRecordButton = By.Id("addNewRecordButton");
        private readonly By inputFields = By.XPath("//div[@class='rt-tr-group']//input");
        private readonly By submitButton = By.Id("submit");

        public WebTablesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IReadOnlyList<string> GetTableHeaders()
        {
            var headers = driver.FindElements(By.CssSelector("div.rt-th"));
            return headers.Select(header => header.Text).ToList();
        }

        public TableRowData GetTableRowData(int rowIndex)
        {
            var row = driver.FindElement(By.CssSelector($"div.rt-tbody > div:nth-child({rowIndex})"));
            var cells = row.FindElements(By.CssSelector("div.rt-td"));

            if (cells.Count >= 6)
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

        public void AddNewEmployee(string firstName, string lastName, string email, string age, string salary, string department)
        {
            driver.FindElement(addNewRecordButton).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(inputFields));

            var inputs = driver.FindElements(inputFields);

            if (inputs.Count >= 6)
            {
                inputs[0].SendKeys(firstName);
                inputs[1].SendKeys(lastName);
                inputs[2].SendKeys(age);
                inputs[3].SendKeys(email);
                inputs[4].SendKeys(salary);
                inputs[5].SendKeys(department);

                driver.FindElement(submitButton).Click();
            }
            else
            {
                throw new NoSuchElementException("Expected number of input fields not found");
            }
        }
        //data source
        public class TableRowData
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Age { get; set; }
            public string Email { get; set; }
            public string Salary { get; set; }
            public string Department { get; set; }
        }
    }
}
