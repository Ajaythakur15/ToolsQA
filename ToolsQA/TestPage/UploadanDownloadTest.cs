using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsQA.Pages;

namespace ToolsQA.TestPage
{
    public class UploadanDownloadTest : BaseTest
    {
        private UploadandDownloadPage Upload;


        [SetUp]
        public void obj()
        {
            Upload = new UploadandDownloadPage(Driver);
        }
        [Test]
        public void TestLink() 
        {
            Upload.ClickDwnBtn();
            Assert.IsTrue(Upload.IsClickDwnBtn(),"Button is not visible after click");
        }
        [Test]
        public void TestChoose() 
        {
            Assert.IsTrue(Upload.IsClickChoose(),"Choose file button is not displaying");
            Upload.ClickChoose();
        }
         
    }
    
}
