using extensions;
using OpenQA.Selenium;

namespace PageObjects
{
    public class UserFormPage
    {
        private readonly string _title = "TitleId";
        private readonly string _initial = "Initial";
        private readonly string _firstName = "FirstName";
        private readonly string _middleName = "MiddleName";
        private readonly string _genderRadioButton = "//input[@type='radio' and @name='[Value]']";
        private readonly string _languageCheckBox = "//input[@type='checkbox' and @name='[Value]']";
        private readonly string _saveButton = "Save";

        public IWebElement Title { get { return driver.FindElement(By.Id(_title)); } }
        public IWebElement Initial { get { return driver.FindElement(By.Id(_initial)); } }

        public IWebElement FirstName { get { return driver.FindElement(By.Id(_firstName)); } }

        public IWebElement MiddleName { get { return driver.FindElement(By.Id(_middleName)); } }

        public IWebElement Save { get { return driver.FindElement(By.Name(_saveButton)); } }



        private IWebDriver driver;

        public UserFormPage(IWebDriver driver) { 
            this.driver = driver;
        }

        public void ChooseGender(string value)
        {
            IWebElement radioButton = driver.FindElement(By.XPath(_genderRadioButton.Replace("[Value]", value)));
            if (!radioButton.Selected) radioButton.Click(); 
        }

        public void ChooseLanguage(string value)
        {
            IWebElement checkBox = driver.FindElement(By.XPath(_languageCheckBox.Replace("[Value]", value)));
            if (!checkBox.Selected) checkBox.Click();
        }

    }
}
