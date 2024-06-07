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
    public class RadioBoxTest : BaseTest
    {
        private RadioButtonPage radio;
        [SetUp]
        public void obj()
        {
            radio = new RadioButtonPage(Driver);
        }
        [Test]
        public void CheckYesRadioBtn()
        {
            radio.ClickYes();
            Assert.IsFalse(radio.isYesRadio(), "Yes radio is not selected");
        }
        [Test]
        public void CheckImpresiveRadioBtn()
        {
            radio.ClickImpressive();
            Assert.IsFalse(radio.isImpressive(), "Impressive radio is not selected");
        }
        [Test]
        public void CheckNoRadioBtn()
        {
            radio.ClickNo();
            Assert.IsFalse(radio.isNo(), "No button should be disabled");

        }

    }
}
