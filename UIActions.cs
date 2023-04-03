using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using utilities;

namespace extensions
{
    public class UIActions : CommponsOps
    {
        [AllureStep("UI Action: Click on the element")]
        public static void Click(IWebElement elemnt) {
            wait.Until(ExpectedConditions.ElementToBeClickable(elemnt));
            elemnt.Click();
        }

        [AllureStep("UI Action: Type Text")]
        public static void UpdateText(IWebElement element, string text) {
            //wait.Until(ExpectedConditions.ElementIsVisible((By)element));
            ClearText(element);
            element.SendKeys(text);
        }

        [AllureStep("UI Action: Clear Text")]
        public static void ClearText(IWebElement element) {
            element.Clear();
        }

        [AllureStep("UI Action: Select drop-down item")]
        public static void UpdateDropDown(IWebElement element, string optionName, string selectBy)
        {
            SelectElement select = new SelectElement(element);
            if (selectBy.Equals("text")) select.SelectByText(optionName);
            else if (selectBy.Equals("value")) select.SelectByValue(optionName);
        }

    }
}
