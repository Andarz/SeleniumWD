using OpenQA.Selenium;

namespace POMExcersise.Pages
{
	public class InventoryPage : BasePage
	{
        public InventoryPage(IWebDriver driver) : base(driver)
        {
            
        }

        protected readonly By cartLink = By.XPath("//a[@class='shopping_cart_link']");
        protected readonly By productsPageTitle = By.ClassName("title");
        public readonly By inventoryItems = By.CssSelector(".inventory_item");

        public void AddToCartByIndex(int itemIndex)
        {
            var itemAddToCartButton = By.CssSelector($".inventory_item:nth-child({itemIndex + 1}) .btn_inventory");
            Click(itemAddToCartButton);
        }

        public void AddToCartByName(string productName)
        {
            var itemAddToCartButton = By.XPath($"//div[text()='{productName}']" + 
                $"/ancestor::div[@class='inventory_item']//button[contains(@class, 'btn_inventory')]");
            Click(itemAddToCartButton);
        }

        public void ClickCartLink()
        {
            Click(cartLink);
        }

        public bool IsInventoryDisplayed()
        {
            return FindElements(inventoryItems).Any();
        }

        public bool IsPageLoaded()
        {
            return GetText(productsPageTitle) == "Products" && driver.Url.Contains("inventory.html");
        }
	}
}
