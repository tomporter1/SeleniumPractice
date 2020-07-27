using AutomationPracticeTestingFramework.Lib.DriverConfig;
using AutomationPracticeTestingFramework.Lib.Pages;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace AutomationPracticeTestingFramework.Lib
{
    public class Website
    {
        public readonly IWebDriver seleniumDriver;
        public readonly HomePage homePage;
        public readonly FadedTShirtPage tshirtPage;
        public Website(string driverName, float pageLoadWaitInSecs = 10, float implicitWaitInSecs = 10)
        {
            seleniumDriver = new SeleniumDriverConfig(driverName, pageLoadWaitInSecs, implicitWaitInSecs).Driver;
            homePage = new HomePage(seleniumDriver);
            tshirtPage = new FadedTShirtPage(seleniumDriver);
        }

        internal void SleepDriver(int sleepTime) => Thread.Sleep(TimeSpan.FromSeconds(sleepTime));

        internal void Close() => seleniumDriver.Dispose();

        internal string GetUrl() => seleniumDriver.Url;
    }
}