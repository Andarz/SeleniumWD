using POMExcersise.Pages;

namespace POMExcersise.Tests
{
	public class InventoryTests : BaseTest
	{
		[Test]
		public void TestInventoryDisplay()
		{
			Login("standard_user", "secret_sauce");

			var inventoryPage = new InventoryPage(driver);

			Assert.That(inventoryPage.IsInventoryDisplayed(), Is.True,
				"Login failed and inventory page is not loaded");
		}

		[Test]
		public void TestAddToCartByIndex()
		{
			Login("standard_user", "secret_sauce");

			var inventoryPage = new InventoryPage(driver);
			inventoryPage.AddToCartByIndex(3);
			var cartPage = new CartPage(driver);
			inventoryPage.ClickCartLink();

			Assert.That(cartPage.IsCartItemDisplayed(), Is.True,
				"Adding to cart failed - no item in the cart");
		}

		[Test]
		public void TestAddToCartByName()
		{
			Login("standard_user", "secret_sauce");

			var inventoryPage = new InventoryPage(driver);
			inventoryPage.AddToCartByName("Sauce Labs Bike Light");
			var cartPage = new CartPage(driver);
			inventoryPage.ClickCartLink();

			Assert.That(cartPage.IsCartItemDisplayed(), Is.True,
				"Adding to cart failed - no item in the cart");
		}

		[Test]
		public void TestPageTitle()
		{
			Login("standard_user", "secret_sauce");

			var inventoryPage = new InventoryPage(driver);


		}
	}
}
