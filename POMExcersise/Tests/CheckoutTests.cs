namespace POMExcersise.Tests
{
	public class CheckoutTests : BaseTest
	{
		[SetUp]
		public void SetUp()
		{
			Login("standard_user", "secret_sauce");
			inventoryPage.AddToCartByIndex(2);
			inventoryPage.ClickCartLink();
			cartPage.ClickCheckout();
		}

		[Test]
		public void TestCheckoutPageLoaded()
		{
			Assert.True(checkoutPage.IsPageLoaded(), "Checkout page is not loaded");
		}

		[Test]
		public void TestContinueToNextStep()
		{
			checkoutPage.EnterFirstName("Mark");
			checkoutPage.EnterLastName("Fuller");
			checkoutPage.EnterPostalCode("1069");
			checkoutPage.ClickContinue();

			Assert.True(driver.Url.Contains("checkout-step-two.html"), "User can not proceed to the next step");
		}

		[Test]
		public void TestCompleteOrder()
		{
			checkoutPage.EnterFirstName("Mark");
			checkoutPage.EnterLastName("Fuller");
			checkoutPage.EnterPostalCode("1069");
			checkoutPage.ClickContinue();
			checkoutPage.ClickFinish();

			Assert.True(checkoutPage.IsChecoutComplete(), "Checkout finish is not succeeded");
		}
	}
}
