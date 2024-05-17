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
    public class WriteDataInExcel
    {
        [Test]
        public void AddDataFromWebpageToExcel()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/webtables");
            driver.Manage().Window.Maximize();
            //ScrollPage(500);

            var rows = driver.FindElements(By.CssSelector("div.rt-td"));
                /*string FirstName = cells[0].Text;
                string LastName = cells[1].Text;
                string Age = cells[2].Text;
                string Email = cells[3].Text;
                string Salary = cells[4].Text;
                string department = cells[5].Text;*/



            using (ExcelPackage package = new ExcelPackage(new FileInfo("Data.xlsx")))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["sheet2"];
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
            driver.Quit();
        }
    }


   
}
