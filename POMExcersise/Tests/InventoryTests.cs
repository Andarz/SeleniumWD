namespace POMExcersise.Tests
{
	public class InventoryTests : BaseTest
	{
		[SetUp]
		public void SetUp()
		{
			Login("standard_user", "secret_sauce");
		}
		[Test]
		public void TestInventoryDisplay()
		{

			Assert.That(inventoryPage.IsInventoryDisplayed(), Is.True,
				"Login failed and inventory page is not loaded");
		}

		[Test]
		public void TestAddToCartByIndex()
		{

			inventoryPage.AddToCartByIndex(3);
			inventoryPage.ClickCartLink();

			Assert.That(cartPage.IsCartItemDisplayed(), Is.True,
				"Adding to cart failed - no item in the cart");
		}

		[Test]
		public void TestAddToCartByName()
		{

			inventoryPage.AddToCartByName("Sauce Labs Bike Light");
			inventoryPage.ClickCartLink();

			Assert.That(cartPage.IsCartItemDisplayed(), Is.True,
				"Adding to cart failed - no item in the cart");
		}

		[Test]
		public void TestPageTitle()
		{
			//Login("standard_user", "secret_sauce");
			Assert.That(inventoryPage.IsPageLoaded(), Is.True, "Inventory page is not loaded correctly");
		}
	}
}
