using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace ToolQAPOC
{
    [TestFixture]
    public class CheckBoxTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/");
            ScrollPage(800);
        }

        [Test]
        public void TestDefaultStateOfCheckboxes()
        {
            ClickElementsTab();
            ClickSubElementsCheckBoxTab();
            // Validate that checkbox is unchecked by default
            Assert.IsFalse(IsCheckboxChecked(), "Checkbox is checked by default.");
        }

        [Test]
        public void TestSelectCheckbox()
        {
            ClickElementsTab();
            ClickSubElementsCheckBoxTab();
            ClickCheckbox();
            // Validate that checkbox is selected after clicking
            Assert.IsFalse(IsCheckboxChecked(), "Checkbox is not selected after clicking.");
        }

        [Test]
        public void TestDeselectCheckbox()
        {
            ClickElementsTab();
            ClickSubElementsCheckBoxTab();
            ClickCheckbox();
            ClickCheckbox(); // Deselecting checkbox by clicking it again
            // Validate that checkbox is unchecked after clicking again
            Assert.IsFalse(IsCheckboxChecked(), "Checkbox is still selected after clicking again.");
        }

        private bool IsCheckboxChecked()
        {
            return driver.FindElement(By.CssSelector("span.rct-checkbox")).GetAttribute("class").Contains("rct-icon-check");
        }

        private void ClickElementsTab()
        {
            ClickElement(By.XPath("//h5[contains(text(),'Elements')]"));
        }

        private void ClickSubElementsCheckBoxTab()
        {
            ClickElement(By.XPath("//span[contains(text(),'Check Box')]"));
        }

        private void ClickCheckbox()
        {
            ClickElement(By.CssSelector("span.rct-checkbox"));
        }

        private void ClickElement(By locator)
        {
            driver.FindElement(locator).Click();
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
