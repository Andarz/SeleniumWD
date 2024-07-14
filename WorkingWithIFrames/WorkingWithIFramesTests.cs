using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WorkingWithIFrames
{
	public class WorkingWithIFrames
	{
		WebDriver driver;

		[SetUp]
		public void Setup()
		{
			driver = new ChromeDriver();
			driver.Navigate().GoToUrl("https://codepen.io/pervillalva/full/abPoNLd");
			//driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
		}

		[TearDown]
		public void TearDown()
		{
			driver.Quit();
			driver.Dispose();
		}

		[Test]
		public void HandlingiFramesByIndex()
		{
			WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10));

			wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.TagName("iframe")));

			wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("dropbtn"))).Click();

			var links = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".dropdown-content a")));

            foreach (var link in links)
            {
                Console.WriteLine(link.Text);

				Assert.IsTrue(link.Displayed, "Link is not displayed as expected");
            }

			driver.SwitchTo().DefaultContent();
        }

		[Test]
		public void HandlingiFramesById()
		{
			WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10));

			wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("result"));

			wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("dropbtn"))).Click();

			var links = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".dropdown-content a")));

			foreach (var link in links)
			{
				Console.WriteLine(link.Text);

				Assert.IsTrue(link.Displayed, "Link is not displayed as expected");
			}

			driver.SwitchTo().DefaultContent();
		}

		[Test]
		public void HandlingiFramesByWebElement()
		{
			WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10));

			wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.CssSelector("#result")));

			wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("dropbtn"))).Click();

			var links = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".dropdown-content a")));

			foreach (var link in links)
			{
				Console.WriteLine(link.Text);

				Assert.IsTrue(link.Displayed, "Link is not displayed as expected");
			}

			driver.SwitchTo().DefaultContent();
		}
	}
}