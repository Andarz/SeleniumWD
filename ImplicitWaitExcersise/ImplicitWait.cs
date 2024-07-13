using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ImplicitWaitExcersise
{
	public class Tests
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
		public void TearDown()
		{
			driver.Quit();
			driver.Dispose();
		}

		[Test, Order(1)]
		public void SearchProduct_Keyboard_ShouldAddToCart()
		{
			driver.FindElement(By.XPath("//input[@name='keywords']")).SendKeys("keyboard" + Keys.Enter);

			try
			{
				driver.FindElement(By.XPath("//*[@id=\"tdb4\"]/span[2]")).Click();

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
		public void SearchProduct_Junk()
		{
			driver.FindElement(By.XPath("//input[@name='keywords']")).SendKeys("junk" + Keys.Enter);

			try
			{
				driver.FindElement(By.LinkText("Buy Now")).Click();				
            }
			catch (NoSuchElementException ex)
			{
				Assert.Pass("Expected NoSuchElementException was thrown");
                Console.WriteLine("Timeout - " + ex.Message);
            }
			catch (Exception ex)
			{
				Assert.Fail("Unexpected exception: " + ex.Message);
			}
		}
	}
}