using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Selenium_Waits
{
	public class SeleniumWaitsTests
	{
		IWebDriver driver;

		[SetUp]
		public void Setup()
		{
			driver = new ChromeDriver();
			driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/dynamic.html");
		}

		[TearDown]
		public void TearDown()
		{
			driver.Quit();
			driver.Dispose();
		}

		[Test, Order(1)]
		public void AddBoxWithoutWaitsFails()
		{
			driver.FindElement(By.Id("adder")).Click();

			var redBox = driver.FindElement(By.Id("box0"));

			Assert.True(redBox.Displayed);
		}

		[Test, Order(2)]
		public void RevealInputWithoutWaitsFail()
		{
			driver.FindElement(By.Id("reveal")).Click();

			var inputBox = driver.FindElement(By.Id("revealed"));

			inputBox.SendKeys("Displayed");

			Assert.That(inputBox.GetAttribute("value"), Is.EqualTo("Displayed"));
		}

		// Using Thread.Sleep

		[Test, Order(3)]
		public void AddBoxWithThreadSleep()
		{
			driver.FindElement(By.Id("adder")).Click();

			Thread.Sleep(3000);

			var redBox = driver.FindElement(By.Id("box0"));

			Assert.True(redBox.Displayed);
		}

		// Using Implicit Wait

		[Test, Order(4)]
		public void AddBoxWithImplicitWait()
		{
			driver.FindElement(By.Id("adder")).Click();

			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

			var redBox = driver.FindElement(By.Id("box0"));

			Assert.True(redBox.Displayed);
		}

		[Test, Order(5)]
		public void RevealInputWithImplicitWaits()
		{
			driver.FindElement(By.Id("reveal")).Click();

			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

			var inputBox = driver.FindElement(By.Id("revealed"));

			Assert.That(inputBox.TagName, Is.EqualTo("input"));
		}

		// Using Explicit Wait

		[Test, Order(6)]
		public void RevealInputWithExplicitWaits()
		{
			var revealed = driver.FindElement(By.Id("revealed"));
			driver.FindElement(By.Id("reveal")).Click();

			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
			wait.Until(d => revealed.Displayed);

			revealed.SendKeys("Displayed");

			Assert.That(revealed.GetAttribute("value"), Is.EqualTo("Displayed"));
		}

		// Using Fluent Wait

		[Test, Order(7)]
		public void AddBoxWithFluentWaitExpectedConditionsAndIgnoredExceptions()
		{
			driver.FindElement(By.Id("adder")).Click();

			WebDriverWait wait = new WebDriverWait (driver, TimeSpan.FromSeconds(10));
			wait.PollingInterval = TimeSpan.FromMilliseconds(500);
			wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

			var redBox = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("box0")));

			Assert.IsTrue(redBox.Displayed);
		}

		[Test, Order(8)]
		public void RevealInputWithCustomFluentWait()
		{
			var revealed = driver.FindElement(By.Id("revealed"));
			driver.FindElement(By.Id("reveal")).Click();

			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
			wait.PollingInterval = TimeSpan.FromMilliseconds(200);
			wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));

			wait.Until(d =>
			{
				revealed.SendKeys("Displayed");
				return true;
			});

			Assert.That(revealed.TagName, Is.EqualTo("input"));
			Assert.That(revealed.GetAttribute("value"), Is.EqualTo("Displayed"));
		}
	}
}