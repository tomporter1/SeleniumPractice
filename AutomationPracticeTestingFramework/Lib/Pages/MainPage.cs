using OpenQA.Selenium;

namespace AutomationPracticeTestingFramework.Lib.Pages
{
    public class HomePage : SuperPage
    {
        private IWebElement tshirtItem => _seleniumDriver.FindElement(By.LinkText("Faded Short Sleeve T-shirts"));

        public HomePage(IWebDriver seleniumDriver) : base(seleniumDriver)
        {
            _url = WebsiteConfigReader.HomeUrl;
        }

        internal void ClickOnTshirt() => tshirtItem.Click();
    }
}