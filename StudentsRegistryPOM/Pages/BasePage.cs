using OpenQA.Selenium;

namespace StudentsRegistryPOM.Pages
{
	public class BasePage
	{
		protected readonly IWebDriver driver;
		public BasePage(IWebDriver driver)
		{
			this.driver = driver;
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
		}

		public virtual string PageUrl { get; }

		public IWebElement HomePageLink => driver.FindElement(By.LinkText("Home"));
		public IWebElement ViewStudentsLink => driver.FindElement(By.LinkText("View Students"));
		public IWebElement AddStudentLink => driver.FindElement(By.LinkText("Add Student"));
		public IWebElement PageHeading => driver.FindElement(By.XPath("//h1"));

		public void Open()
		{
			driver.Navigate().GoToUrl(this.PageUrl);
		}

		public bool IsOpen()
		{
			return driver.Url == this.PageUrl;
		}

		public string GetPageTitle()
		{
			return driver.Title;
		}

		public string GetPageHeadingText()
		{
			return PageHeading.Text;
		}
	}
}
