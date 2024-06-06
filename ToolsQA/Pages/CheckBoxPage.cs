using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsQA.Pages
{
    public class CheckBoxPage : BasePage
    {
        private IWebDriver driver;
        public CheckBoxPage (IWebDriver driver) : base(driver)
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
            try
            {
                return driver.FindElement(CheckDocument).Selected;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool isDownloadChecked()
        {
            try
            {
                return driver.FindElement(CheckDownload).Selected;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool isDesktopChecked()
        {
            try
            {
                return driver.FindElement(CheckDesktop).Selected;
            }
            
             catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool isHomecheckClicked()
        {
            try
            {
                return driver.FindElement(CheckHome).Selected;
            }
           
             catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
