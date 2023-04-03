using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjects
{


    public class LoginPage
    {
        private readonly string _username = "UserName";
        private readonly string _password = "Password";
        private IWebDriver driver;

        public IWebElement Username { get { return driver.FindElement(By.Name(_username)); } }
        public IWebElement Password { get { return driver.FindElement(By.Name(_password));} }

        public LoginPage(IWebDriver driver) {
            this.driver = driver;
        }
    }
}
