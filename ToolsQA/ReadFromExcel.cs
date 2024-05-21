using NUnit.Framework;
using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ToolsQA
{
    [TestFixture]
    public class ReadFromexcel
    {
        private IWebDriver driver;
        [SetUp]
        public void OpenBrowser()
        {
             driver = new ChromeDriver();
        }

        public static IEnumerable<object[]> ReadExcel()
        {
            //create worksheet object
            using (ExcelPackage package = new ExcelPackage(new FileInfo("Data.xlsx")))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["sheet1"];
                int rowcount = worksheet.Dimension.End.Row;
                for (int i = 2; i <= rowcount; i++)
                {
                    yield return new object[] {
                    worksheet.Cells[i, 1].Value?.ToString().Trim(), //FirstName
                    worksheet.Cells[i, 2].Value?.ToString().Trim(),
                    worksheet.Cells[i, 3].Value?.ToString().Trim(),
                    worksheet.Cells[i, 4].Value?.ToString().Trim(),
                    worksheet.Cells[i, 5].Value?.ToString().Trim(),
                    worksheet.Cells[i, 6].Value?.ToString().Trim()
                    };

                }
            }
        }
        [TestCaseSource(nameof(ReadExcel))]
        [Test]
        public void DataDrivenUsingExcel(string fname, string lname, string email, string age, string salary, string department)
        {
           
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/webtables");

            StartPage start = new StartPage(driver);
            start.ClickAdd();

            driver.FindElement(By.Id("firstName")).SendKeys(fname);
            driver.FindElement(By.Id("lastName")).SendKeys(lname);
            driver.FindElement(By.Id("userEmail")).SendKeys(email);
            driver.FindElement(By.Id("age")).SendKeys(age);
            driver.FindElement(By.Id("salary")).SendKeys(salary);
            driver.FindElement(By.Id("department")).SendKeys(department);

           

        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
    public class StartPage
    {
        private IWebDriver driver;

        public StartPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ClickAdd()
        {

            driver.FindElement(By.XPath("//button[@id='addNewRecordButton']")).Click();
        }
    }
}      

