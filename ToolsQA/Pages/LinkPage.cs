using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.Pages
{
    public class LinkPage : BasePage
    {
        private IWebDriver driver;
        public LinkPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        private By HomeLinkId => By.XPath("//a[@id='simpleLink']");
        private By HomeDynamicId => By.XPath("//a[@id='dynamicLink']");
        private By ForbiddenId => By.Id("forbidden");
        private By BadRequest => By.Id("bad-request");

        public void ClickHomeLink()
        {
            ScrollDown(300);
            Click(HomeLinkId);
        }
        public bool IsClickHomeLink()
        {
            return driver.FindElement(HomeLinkId).Displayed;
        }
        public void ClickHomeDynamicId()
        {
            ScrollDown(300);
            Click(HomeDynamicId);
        }
        public bool IsClickHomeDynamicLink()
        {
            return driver.FindElement(HomeDynamicId).Displayed;
        }
        public void ClickForbiddenLink()
        {
            ScrollDown(500);
            Click(ForbiddenId);
        }
        public bool IsClickForbiddenLink()
        {
            return driver.FindElement(ForbiddenId).Displayed;
        }
        public void ClickBadLink()
        {
            ScrollDown(500);
            Click(BadRequest);
        }
        public bool IsClickBadLink()
        {
            return driver.FindElement(BadRequest).Displayed;
        }
    }
}
