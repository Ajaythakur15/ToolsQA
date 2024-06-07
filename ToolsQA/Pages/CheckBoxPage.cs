using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;

namespace ToolsQA.Pages
{
    public class CheckBoxPage : BasePage
    {
        private IWebDriver driver;

        public CheckBoxPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public By ClickButton => By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/ol[1]/li[1]/span[1]/button[1]/*[1]");
        public By CheckDownload => By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/ol[1]/li[1]/ol[1]/li[3]/span[1]/label[1]/span[1]");
        public By CheckDocument => By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/ol[1]/li[1]/ol[1]/li[2]/span[1]/label[1]/span[1]/*[1]");
        public By CheckDesktop => By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/ol[1]/li[1]/ol[1]/li[1]/span[1]/label[1]/span[1]/*[1]");
        public By CheckHome => By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/ol[1]/li[1]/span[1]/label[1]/span[1]/*[1]");

        public void ClickOnHomeArrow()
        {
            ScrollDown(300);
            Click(ClickButton);
        }

        public void ClickOnDocument()
        {
            Click(CheckDocument);
        }

        public void ClickOnDownload()
        {
            Click(CheckDownload);
        }

        public void ClickOnDesktop()
        {
            Click(CheckDesktop);
        }

        public bool isDocumentChecked()
        {
            return IsCheckboxChecked(CheckDocument);
        }

        public bool isDownloadChecked()
        {
            return IsCheckboxChecked(CheckDownload);
        }

        public bool isDesktopChecked()
        {
            return IsCheckboxChecked(CheckDesktop);
        }

        public bool isHomecheckClicked()
        {
            return IsCheckboxChecked(CheckHome);
        }

        private bool IsCheckboxChecked(By locator)
        {
            try
            {
                var element = driver.FindElement(locator);
                return element.GetAttribute("class").Contains("rct-icon-check");
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
