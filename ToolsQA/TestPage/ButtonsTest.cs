using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsQA.Pages;

namespace ToolsQA.TestPage
{
    public class ButtonsTest : BaseTest
    {
        

        public ButtonsPage buttonpage;

        [SetUp]
        public void obj()
        {
            buttonpage = new ButtonsPage(Driver);
        }
        [Test]
        public void DoubleClick()
        {
            buttonpage.ClickDoubleBtn();
            Assert.IsTrue(buttonpage.IsDoubleBtnVisible(),"Double click button is not visible");
        }
        [Test]
        public void RightClick()
        {
            buttonpage.ClickRightClickBtn();
            Assert.IsTrue(buttonpage.IsRightBtnVisible(),"Right click button is not visible");
        }
        [Test]
        public void SimpleClick()
        {
            buttonpage.ClickClickMeBtn();
            Assert.IsTrue(buttonpage.IsClickMeBtnVisible(),"Simpleclick button is visible");
        }
    }
}
