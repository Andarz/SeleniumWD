using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ExplicitWaitExcersise
{
	public class ExplicitWaitTests
	{
		WebDriver driver;

		[SetUp]
		public void Setup()
		{
			driver = new ChromeDriver();
			driver.Navigate().GoToUrl("http://practice.bpbonline.com/");
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
		}

		[TearDown]
		public void Teardown()
		{
			driver.Quit();
			driver.Dispose();
		}

		[Test, Order(1)]
		public void SearchForKeyboardTest()
		{
			driver.FindElement(By.XPath("//input[@name='keywords']")).SendKeys("keyboard" + Keys.Enter);

			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);


			try
			{
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

				var buyNowBtn = wait.Until(e => e.FindElement(By.LinkText("Buy Now")));

				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

				buyNowBtn.Click();

				Assert.IsTrue(driver.FindElement(By.XPath("//*[@id=\"tdb5\"]/span[2]")).Displayed);
				Assert.IsTrue(driver.PageSource.Contains("Keyboard"),
					"The product 'keyboard' was not found in the cart page");
				Console.WriteLine("Scenario completed");
			}
			catch (Exception ex)
			{
				Assert.Fail("Unexpected exception: " + ex.Message);
			}
		}

		[Test, Order(2)]
		public void SearchForJunkTest()
		{
			driver.FindElement(By.XPath("//input[@name='keywords']")).SendKeys("junk" + Keys.Enter);

			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

			try
			{
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

				var buyNowBtn = wait.Until(e => e.FindElement(By.LinkText("Buy Now")));

				buyNowBtn.Click();

				Assert.Fail("The 'Buy Now' link was not found for a non-existing product");
			}
			catch (WebDriverTimeoutException)
			{
				Assert.Pass("Expected WebDriverTimeoutException was thrown");
			}
			catch (Exception ex)
			{
				Assert.Fail("Unexpected exception: " + ex.Message);
			}
			finally
			{
				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			}
		}
	}
}