using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA
{
    public class Form
    {
        private IWebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            driver.Manage().Window.Maximize();
            ScrollDown(300);
        }
        [Test]
        public void FillTextBoxValue()
        {
            TestCasesForm obj = new TestCasesForm(driver);
            obj.FillFirstName("Prachi");
            obj.FillLastName("Sharma");
            obj.FillEmail("prachi@gmail.com");
            obj.FillMobileNumber("8283283621");
            obj.FillDOB();
            obj.FillSubjects("Commerce","Biology");
            obj.FillPicture("C:\\Users\\prachi sharma\\Downloads\\sampleFile.jpeg");
            obj.FillCurrAdd("I am From Pilkhuwa");

            Assert.AreEqual("Prachi",obj.GetTextBoxValue("firstName"),"FirstName value does not matched");
            Assert.AreEqual("Sharma",obj.GetTextBoxValue("lastName"),"Last name does not matched");
            Assert.AreEqual("prachi@gmail.com",obj.GetTextBoxValue("userEmail"),"Email does not matched");
            Assert.AreEqual("8283283621",obj.GetTextBoxValue("userNumber"),"Mobile number does not matched");
            Assert.AreEqual("04/05/2001",obj.GetTextBoxValue("dateOfBirthInput"),"Dob does not matched");
            Assert.IsTrue(obj.IsSubjectSelected(),"Subject Commerce does not matched");
            Assert.AreEqual("I am From Pilkhuwa",obj.GetTextBoxValue("currentAddress"),"Address does not matched");

        }
        [Test]
        public void CheckcheckBoxes()
        {
            TestCasesForm obj = new TestCasesForm(driver);
            ScrollDown(300);
            //obj.FillOneCheckBoxInput();
            obj.FillTwoCheckBoxes("Sports, Reading");
            Assert.IsTrue(obj.IsCheckboxChecked(), "Checkbox is not checked");
        }
        [Test]
        public void CheckFirstRadioButton()
        {
            TestCasesForm obj = new TestCasesForm(driver);
            obj.FillFirstRadioButton();
            Assert.IsTrue(obj.IsCheckFirstRadioButton(), "First Radio button is not get selected");
        }
        [Test]
        public void CheckSecondRadioButton()
        {
            TestCasesForm obj = new TestCasesForm(driver);
            obj.FillSecondRadioButton();
            Assert.IsTrue(obj.IsCheckSecondRadioButton(), "Second Radio button is not get selected");
        }
        [Test]
        public void CheckThirdRadioButton()
        {
            TestCasesForm obj = new TestCasesForm(driver);
            obj.FillThirdRadioButton();
            Assert.IsTrue(obj.IsCheckThirdRadioButton(), "Third Radio button is not get selected");
        }
        [Test]
        public void SubmitBtn()
        {
            TestCasesForm obj = new TestCasesForm(driver);
            ScrollDown(400);
            Assert.IsTrue(obj.IsBtnVisible(), "Button is not visible");
            driver.FindElement(By.XPath("//button[@id='submit']")).Click();

        }
        [Test]
        public void DropDown()
        {
            TestCasesForm obj = new TestCasesForm(driver);
            ScrollDown(400);
            obj.FillDropDown1("NCR");
            obj.FillDropDown2("Noida");

            Assert.IsTrue(obj.IsDropdown1(),"State is not same");
            Assert.IsTrue(obj.IsDropdown1(), "City is not same");

        }

        public void ScrollDown(int yOffset)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0,{yOffset});");
        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
    public class TestCasesForm
    {
        private IWebDriver _driver;

        public TestCasesForm(IWebDriver driver)
        {
            this._driver = driver;
        }
        public void waitForElementVisible(By by, int timeOutInSeconds = 60)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
        public void SendKeys(By by, string text, int timeOutInSeconds = 60)
        {
            waitForElementVisible(by, timeOutInSeconds);
            var element = _driver.FindElement(by);
            element.Clear();
            element.SendKeys(text);
            element.SendKeys(Keys.Enter);
        }

        public void FillFirstName(string firstname)
        {
            SendKeys(FirstnameText, firstname);
        }
        public void FillLastName(string lastname)
        {
            SendKeys(LastNameInput, lastname);
        }
        public void FillEmail(string email)
        {
            SendKeys(EmailInput, email);
        }
        public void FillMobileNumber(string number)
        {
            SendKeys(MobileInput, number);
        }
        public void FillDOB()
        {
            ScrollDownn(400);
            ClickElement(SelectMonth);
            ClickElement(SelectMay);
            ClickElement(SelectYear);
            ClickElement(Select2001);
            ClickElement(SelectDate);

            
        }
        public void FillSubjects(params string[] subjects)
        {
            IWebElement element = _driver.FindElement(SubjectsInput);
            element.Click();
            foreach( var subject in subjects)
            {
                element.SendKeys(subject);
                //ClickElement(By.XPath($"//div[contains(text(),'{subject}')]"));
                element.SendKeys(Keys.Enter);
                
            }
        
        }
        public bool IsSubjectSelected()
        {
            return _driver.FindElement(SubjectCommerce).Selected;
        }
        public void FillPicture(string path)
        {

            SendKeys(PictureInput, path);
        }
        public void FillCurrAdd(string address)
        {
            SendKeys(AddressInput, address);
        }

        /////For CheckBoxes
        public void FillOneCheckBoxInput()
        {
            ClickElement(OneCheckBoxInput);


        }
        public void FillTwoCheckBoxes(string hobbies)
        {
            foreach (var hobby in hobbies.Split(','))
            {
                ClickElement(TwoCheckBoxInputs(hobby.Trim()));
            }
        }

        public void FillSecondRadioButton()
        {
            ClickElement(SecondRadioButtonInput);
        }
        public void FillFirstRadioButton()
        {
            ClickElement(FirstRadioButtonInput);
        }
        public void FillThirdRadioButton()
        {
            ClickElement(ThirdRadioButtonInput);
        }
        public void FillDropDown1(string state)
        {
            ClickElement(DropDown1);
            ClickElement(By.XPath($"//div[text()='{state}']"));
        }
        public void FillDropDown2(string city)
        {
            ClickElement(DropDown2);
            ScrollDownn(200);
            ClickElement(By.XPath($"//div[text()='{city}']"));
        }
        public bool IsDropdown1()
        {
            return _driver.FindElement(By.XPath("//div[contains(text(),'NCR')]")).Displayed;
        }
        public bool IsDropdown2()
        {
            var dropdown = _driver.FindElement(DropDown2);
            var option = dropdown.FindElement(By.XPath("//div[contains(text(),'Noida')]"));
            return option.Displayed;
        }

        private By FirstnameText => By.Id("firstName");
        private By LastNameInput => By.Id("lastName");
        private By EmailInput => By.Id("userEmail");
        private By MobileInput => By.Id("userNumber");
        private By DOBInput => By.Id("dateOfBirthInput");
        private By SubjectsInput => By.Id("subjectsInput");
        private By SubjectCommerce => By.XPath("//div[contains(text(),'Commerce')]");
        private By SelectMonth => By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/form[1]/div[5]/div[2]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/select[1]");
        private By SelectMay => By.XPath("//option[contains(text(),'May')]");
        private By SelectYear => By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/form[1]/div[5]/div[2]/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/div[2]/div[2]/select[1]");
        private By Select2001 => By.XPath("//option[contains(text(),'2001')]");
        private By SelectDate => By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/form[1]/div[5]/div[2]/div[2]/div[2]/div[1]/div[1]/div[2]/div[2]/div[1]/div[6]");
        private By PictureInput => By.Id("uploadPicture");
        private By AddressInput => By.Id("currentAddress");
        private By OneCheckBoxInput => By.XPath("//label[contains(text(),'Music')]");
        private By TwoCheckBoxInputs(string hobby) => By.XPath($"//label[text()='{hobby}']");
        private By SecondRadioButtonInput => By.XPath("//label[contains(text(),'Female')]");
        private By FirstRadioButtonInput => By.XPath("//label[contains(text(),'Male')]");
        private By ThirdRadioButtonInput => By.XPath("//label[contains(text(),'Other')]");
        private By DropDown1 => By.Id("state");
        private By DropDown2 => By.Id("city");



        public IWebElement GetElement(By by, int timeOutInSeconds = 60)
        {
            waitForElementVisible(by, timeOutInSeconds);
            return _driver.FindElement(by);
        }


        public void ScrollDownn(int yOffset)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript($"window.scrollBy(0,{yOffset});");
        }
        public void ClickElement(By by, int timeOutInSeconds = 60)
        {
            waitForElementVisible(by, timeOutInSeconds);
            _driver.FindElement(by).Click();
        }

        public bool IsBtnVisible()
        {
            return _driver.FindElement(By.XPath("//button[@id='submit']")).Displayed;
        }

        public string GetTextBoxValue(string id)
        {
            return _driver.FindElement(By.Id(id)).GetAttribute("value");
        }

        public bool IsCheckboxChecked()
        {
            return _driver.FindElement(By.Id("hobbies-checkbox-1")).GetAttribute("class").Contains("custom-control-input");

        }
        public bool IsCheckFirstRadioButton()
        {
            return _driver.FindElement(By.Id("gender-radio-1")).GetAttribute("class").Contains("custom-control-input");
        }
        public bool IsCheckSecondRadioButton()
        {
            return _driver.FindElement(By.Id("gender-radio-2")).GetAttribute("class").Contains("custom-control-input");
        }
        public bool IsCheckThirdRadioButton()
        {
            return _driver.FindElement(By.Id("gender-radio-3")).GetAttribute("class").Contains("custom-control-input");
        }
    }
}


