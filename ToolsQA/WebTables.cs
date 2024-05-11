using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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
        //2: It initializes the ChromeDriver, maximizes the window, navigates to the specified URL(https://demoqa.com/webtables), and scrolls the page down by 600 pixels.
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/webtables");
            ScrollPage(600);
        }
        [Test]
        public void VerifyTableHeaders()
        {
            // Verify the headers of the web table
            string[] expectedHeaders = { "First Name", "Last Name", "Age", "Email", "Salary", "Department" };
            IWebElement table = driver.FindElement(By.ClassName("tsc_table_s13"));
            IWebElement headerRow = table.FindElement(By.TagName("thead")).FindElement(By.TagName("tr"));
            IList<IWebElement> headerCells = headerRow.FindElements(By.TagName("th"));

            Assert.AreEqual(expectedHeaders.Length, headerCells.Count);

            for (int i = 0; i < expectedHeaders.Length; i++)
            {
                Assert.AreEqual(expectedHeaders[i], headerCells[i].Text.Trim());
            }
        }

        [Test]
        public void VerifyTableRowCount()
        {
            // Verify the total number of rows in the web table
            int expectedRowCount = 5; // Assuming there are 5 rows in the table
            IWebElement tableBody = driver.FindElement(By.ClassName("tsc_table_s13")).FindElement(By.TagName("tbody"));
            IList<IWebElement> rows = tableBody.FindElements(By.TagName("tr"));

            Assert.AreEqual(expectedRowCount, rows.Count);
        }

        [Test]
        public void VerifyTableCellValue()
        {
            // Verify the value of a specific cell in the web table
            string expectedValue = "John";
            IWebElement tableBody = driver.FindElement(By.ClassName("tsc_table_s13")).FindElement(By.TagName("tbody"));
            IWebElement cell = tableBody.FindElement(By.XPath("//td[contains(text(), 'John')]"));

            Assert.AreEqual(expectedValue, cell.Text.Trim());
        }
        //Helper Methods(WaitForElementClickable, WaitForElementDisplayed, ScrollPage):
        //1: These methods are used for common tasks like waiting for elements to be clickable or displayed, and scrolling the page.
        //2: WaitForElementClickable waits for an element to be clickable within a specified timeout.
        //3: WaitForElementDisplayed waits for an element to be displayed within a specified timeout.
        //4: ScrollPage scrolls the page by a specified yOffset.
        private IWebElement WaitForElementClickable(By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        private bool WaitForElementDisplayed(By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            try
            {
                return wait.Until(driver => driver.FindElement(locator).Displayed);
            }
            catch (NoSuchElementException)
            {
                return false;
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

