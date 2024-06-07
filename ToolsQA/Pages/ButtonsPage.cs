using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.Pages
{
    public class ButtonsPage : BasePage
    {
        private IWebDriver driver;
        public ButtonsPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        private By doubleclickId => By.Id("doubleClickBtn");
        private By RightClickId => By.Id("rightClickBtn");
        private By ClickMeId => By.XPath("//button[contains(text(),'Click Me')]");

        public void ClickDoubleBtn()
        {
            ScrollDown(300);
            IWebElement element = driver.FindElement(doubleclickId);
            Actions action = new Actions(driver);
            action.DoubleClick(element).Perform();
        }
        public bool IsDoubleBtnVisible()
        {
            return driver.FindElement(doubleclickId).Displayed;
        }
        public void ClickRightClickBtn() 
        {
            ScrollDown(300);
            IWebElement element = driver.FindElement(RightClickId);
            Actions action = new Actions(driver);
            action.ContextClick(element).Perform();
        }
        public bool IsRightBtnVisible()
        {
            return driver.FindElement(RightClickId).Displayed;
        }
        public void ClickClickMeBtn() 
        {
            ScrollDown(300);
            Click(ClickMeId);
        }
        public bool IsClickMeBtnVisible()
        {
            return driver.FindElement(ClickMeId).Displayed;
        }
    }
}
