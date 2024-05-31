using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.Pages
{
    public class TextBoxPage: BasePage
    {
        private IWebDriver driver;
        public TextBoxPage (IWebDriver driver) : base(driver) { }

        private By NameId => By.Id("userName");
        private By EmailId => By.Id("userEmail");
        private By CurrAdd => By.Id("currentAddress");
        private By PerAdd => By.Id("permanentAddress");
        private By SubmitId => By.Id("submit");

        public void FillFullName(string text)
        {
            SendKeys(NameId, text);
        }
        public void FillEmail(string text)
        {
            SendKeys(EmailId, text);
        }
        public void FillCurrentAddress(string text)
        {
            SendKeys(CurrAdd,text);
        }
        public void FillPermanentAddress(string text)
        {
            SendKeys(PerAdd, text);
        }
        public void ClickSubmit()
        {
            Click(SubmitId);
        }
        public string GetTextBoxValue(string id) 
        {
            return driver.FindElement(By.Id(id)).GetAttribute("value");
        }
        public bool IsBtnDispplyed()
        {
            return driver.FindElement(SubmitId).Displayed;
        }
    }
}
