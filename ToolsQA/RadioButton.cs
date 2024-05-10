using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace DemoQATests
{
    [TestFixture]
    public class RadioButtonTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/radio-button");
            ScrollPage(600);
        }

        [Test]
        public void VerifyDefaultSelection()
        {
            RadioButtonPage radioButtonPage = new RadioButtonPage(driver);

            // Verify the default selection of the radio button
            Assert.IsFalse(radioButtonPage.FirstRadioButtonIsSelected(), "First radio button should be selected by default.");
        }

        [Test]
        public void SelectSecondRadioButton()
        {
            RadioButtonPage radioButtonPage = new RadioButtonPage(driver);

            // Select the second radio button
            radioButtonPage.SelectSecondRadioButton();

            // Verify that the second radio button is selected
            Assert.IsFalse(radioButtonPage.SecondRadioButtonIsSelected(), "Second radio button should be selected.");
        }

        [Test]
        public void SelectThirdRadioButton()
        {
            RadioButtonPage radioButtonPage = new RadioButtonPage(driver);

            // Select the third radio button
            radioButtonPage.SelectThirdRadioButton();

            // Verify that the third radio button is selected
            Assert.IsFalse(radioButtonPage.ThirdRadioButtonIsSelected(), "Third radio button should be selected.");
        }

        [Test]
        public void SelectRadioButtonByLabel()
        {
            RadioButtonPage radioButtonPage = new RadioButtonPage(driver);

            // Select the radio button by its label
            radioButtonPage.SelectRadioButtonByLabel("Yes");

            // Verify that the radio button with label "Yes" is selected
            Assert.IsTrue(radioButtonPage.IsRadioButtonSelectedByLabel("Yes"), "Radio button with label 'Yes' should be selected.");
        }
        [Test]
        public void SelectRadioButtonByLabel1()
        {
            RadioButtonPage radioButtonPage = new RadioButtonPage(driver);
            radioButtonPage.SelectRadioButtonByLabel("Impressive");
            Assert.IsFalse(radioButtonPage.IsRadioButtonSelectedByLabel("Impressive"), "Radio button with label 'Impressive' should be selected.");
        }
        [Test]
        public void SelectRadioButtonByLabel2()
        {
            RadioButtonPage radioButtonPage = new RadioButtonPage(driver);
            radioButtonPage.SelectRadioButtonByLabel("No");
            Assert.IsFalse(radioButtonPage.IsRadioButtonSelectedByLabel("No"), "Radio button with label 'No' should be selected.");
        }

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

    public class RadioButtonPage
    {
        private IWebDriver driver;

        public RadioButtonPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool FirstRadioButtonIsSelected()
        {
            return driver.FindElement(By.XPath("//label[contains(text(),'Yes')]")).Selected;
        }

        public void SelectSecondRadioButton()
        {
            driver.FindElement(By.XPath("//label[contains(text(),'Impressive')]")).Click();
        }

        public bool SecondRadioButtonIsSelected()
        {
            return driver.FindElement(By.XPath("//label[contains(text(),'Impressive')]")).Selected;
        }

        public void SelectThirdRadioButton()
        {
            driver.FindElement(By.XPath("//label[contains(text(),'No')]")).Click();
        }

        public bool ThirdRadioButtonIsSelected()
        {
            return driver.FindElement(By.XPath("//label[contains(text(),'No')]")).Selected;
        }

        public void SelectRadioButtonByLabel(string label)
        {
            driver.FindElement(By.XPath($"//label[text()='{label}']")).Click();
        }

        public bool IsRadioButtonSelectedByLabel(string label)
        {
            return driver.FindElement(By.XPath($"//label[text()='{label}']/preceding-sibling::input")).Selected;
        }
    }
}
