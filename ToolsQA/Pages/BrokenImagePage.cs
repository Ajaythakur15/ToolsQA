using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsQA.TestPage;

namespace ToolsQA.Pages
{
    public class BrokenImagePage : BasePage
    {
        private IWebDriver driver;
        public BrokenImagePage(IWebDriver driver) : base(driver) 
        {
            this.driver = driver;
        }

        public By ValidLinkId => By.XPath("//a[contains(text(),'Click Here for Valid Link')]");

        public void ClickValidLink()
        {
            ScrollDown(500);
            Click(ValidLinkId);
        }
        public bool IsClickValidLink()
        {
            return driver.FindElement(ValidLinkId).Displayed;
        }
        public int GetBrokenImagesCount()
        {
            int count = 0;
            var images = driver.FindElements(By.TagName("img"));
            foreach(var image in images)
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
        public bool IsImageLoaded(IWebElement image)
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
