using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WorkingWithIFrames
{
	public class Tests
	{
		WebDriver driver;

		[SetUp]
		public void Setup()
		{
			driver = new ChromeDriver();
		}

		[TearDown]
		public void TearDown()
		{
			driver.Quit();
			driver.Dispose();
			driver.Navigate().GoToUrl("https://codepen.io/pervillalva/full/abPoNLd");
		}

		[Test]
		public void WorkingWithIFramesTests()
		{
			
		}
	}
}