using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace ToolsQA
{
   
        [TestFixture]
        public class ButtonsTests
        {
            private IWebDriver driver;

            [SetUp]
            public void Setup()
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://demoqa.com/buttons");
                ScrollPage(400);
            }

        [Test]
        public void TestButtonClick()
        {
            ClickButtonAndVerifyAlert("Click Me", "You clicked a button", TimeSpan.FromSeconds(30));
        }

        private void ClickButtonAndVerifyAlert(string buttonText, string expectedAlertText, TimeSpan timeout)
        {
            IWebElement button = driver.FindElement(By.XPath($"//button[text()='{buttonText}']"));

            if (button != null)
            {
                Actions actions = new Actions(driver);
                actions.MoveToElement(button).Click().Build().Perform();

                WebDriverWait wait = new WebDriverWait(driver, timeout);
                IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());

                Assert.IsNotNull(alert);
                Assert.AreEqual(expectedAlertText, alert.Text);

                alert.Accept();
            }
            else
            {
                Assert.Fail($"Button with text '{buttonText}' not found.");
            }
        }


        [Test]
            public void TestDoubleClick()
            {
                // Find and double click the "Double Click Me" button
                IWebElement doubleClickMeButton = driver.FindElement(By.XPath("//button[text()='Double Click Me']"));
                Actions actions = new Actions(driver);
                actions.DoubleClick(doubleClickMeButton).Build().Perform();

                // Verify that the button double click generates an alert
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
                Assert.IsNotNull(alert);
                Assert.AreEqual("You have done a double click", alert.Text);

                // Close the alert
                alert.Accept();
            }

            [Test]
            public void TestRightClick()
            {
                // Find and right click the "Right Click Me" button
                IWebElement rightClickMeButton = driver.FindElement(By.XPath("//button[text()='Right Click Me']"));
                Actions actions = new Actions(driver);
                actions.ContextClick(rightClickMeButton).Build().Perform();

                // Verify that the button right click generates an alert
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
                Assert.IsNotNull(alert);
                Assert.AreEqual("You have done a right click", alert.Text);

                // Close the alert
                alert.Accept();
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