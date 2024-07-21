using OpenQA.Selenium;
using POMExcersise.Pages;

namespace POMExcersise.Tests
{
	public class HiddenMenuTests : BaseTest
	{
		[SetUp]
		public void SetUp()
		{
			Login("standard_user", "secret_sauce");
		}

		[Test]
		public void TestOpenMenu()
		{
			hiddenMenuPage.ClickMenuButton();
			
			Assert.True(hiddenMenuPage.IsMenuOpen(), "Hidden menu is not opened");
		}

		[Test]
		public void TestLogout()
		{
			hiddenMenuPage.ClickMenuButton();
			hiddenMenuPage.ClickLogoutButton();

			Assert.True(driver.Url.Equals("https://www.saucedemo.com/"), "Logout was not succeed");
		}
	}
}
