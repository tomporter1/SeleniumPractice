using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace AutomationPracticeTestingFramework.Lib.Pages
{
    public class FadedTShirtPage : SuperPage
    {
        private SelectElement sizeComboBox => new SelectElement(_seleniumDriver.FindElement(By.Id("group_1")));
        private IWebElement blueColourOption => _seleniumDriver.FindElement(By.Id("color_14"));
        private IWebElement addToCartButton => _seleniumDriver.FindElement(By.Id("add_to_cart"));
        private IWebElement cartCount => _seleniumDriver.FindElement(By.ClassName("ajax_cart_quantity"));
        private IWebElement emptyCartCount => _seleniumDriver.FindElement(By.CssSelector(".ajax_cart_no_product"));
        private IWebElement increaseQuantity => _seleniumDriver.FindElement(By.ClassName("icon-plus"));
        private IWebElement quantityTextBox => _seleniumDriver.FindElement(By.Id("quantity_wanted"));
        private IWebElement errorBox => _seleniumDriver.FindElement(By.ClassName("fancybox-outer"));
        private IWebElement popUpWindowCloseButton => _seleniumDriver.FindElement(By.CssSelector("span[class = 'continue btn btn-default button exclusive-medium']"));
        private IWebElement removeItem => _seleniumDriver.FindElement(By.CssSelector(".ajax_cart_block_remove_link"));
        private ReadOnlyCollection<IWebElement> totalPrice => _seleniumDriver.FindElements(By.ClassName("layer_cart_row"));

        public FadedTShirtPage(IWebDriver seleniumDriver) : base(seleniumDriver)
        {
            _url = "http://automationpractice.com/index.php?id_product=1&controller=product";
        }

        internal void SelectMediumSize() => sizeComboBox.SelectByValue("2");
        internal void ClickBlueOption() => blueColourOption.Click();
        internal int GetNumOfItemsInCart() => int.Parse(cartCount.Text);
        internal void ClickAddToCart() => addToCartButton.Click();
        internal void IncreaseQuantity() => increaseQuantity.Click();
        internal string GetQuantity() => quantityTextBox.GetAttribute("value");

        internal void SetQuantity(string quantity)
        {
            quantityTextBox.Clear();
            quantityTextBox.SendKeys(quantity);
        }

        internal string GetErrorMeg() => errorBox.Text;
        internal List<string> GetCartPriceRows() => TableMethods.ToStringList(totalPrice);

        internal void ClosePopup() => popUpWindowCloseButton.Click();

        internal void RemoveTshirtFromCart()
        {
            //hover over first
            HoverMouse(".shopping_cart > a:nth-child(1)");

            removeItem.Click();
        }

        private void HoverMouse(string cssSelector)
        {
            Actions actions = new Actions(_seleniumDriver);
            IWebElement cart = _seleniumDriver.FindElement(By.CssSelector(cssSelector));
            actions.MoveToElement(cart).Perform();
            Thread.Sleep(3000);
        }

        internal bool CartIsEmpty() => emptyCartCount.Text == "(empty)";
    }
}