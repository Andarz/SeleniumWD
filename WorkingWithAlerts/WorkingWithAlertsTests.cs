using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WorkingWithAlerts
{
	public class WorkingWithAlertsTests
	{
		WebDriver driver;

		[SetUp]
		public void Setup()
		{
			driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
		}

		[TearDown]
		public void TearDown()
		{
			driver.Quit();
			driver.Dispose();
		}

		[Test]
		public void HandlingBasicJavaScriptAlerts()
		{
			driver.FindElement(By.XPath("//*[@id=\"content\"]/div/ul/li[1]/button")).Click();

			IAlert alert = driver.SwitchTo().Alert();

			Assert.That(alert.Text, Is.EqualTo("I am a JS Alert"),
				"Alert text is not as expected");

			alert.Accept();

			var resultElement = driver.FindElement(By.Id("result"));
			Assert.That(resultElement.Text, Is.EqualTo("You successfully clicked an alert"),
				"Result message is not as expected");
		}

		[Test]
		public void HandlingJavaScriptConfirmAlerts()
		{
			driver.FindElement(By.XPath("//*[@id=\"content\"]/div/ul/li[2]/button")).Click();

			IAlert alert = driver.SwitchTo().Alert();

			Assert.That(alert.Text, Is.EqualTo("I am a JS Confirm"), "Alert text is not as expected");

			alert.Accept();

			var resultElem = driver.FindElement(By.Id("result"));
			Assert.That(resultElem.Text, Is.EqualTo("You clicked: Ok"), "Result message is not as expected");

			driver.FindElement(By.XPath("//*[@id=\"content\"]/div/ul/li[2]/button")).Click();

			alert.Dismiss();

			Assert.That(resultElem.Text, Is.EqualTo("You clicked: Cancel"), "Result message is not as expected");
		}

		[Test]
		public void HandlingJavaScriptPromptAlerts()
		{
			driver.FindElement(By.XPath("//*[@id=\"content\"]/div/ul/li[3]/button")).Click();

			IAlert alert = driver.SwitchTo().Alert();

			Assert.That(alert.Text, Is.EqualTo("I am a JS prompt"),
				"Alert text is not as expected");

			string inputString = "Hello there!";

			alert.SendKeys(inputString);
			alert.Accept();

			var resultElem = driver.FindElement(By.Id("result"));
			Assert.That(resultElem.Text, Is.EqualTo("You entered: Hello there!"), "Result message is not as expected");
		}
	}
}