using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace AutomationPracticeTestingFramework.Lib.DriverConfig
{
    public class SeleniumDriverConfig
    {
        public IWebDriver Driver { get; set; }

        public SeleniumDriverConfig(string driverName, float pageLoadTimeInSecs, float implicitWaitInSecs)
        {
            DriverSetup(driverName, pageLoadTimeInSecs, implicitWaitInSecs);
        }

        private void DriverSetup(string driverName, float pageLoadTimeInSecs, float implicitWaitInSecs)
        {
            if (driverName.ToLower() == "chrome")
            {
                SetChromeDriver();
            }
            else if (driverName.ToLower() == "firefox")
            {
                SetFireFoxDriver();
            }
            else
            {
                throw new Exception("Use 'chrome' or 'firefox'");
            }
            SetDriverConfiguration(pageLoadTimeInSecs, implicitWaitInSecs);
        }

        private void SetDriverConfiguration(float pageLoadTimeInSecs, float implicitWaitInSecs)
        {
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadTimeInSecs);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitInSecs);
        }

        private void SetFireFoxDriver() => Driver = new FirefoxDriver();

        private void SetChromeDriver() => Driver = new ChromeDriver();
    }
}