using NUnit.Framework;
using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;

namespace ToolsQA
{
    [TestFixture]
    public class ReadFromExcel
    {
        private IWebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        public static IEnumerable<object[]> ReadExcel()
        {
            // Create worksheet object
            string filePath = "Data.xlsx";
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found: {filePath}");
            }

            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["sheet1"];
                int rowCount = worksheet.Dimension.End.Row;
                for (int i = 2; i <= rowCount; i++)
                {
                    yield return new object[]
                    {
                        worksheet.Cells[i, 1].Value?.ToString().Trim(), // FirstName
                        worksheet.Cells[i, 2].Value?.ToString().Trim(), // LastName
                        worksheet.Cells[i, 3].Value?.ToString().Trim(), // Email
                        worksheet.Cells[i, 4].Value?.ToString().Trim(), // Age
                        worksheet.Cells[i, 5].Value?.ToString().Trim(), // Salary
                        worksheet.Cells[i, 6].Value?.ToString().Trim()  // Department
                    };
                }
            }
        }

        [TestCaseSource(nameof(ReadExcel))]
        [Test]
        public void DataDrivenUsingExcel(string fname, string lname, string email, string age, string salary, string department)
        {
            driver.Navigate().GoToUrl("https://demoqa.com/webtables");

            StartPage startPage = new StartPage(driver);
            startPage.ClickAdd();

            driver.FindElement(By.Id("firstName")).SendKeys(fname);
            driver.FindElement(By.Id("lastName")).SendKeys(lname);
            driver.FindElement(By.Id("userEmail")).SendKeys(email);
            driver.FindElement(By.Id("age")).SendKeys(age);
            driver.FindElement(By.Id("salary")).SendKeys(salary);
            driver.FindElement(By.Id("department")).SendKeys(department);

            driver.FindElement(By.Id("submit")).Click();
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }

    public class StartPage
    {
        private readonly IWebDriver driver;

        public StartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickAdd()
        {
            driver.FindElement(By.Id("addNewRecordButton")).Click();
        }
    }
}