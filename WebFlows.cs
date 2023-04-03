using extensions;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using PageObjects;
using utilities;

namespace workflows
{
    class WebFlows : CommponsOps
    {
        [AllureStep("Businees Flow: Login to the site")]
        public static UserFormPage LoginToSite(string userName, string password) {
            loginPage = new LoginPage(driver);
            UIActions.UpdateText(loginPage.Username, userName);
            UIActions.UpdateText(loginPage.Password, password + Keys.Enter);
            return new UserFormPage(driver);
        }

        [AllureStep("Businees Flow: Fill The User Deatils Form")]
        public static void FillUserForm(string title, string inital, string firstName, string middleName, string gender, string language)
        {
            UIActions.UpdateDropDown(userForm.Title, title, "title");
            UIActions.UpdateText(userForm.Initial, inital);
            UIActions.UpdateText(userForm.FirstName, firstName);
            UIActions.UpdateText(userForm.MiddleName, middleName);
            userForm.ChooseGender(gender);
            userForm.ChooseLanguage(language);
            UIActions.Click(userForm.Save);
        }

    }
}
