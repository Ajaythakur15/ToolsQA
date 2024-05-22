using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ToolsQA.Pages;
using ToolsQA.TestPage;

namespace ToolsQA.Tests
{
    [TestFixture]
    public class PracticeFormTests : BaseTest
    {
        //private IWebDriver driver;
        private PracticeFormPage practiceFormPage;

        [SetUp]
        public void Before()
        {
            practiceFormPage = new PracticeFormPage(Driver);
        }

        [Test(Description = "Verify that a user can submit the form")]
        public void TestSubmitForm()
        {
            practiceFormPage.FillFirstName("John");
            practiceFormPage.FillLastName("Doe");
            practiceFormPage.FillEmail("john.doe@example.com");
            practiceFormPage.SelectGender("Male");
            practiceFormPage.FillMobileNumber("1234567890");
            practiceFormPage.SelectDateOfBirth("20 May 1985");
            practiceFormPage.AddSubjects("Maths, Physics");
            practiceFormPage.SelectHobbies("Sports, Reading");
            practiceFormPage.UploadPicture("C:\\Users\\Techpro-LP1\\Pictures\\galaxy.jpg");
            practiceFormPage.FillCurrentAddress("123 Main St");
            practiceFormPage.SelectState("NCR");
            practiceFormPage.SelectCity("Delhi");
            practiceFormPage.SubmitForm();
            // Add assertions to verify form submission
        }
    }
}