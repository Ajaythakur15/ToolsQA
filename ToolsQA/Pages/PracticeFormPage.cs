using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ToolsQA.Pages
{
    public class PracticeFormPage : BasePage
    {
        public PracticeFormPage(IWebDriver driver) : base(driver) { }

        // Locators
        private By FirstNameInput => By.Id("firstName");
        private By LastNameInput => By.Id("lastName");
        private By EmailInput => By.Id("userEmail");
        private By GenderRadio(string gender) => By.XPath($"//label[text()='{gender}']");
        private By MobileNumberInput => By.Id("userNumber");
        private By DateOfBirthInput => By.Id("dateOfBirthInput");
        private By SubjectsInput => By.Id("subjectsInput");
        private By HobbiesCheckbox(string hobby) => By.XPath($"//label[text()='{hobby}']");
        private By UploadPictureButton => By.Id("uploadPicture");
        private By CurrentAddressInput => By.Id("currentAddress");
        private By StateDropdown => By.Id("state");
        private By CityDropdown => By.Id("city");
        private By SubmitButton => By.Id("submit");

        // Methods
        public void FillFirstName(string firstName)
        {
            SendKeys(FirstNameInput, firstName);
        }

        public void FillLastName(string lastName)
        {
            SendKeys(LastNameInput, lastName);
        }

        public void FillEmail(string email)
        {
            SendKeys(EmailInput, email);
        }

        public void SelectGender(string gender)
        {
            Click(GenderRadio(gender));
        }

        public void FillMobileNumber(string mobileNumber)
        {
            SendKeys(MobileNumberInput, mobileNumber);
        }

        public void SelectDateOfBirth(string dateOfBirth)
        {
            ScrollDown(200);
            var dateInput = GetElement(DateOfBirthInput);
            dateInput.Click();
            dateInput.Clear();
            dateInput.SendKeys(dateOfBirth);
            dateInput.SendKeys(Keys.Enter);
        }

        public void AddSubjects(string subjects)
        {
            ScrollDown(100);
            var subjectsInput = GetElement(SubjectsInput);
            foreach (var subject in subjects.Split(','))
            {
                subjectsInput.SendKeys(subject.Trim());
                subjectsInput.SendKeys(Keys.Enter);
            }
        }

        public void SelectHobbies(string hobbies)
        {
            ScrollDown(100);
            foreach (var hobby in hobbies.Split(','))
            {
                Click(HobbiesCheckbox(hobby.Trim()));
            }
        }

        public void UploadPicture(string filePath)
        {
            SendKeys(UploadPictureButton, filePath);
        }

        public void FillCurrentAddress(string address)
        {
            SendKeys(CurrentAddressInput, address);
        }

        public void SelectState(string state)
        {
            Click(StateDropdown);
            Click(By.XPath($"//div[text()='{state}']"));
        }

        public void SelectCity(string city)
        {
            Click(CityDropdown);
            Click(By.XPath($"//div[text()='{city}']"));
        }

        public void SubmitForm()
        {
            Click(SubmitButton);
        }
    }
}