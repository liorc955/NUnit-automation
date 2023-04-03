using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using PageObjects;
using RestSharp;


namespace utilities
{
    public class Base
    {
        protected static IWebDriver driver;
        protected static string platform;
        protected static Actions action;
        protected static IJavaScriptExecutor jsExecutor;
        protected static RestRequest httpRequest;
        protected static RestResponse httpResponse;
        protected static RestClient client;

        //page objects
        protected static LoginPage loginPage;
        protected static UserFormPage userForm;
        protected static WebDriverWait wait;
    }
}
