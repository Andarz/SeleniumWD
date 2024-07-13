using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace WorkingWithBrowserWindows
{
	public class WindowsHandlingTests
	{
		WebDriver driver;

		[SetUp]
		public void Setup()
		{
			driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
		}

		[TearDown]
		public void TearDown()
		{
			driver.Quit();
			driver.Dispose();
		}

		[Test]
		public void HandlingMultipleWindowsTest()
		{
			driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");

			driver.FindElement(By.LinkText("Click Here")).Click();

			ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

			Assert.That(windowHandles.Count, Is.EqualTo(2), "There should be two windows opened");

			driver.SwitchTo().Window(windowHandles[1]);

			Assert.That(driver.PageSource.Contains("New Window"));

			string path = Path.Combine(Directory.GetCurrentDirectory(), "windows.txt");
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			File.AppendAllText(path, "Window handle for new window: " +
				driver.CurrentWindowHandle + "\n\n");
			File.AppendAllText(path, "The page content: " + driver.PageSource.ToString() + "\n\n");

			driver.Close();

			driver.SwitchTo().Window(windowHandles[0]);

			Assert.That(driver.PageSource.Contains("Opening a new window"));

			File.AppendAllText(path, "Window handle for original window: " +
				driver.CurrentWindowHandle + "\n\n");
			File.AppendAllText(path, "The page content: " + driver.PageSource.ToString() + "\n\n");
		}

		[Test]
		public void NoSuchWindowExceptionTest ()
		{
			driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");

			driver.FindElement(By.LinkText("Click Here")).Click();

			ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

			driver.SwitchTo().Window(windowHandles[1]);

			driver.Close();

			try
			{
				driver.SwitchTo().Window(windowHandles[1]);
			}
			catch (NoSuchWindowException ex)
			{
				string path = Path.Combine(Directory.GetCurrentDirectory(), "windows.txt");
				File.AppendAllText(path, "NoSuchWindowException caught: " + ex.Message + "\n\n");

				Assert.Pass("NoSuchWindowException was correctly handled.");
			}
			catch (Exception ex)
			{
				Assert.Fail("An unexpected exception was thrown: " + ex.Message);
			}
			finally
			{
				driver.SwitchTo().Window(windowHandles[0]);
			}
		}
	}
}