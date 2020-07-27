using AutomationPracticeTestingFramework.Lib;
using AutomationPracticeTestingFramework.Lib.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace AutomationPracticeTestingFramework.Features
{
    [Binding]
    public class AddTShirtToCartSteps
    {
        private Website _website;
        private const int _sleepTime = 5;

        #region Setup and Teardowns
        [BeforeScenario]
        public void SetUp()
        {
            if (ScenarioContext.Current.ScenarioInfo.Tags[0] == "Firefox")
                _website = new Website("firefox", _sleepTime, _sleepTime);
            else if (ScenarioContext.Current.ScenarioInfo.Tags[0] == "Chrome")
                _website = new Website("chrome", _sleepTime, _sleepTime);
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _website.seleniumDriver.Dispose();
        }
        #endregion

        #region Arrange
        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            _website.homePage.Visit();
        }

        [Given(@"I am on the tshirt item page")]
        public void GivenIAmOnTheTshirtItemPage()
        {
            _website.tshirtPage.Visit();
        }

        [Given(@"I have entered (.*) into the quantity")]
        public void GivenIHaveEnteredIntoTheQuantity(string quantity)
        {
            _website.tshirtPage.SetQuantity(quantity.ToString());
        }
        #endregion

        #region Act
        [When(@"have waited for the page to load")]
        public void WhenHaveWaitedForThePageToLoad()
        {
            Thread.Sleep(TimeSpan.FromSeconds(_sleepTime));
        }

        [When(@"I click on the tshirt")]
        public void WhenIClickOnTheTshirt()
        {
            _website.homePage.ClickOnTshirt();
        }

        [When(@"I click on the M size in the size combobox")]
        public void WhenIClickOnTheMSizeInTheSizeCombobox()
        {
            _website.tshirtPage.SelectMediumSize();
        }

        [When(@"I click on blue colour option")]
        public void WhenIClickOnBlueColourOption()
        {
            _website.tshirtPage.ClickBlueOption();
        }

        [When(@"I click on the add to cart button")]
        public void WhenIClickOnTheAddToCartButton()
        {
            _website.tshirtPage.ClickAddToCart();
        }

        [When(@"I click on increase quantity")]
        public void WhenIClickOnIncreaseQuantity()
        {
            _website.tshirtPage.IncreaseQuantity();
        }
        #endregion

        #region Assert
        [Then(@"the URL should be ""(.*)""")]
        public void ThenTheURLShouldBe(string url)
        {
            Assert.That(_website.GetUrl(), Is.EqualTo(url));
        }

        [Then(@"The url should contain ""(.*)""")]
        public void ThenTheUrlShouldContain(string urlSection)
        {
            Assert.That(_website.GetUrl(), Does.Contain(urlSection));
        }

        [Then(@"There should be ""(.*)"" item in the cart")]
        public void ThenThereShouldBeItemInTheCart(int count)
        {
            Assert.That(_website.tshirtPage.GetNumOfItemsInCart(), Is.EqualTo(count));
        }

        [Then(@"There should be (.*) item in the quantity text box")]
        public void ThenThereShouldBeItemInTheQuantityTextBox(string expectedQuantity)
        {
            Assert.That(_website.tshirtPage.GetQuantity(), Is.EqualTo(expectedQuantity.ToString()));
        }

        [Then(@"There should be an error message saying ""(.*)""")]
        public void ThenThereShouldBeAnErrorMessageSaying(string msg)
        {
            Assert.That(_website.tshirtPage.GetErrorMeg(), Is.EqualTo(msg));
        }

        [Then(@"The rows of the cart price should be:")]
        public void ThenTheRowsOfTheCartPriceShouldBe(Table expected)
        {
            List<string> rows = _website.tshirtPage.GetCartPriceRows();
            List<string> expectedRows = TableMethods.TableToList(expected);

            Assert.That(rows[0], Is.EqualTo(expectedRows[0]));
            Assert.That(rows[1], Is.EqualTo(expectedRows[1]));
            Assert.That(rows[2], Is.EqualTo(expectedRows[2]));
        }
        #endregion

        [Given(@"I have added the tshirt to the cart")]
        public void GivenIHaveAddedTheTshirtToTheCart()
        {
            _website.tshirtPage.ClickAddToCart();
        }

        [Given(@"I have closed the popup window")]
        public void GivenIHaveClosedThePopupWindow()
        {
            _website.tshirtPage.ClosePopup();
        }

        [When(@"I click on the remove button from the cart")]
        public void WhenIClickOnTheRemoveButtonFromTheCart()
        {
            _website.tshirtPage.RemoveTshirtFromCart();
        }

        [Then(@"The cart should be empty")]
        public void ThenTheCartShouldBeEmpty()
        {
            Assert.That(_website.tshirtPage.CartIsEmpty());
        }

        [Given(@"have waited for the page to load")]
        public void GivenHaveWaitedForThePageToLoad()
        {
            Thread.Sleep(TimeSpan.FromSeconds(_sleepTime));
        }
    }
}