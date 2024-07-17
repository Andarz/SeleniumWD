using POMExcersise.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMExcersise.Tests
{
	public class LoginTests : BaseTest
	{
		[Test]
		public void TestLoginWithValidCredentials()
		{
			Login("standard_user", "secret_sauce");

			var inventoryPage = new InventoryPage(driver);

			Assert.That(inventoryPage.IsPageLoaded(), Is.True, 
				"Login failed and inventory page is not loaded");
		}

		[Test]
		public void TestLoginWithInvalidCredentials()
		{
			Login("invalid_user", "secret_sauce");

			var logPage = new LoginPage(driver);
			string errorMessage = logPage.GetErrorMessage();

			Assert.That(errorMessage.Contains("Username and password do not match"), "Error message is not correct");
		}
	}
}
