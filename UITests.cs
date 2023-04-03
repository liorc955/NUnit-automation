using NUnit.Allure.Attributes;
using utilities;
using workflows;

namespace sanity
{
    [AllureSuite("UI Tests")]
    [AllureEpic("Automation Testing web app")]
    public class UITests : CommponsOps
    {

        [AllureStory("This test verifies the filling form with differents data")]
        [TestCaseSource(typeof(ManageDDT), nameof(ManageDDT.AddTestDataConfig)), Category("Sanity")]
        [AllureTag("Sanity")]
        public static void TestOne(string title, string inital, string firstName, string middleName, string gender, string language)
        {
            WebFlows.FillUserForm(title, inital, firstName, middleName, gender, language);
            Assert.That(driver.Title, Is.EqualTo("Execute Automation"));
        }

    }
}
