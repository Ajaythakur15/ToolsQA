using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA
{
    [TestFixture]
    public class WriteDataInExcel
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/webtables");
            ScrollPage(500);

            // Set the license context for EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        [Test]
        public void AddDataFromWebpageToExcel()
        {
            var rows = driver.FindElements(By.CssSelector("div.rt-tbody div.rt-tr-group"));
            string filePath = "Data.xlsx";
            FileInfo file = new FileInfo(filePath);

            using (ExcelPackage package = new ExcelPackage(new FileInfo("Data.xlsx")))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet2"];
                worksheet.Cells[1, 1].Value = "First Name";
                worksheet.Cells[1, 2].Value = "Last Name";
                worksheet.Cells[1, 3].Value = "Age";
                worksheet.Cells[1, 4].Value = "Email";
                worksheet.Cells[1, 5].Value = "Salary";
                worksheet.Cells[1, 6].Value = "Department";

                int rowNumber = 2;    // Start from the second row in Excel
                foreach (var row in rows)
                {
                    var cells = row.FindElements(By.CssSelector("div.rt-td"));
                    if (cells.Count >= 6) // Ensure all columns are present
                    {
                        worksheet.Cells[rowNumber, 1].Value = cells[0].Text;
                        worksheet.Cells[rowNumber, 2].Value = cells[1].Text;
                        worksheet.Cells[rowNumber, 3].Value = cells[2].Text;
                        worksheet.Cells[rowNumber, 4].Value = cells[3].Text;
                        worksheet.Cells[rowNumber, 5].Value = cells[4].Text;
                        worksheet.Cells[rowNumber, 6].Value = cells[5].Text;

                        rowNumber++; // Move to the next row in Excel
                    }
                }

                package.Save();


            }
        }
            private void ScrollPage(int yOffset)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript($"window.scrollBy(0, {yOffset});");
            }

            [TearDown]
            public void Cleanup()
            {
                driver.Quit();
            }
        }
    }

