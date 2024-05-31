
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsQA.BasePage;
using ToolsQA.Pages;
using ToolsQA.TestPage;

namespace ToolsQA.TestPage
{
    public class TextBoxTest : BaseTest
       
    {
        private TextBoxPage textpage;
        [SetUp]
        public void Object()
        {
            textpage = new TextBoxPage(Driver);
        }
        [Test]
        public void TextBoxSubmit()
        {
            textpage.FillFullName("Prachi Sharma");
            textpage.FillEmail("prachish74@gmail.com");
            textpage.FillCurrentAddress("Pilkhuwa");
            textpage.FillPermanentAddress("Pilkhuwa");
            textpage.ClickSubmit();

            Assert.AreEqual("Prachi Sharma", textpage.GetTextBoxValue("userName"), "Name does not match");
            Assert.AreEqual("prachish74@gmail.com", textpage.GetTextBoxValue("userEmail"), "Name does not match");
            Assert.AreEqual("Pilkhuwa", textpage.GetTextBoxValue("currentAddress"), "Name does not match");
            Assert.AreEqual("Pilkhuwa", textpage.GetTextBoxValue("permanentAddress"), "Name does not match");

            Assert.IsTrue(textpage.IsBtnDispplyed(), "Button is not displayed");

        }
    }
}
