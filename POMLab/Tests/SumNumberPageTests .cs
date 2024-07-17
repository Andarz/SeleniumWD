using OpenQA.Selenium.Chrome;
using POMLab.Pages;

namespace POMLab.Tests
{
	public class SumNumberPageTests
	{
		private ChromeDriver driver;
		private SumNumberPage sumpage;

		[SetUp]
		public void Setup()
		{
			driver = new ChromeDriver();
			sumpage = new SumNumberPage(driver);
		}

		[TearDown]
		public void Close()
		{
			if (driver != null)
			{
				driver.Quit();
				driver.Dispose();
			}
		}

		[Test]
		public void Test_AddTwoNumbers_ValidInput()
		{
			sumpage.OpenPage();
			var result = sumpage.AddNumbers("3", "7");
			Assert.That(result, Is.EqualTo("Sum: 10"));
		}

		[Test]
		public void Test_AddTwoNumbers_InvalidInput()
		{
			sumpage.OpenPage();
			var result = sumpage.AddNumbers("super", "7");
			Assert.That(result, Is.EqualTo("Sum: invalid input"));
		}

		[Test]
		public void Test_ResetForm ()
		{
			sumpage.OpenPage();

			sumpage.AddNumbers("1", "1");
			bool IsFormEmpty = sumpage.IsFormEmpty();
			Assert.That(IsFormEmpty, Is.False);

			sumpage.ResetForm();
			IsFormEmpty = sumpage.IsFormEmpty();
			Assert.That(IsFormEmpty, Is.True);
		}
	}
}