using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsQA.Pages;

namespace ToolsQA.TestPage
{
    public class BrokenImageTest : BaseTest
    {
        private BrokenImagePage broken;

        [SetUp]
        public void obj()
        {
            broken = new BrokenImagePage(Driver);
        }
        [Test]
        public void TestLink()
        {
            //broken.ClickValidLink();
            Assert.IsFalse(broken.IsClickValidLink(),"Link is not visible");
        }
        [Test]
        public void TestBrokenImagesCount()
        {
            Assert.AreEqual(1,broken.GetBrokenImagesCount(),"images are not broken");
        }
        [Test]
        public void TestBrokenImageSrc()
        {
            Assert.IsTrue(broken.AreImagesBroken(),"some images are not broken");
        }
       
    }
}
