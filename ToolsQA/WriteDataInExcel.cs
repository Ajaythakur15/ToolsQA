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
        
        public void AddDataFromWebpageToExcel()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/webtables");
            driver.Manage().Window.Maximize();
            //ScrollPage(500);

            var cells = driver.FindElements(By.CssSelector("div.rt-td"));
                string FirstName = cells[0].Text;
                string LastName = cells[1].Text;
                string Age = cells[2].Text;
                string Email = cells[3].Text;
                string Salary = cells[4].Text;
                string department = cells[5].Text;



            using (ExcelPackage package = new ExcelPackage(new FileInfo("Data.xlsx")))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["sheet2"];
                int rowcount = worksheet.Dimension.End.Row;
                for (int i = 2; i <= rowcount; i++)
                {
                    worksheet.Cells[i, 1].Value = FirstName;
                    worksheet.Cells[i, 2].Value = LastName;
                    worksheet.Cells[i, 3].Value = Age;
                    worksheet.Cells[i, 4].Value = Email;
                    worksheet.Cells[i, 5].Value = Salary;
                    worksheet.Cells[i, 6].Value = department;
                }
                package.Save();
               

            }
            driver.Quit();
        }
    }


   
}
