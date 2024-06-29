using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.Pages
{
    public class UploadandDownloadPage : BasePage
    {
        private IWebDriver driver;
        public UploadandDownloadPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        private By downBtn => By.XPath("//a[@id='downloadButton']");
        private By choose => By.Id("uploadFile");
        

        public void ClickDwnBtn()
        {
            ScrollDown(300);
            Click(downBtn);
        }
        public bool IsClickDwnBtn()
        {
            return driver.FindElement(downBtn).Displayed;
        }
        public void ClickChoose()
        {
            ScrollDown(300);
            var uploadfile = driver.FindElement(choose);
            uploadfile.SendKeys(Path.GetFullPath("E:\\Automation_Testing\\File.txt"));
        }

        public bool IsClickChoose()
        {
            return driver.FindElement(choose).Displayed;
        }
    }
}
