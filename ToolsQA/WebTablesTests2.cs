using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace ToolsQA
{
    [TestFixture]
    public class WebTablesTests2
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/webtables");

        }

        [Test]
        public void VerifyTableHeaders()
        {
            WebTablesPage webTablesPage = new WebTablesPage(driver);
            var headers = webTablesPage.GetTableHeaders();

            Assert.AreEqual(6, headers.Count, "Incorrect number of table headers");

            Assert.IsTrue(headers.Contains("Firstname"), "Firstname header not found");
            Assert.IsTrue(headers.Contains("Lastname"), "Lastname header not found");
            Assert.IsTrue(headers.Contains("Email"), "Email header not found");
            Assert.IsTrue(headers.Contains("Age"), "Age header not found");
            Assert.IsTrue(headers.Contains("Salary"), "Salary header not found");
            Assert.IsTrue(headers.Contains("Department"), "Department header not found");
        }

        [Test]
        public void VerifyTableRowData()
        {
            WebTablesPage webTablesPage = new WebTablesPage(driver);
            var rowData = webTablesPage.GetTableRowData(1); // Assuming row index starts from 1

            Assert.AreEqual("Cierra", rowData.FirstName, "Incorrect firstname");
            Assert.AreEqual("Vega", rowData.LastName, "Incorrect lastname");
            Assert.AreEqual("cierra@example.com", rowData.Email, "Incorrect email");
            Assert.AreEqual("39", rowData.Age, "Incorrect age");
            Assert.AreEqual("$75,000", rowData.Salary, "Incorrect salary");
            Assert.AreEqual("Software Engineer", rowData.Department, "Incorrect department");
        }

        [Test]
        public void AddNewEmployee()
        {
            WebTablesPage webTablesPage = new WebTablesPage(driver);
            webTablesPage.AddNewEmployee("John", "Doe", "john@example.com", "35", "$80,000", "IT");

            // Verify that the new employee is added successfully
            var rowData = webTablesPage.GetTableRowData(11); // Assuming row index starts from 1 and there are 10 existing rows
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
    }

    public class WebTablesPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public WebTablesPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IReadOnlyList<string> GetTableHeaders()
        {
            var headers = driver.FindElements(By.CssSelector("#app > div > div > div.pattern-backgound.playgound-header > div > div > div > div.rt-table > div > div.rt-thead.-header > div > div"));
            return headers.Select(header => header.Text).ToList();
        }

        public TableRowData GetTableRowData(int rowIndex)
        {
            var row = driver.FindElement(By.CssSelector($"#app > div > div > div.pattern-backgound.playgound-header > div > div > div > div.rt-table > div > div.rt-tbody > div:nth-child({rowIndex})"));
            var cells = row.FindElements(By.CssSelector("div"));

            return new TableRowData
            {
                FirstName = cells[0].Text,
                LastName = cells[1].Text,
                Email = cells[2].Text,
                Age = cells[3].Text,
                Salary = cells[4].Text,
                Department = cells[5].Text
            };
        }

        public void AddNewEmployee(string firstName, string lastName, string email, string age, string salary, string department)
        {
            var addButton = driver.FindElement(By.CssSelector("#addNewRecordButton"));
            addButton.Click();

            var firstNameField = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("firstName")));
            var lastNameField = driver.FindElement(By.Id("lastName"));
            var emailField = driver.FindElement(By.Id("userEmail"));
            var ageField = driver.FindElement(By.Id("age"));
            var salaryField = driver.FindElement(By.Id("salary"));
            var departmentField = driver.FindElement(By.Id("department"));
            var submitButton = driver.FindElement(By.Id("submit"));

            firstNameField.SendKeys(firstName);
            lastNameField.SendKeys(lastName);
            emailField.SendKeys(email);
            ageField.SendKeys(age);
            salaryField.SendKeys(salary);
            departmentField.SendKeys(department);

            submitButton.Click();
        }
    }

    public class TableRowData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Salary { get; set; }
        public string Department { get; set; }
    }
}
