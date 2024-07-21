namespace POMExcersise.Tests
{
	public class CartTests : BaseTest
	{
		[SetUp]
		public void SetUp()
		{
			Login("standard_user", "secret_sauce");
			inventoryPage.AddToCartByIndex(2);
			inventoryPage.ClickCartLink();
		}

		[Test]
		public void TestCartItemDisplayed()
		{
			Assert.True(cartPage.IsCartItemDisplayed(), "Item not added");
		}

		[Test]
		public void TestClickCheckout()
		{
			cartPage.ClickCheckout();
			Assert.That(checkoutPage.IsPageLoaded(), Is.True, "Checkout page is not loaded correctly");
		}
	}
}
