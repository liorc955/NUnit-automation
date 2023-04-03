using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using workflows;
using OpenQA.Selenium.Interactions;
using NUnit.Allure.Core;
using NUnit.Framework.Interfaces;
using Allure.Commons;
using RestSharp;
using RestSharp.Authenticators;

namespace utilities
{

    [AllureNUnit]
    public class CommponsOps : Base
    {


        public static void InitAPI() {
            client = new RestClient(ManageDDT.GetDataFromXMLConfig("urlAPI"));
            client.Authenticator = new HttpBasicAuthenticator(ManageDDT.GetDataFromXMLConfig("UserName"), ManageDDT.GetDataFromXMLConfig("Password"));
        }

        public static IWebDriver InitChromDriver() {
            new DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver();
        }

        public static IWebDriver InitFireFoxDriver() {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver();
        }

        public static void InitBrowser(string browserName)
        {
            switch (browserName.ToLower())
            {
                case "chrome":
                    driver = InitChromDriver();
                    break;
                case "firefox":
                    driver = InitFireFoxDriver();
                    break;
                default: throw new Exception("Invalid browser name");

            }
            driver.Navigate().GoToUrl(ManageDDT.GetDataFromXMLConfig("urlWeb"));
            //ManagePages.InitiateWebPages();
            driver.Manage().Window.Maximize();
            int timeOutSeconds = Int32.Parse(ManageDDT.GetDataFromXMLConfig("TimeOut"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOutSeconds);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutSeconds));
            action = new Actions(driver);
            jsExecutor = (IJavaScriptExecutor)driver;
        }

        
        [OneTimeSetUp]
        public static void Setup()
        {
            platform = TestContext.Parameters["platformName"];
            string browserName = TestContext.Parameters["browserName"];
            if (browserName == null) browserName = ManageDDT.GetDataFromXMLConfig("browserName");
            if (platform == null) platform = ManageDDT.GetDataFromXMLConfig("platformName");
            if (platform.Equals("Web", StringComparison.OrdinalIgnoreCase)) InitBrowser(browserName);
            else if (platform.Equals("API", StringComparison.OrdinalIgnoreCase)) InitAPI();
            else throw new Exception("Invalid platform name");
        }

        [SetUp]
        public static void BeforeTest() {
            if (platform.Equals("Web", StringComparison.OrdinalIgnoreCase))
                userForm = WebFlows.LoginToSite(ManageDDT.GetDataFromXMLConfig("UserName"), ManageDDT.GetDataFromXMLConfig("Password"));
        }

        [TearDown]
        public static void afterTest() {
            if (platform.Equals("Web", StringComparison.OrdinalIgnoreCase))
                driver.Navigate().GoToUrl(ManageDDT.GetDataFromXMLConfig("urlWeb"));
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            if (testStatus == TestStatus.Failed && platform.Equals("Web", StringComparison.OrdinalIgnoreCase)) {
                byte[] content = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
                AllureLifecycle.Instance.AddAttachment("Screenshot for failed test: " + TestContext.CurrentContext.Test.MethodName, "image/png", content);
            }
        }

        [OneTimeTearDown]
        public static void Tear()
        {
            if (platform.Equals("Web", StringComparison.OrdinalIgnoreCase)) driver.Quit();
        }



    }
}
