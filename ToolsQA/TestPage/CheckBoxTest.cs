using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsQA.Pages;
using ToolsQA.TestPage;
using ToolsQA.BasePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.DevTools.V122.DOM;

namespace ToolsQA.TestPage
{
    public class CheckBoxTest : BaseTest
    {
        private CheckBoxPage checkbox;
        [SetUp]
        public void Obj()
        {
            checkbox = new CheckBoxPage(Driver);
        }
        [Test]
        public void Checkbox()
        {
            checkbox.ClickOnHomeArrow();
            checkbox.ClickOnDownload();
            checkbox.ClickOnDocument();
            checkbox.ClickOnDesktop();


            Assert.IsTrue(checkbox.isDownloadChecked(), "Download checkbox is left for checked");
            Assert.IsTrue(checkbox.isDocumentChecked(), "Document checkbox is not checked");
            Assert.IsTrue(checkbox.isDesktopChecked(), "Desktop checkbox is not checked");
            Assert.IsTrue(checkbox.isHomecheckClicked(), "Some checkbox is left for checked");

        }

    }
}
