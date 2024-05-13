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
    internal class BrokenImagesTests
    {
        private IWebDriver driver;

        [SetUp]
        public void setup() 
        { 
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/broken");
        }
        [Test]
        public void TestBrokenImagesCount()
        {
            BrokenImagesPage brokenImagesPage = new BrokenImagesPage(driver);
            int brokenImagesCount = brokenImagesPage.GetBrokenImagesCount();
            Assert.AreEqual(1, brokenImagesCount, "Expected number of broken image is not matching");
        }
        [Test]
        public void TestBrokenImagesSrc()
        {
            BrokenImagesPage brokenImagesPage = new BrokenImagesPage(driver);
            bool areImagesBroken = brokenImagesPage.AreImagesBroken();
            Assert.IsTrue(areImagesBroken, "Some images are not broken as expected");
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
    public class BrokenImagesPage
        {
            private IWebDriver driver;

            public BrokenImagesPage(IWebDriver driver)
            {
                this.driver = driver;
            }

            public int GetBrokenImagesCount()
            {
                int count = 0;
                var images = driver.FindElements(By.TagName("img"));
                foreach (var image in images)
                {
                    if (!IsImageLoaded(image))
                        count++;
                }
                return count;
            }

            public bool AreImagesBroken()
            {
                var images = driver.FindElements(By.TagName("img"));
                foreach (var image in images)
                {
                    if (!IsImageLoaded(image))
                        return true;
                }
                return false;
            }

            private bool IsImageLoaded(IWebElement image)
            {
                try
                {
                    return image.GetAttribute("naturalWidth").Equals("undefined") || Convert.ToInt32(image.GetAttribute("naturalWidth")) > 0;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }
    }
