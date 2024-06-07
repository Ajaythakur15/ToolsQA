
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsQA.TestPage;

namespace ToolsQA.Pages
{
    public class RadioButtonPage : BasePage
    {
        private IWebDriver driver;
        public RadioButtonPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        private By YesRadio => By.XPath("//label[contains(text(),'Yes')]");
        private By ImpressiveRadio => By.XPath("//label[contains(text(),'Impressive')]");
        private By NoRadio => By.XPath("//label[contains(text(),'No')]");

        public void ClickYes()
        {
            Click(YesRadio);
        }
        public bool isYesRadio()
        {
            return driver.FindElement(YesRadio).Selected;
        }
        public void ClickImpressive()
        {
            Click(ImpressiveRadio);
        }
        public bool isImpressive()
        {
            return driver.FindElement(ImpressiveRadio).Selected;
        }
        public void ClickNo()
        {
            Click(NoRadio);
        }
        public bool isNo()
        {
            return driver.FindElement(NoRadio).Selected;
        }
    }
}
