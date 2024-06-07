using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsQA.Pages;

namespace ToolsQA.TestPage
{
   public class LinkTest : BaseTest
    {
        public LinkPage linkpage;

        [SetUp]
        public void obj()
        {
            linkpage = new LinkPage(Driver);
        }
        [Test]
        public void HomeLink()
        {
            linkpage.ClickHomeLink();
            Assert.IsTrue(linkpage.IsClickHomeLink(),"home anchor is visible");
        }
        [Test]
        public void DynamicLink()
        {
            linkpage.ClickHomeDynamicId();
            Assert.IsTrue(linkpage.IsClickHomeDynamicLink(),"Dynamic link is visible");
        }
        [Test]
        public void ForbiddenLink()
        {
            linkpage.ClickForbiddenLink();
            Assert.IsTrue(linkpage.IsClickForbiddenLink(),"Forbidden api is not clicked");
        }
        [Test]
        public void BadLink()
        {
            linkpage.ClickBadLink();
            Assert.IsTrue(linkpage.IsClickBadLink(),"Badlink api is not clicked");
        }
    }
}
