using OpenQA.Selenium;

namespace POMExcersise.Pages
{
	public class CartPage : BasePage
	{
        public CartPage(IWebDriver driver) : base(driver)
        {
            
        }

        private readonly By cartItem = By.CssSelector(".cart_item");
        private readonly By checkoutButton = By.Id("checkout");

        public bool IsCartItemDisplayed()
        {
            return FindElement(cartItem).Displayed;
        }

        public void ClickCheckout()
        {
            Click(checkoutButton);
        }
    }
}
