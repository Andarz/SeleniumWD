using OpenQA.Selenium;

namespace POMLab.Pages
{
	public class SumNumberPage
	{
		WebDriver driver;

		public SumNumberPage(WebDriver driver)
		{
			this.driver = driver;
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
		}

		const string PageUrl = "https://5651d6bb-1b8a-4286-aaf3-bcbbd62c3a99-00-3imc9lwsgujlk.riker.replit.dev/";

		public IWebElement FieldNum1 => driver.FindElement(By.Id("number1"));

		public IWebElement FieldNum2 => driver.FindElement(By.Id("number2"));

		public IWebElement ButtonCalc => driver.FindElement(By.Id("calcButton"));

		public IWebElement ButtonReset => driver.FindElement(By.Id("resetButton"));

		public IWebElement ElementResult => driver.FindElement(By.Id("result"));

		public void OpenPage()
		{
			driver.Navigate().GoToUrl(PageUrl);
		}

		public string AddNumbers(string num1, string num2)
		{
			FieldNum1.SendKeys(num1);
			FieldNum2.SendKeys(num2);
			ButtonCalc.Click();

			string result = ElementResult.Text;
			return result;
		}

		public void ResetForm()
		{
			ButtonReset.Click();
		}
		public bool IsFormEmpty()
		{
			return FieldNum1.Text + FieldNum2.Text + ElementResult.Text == "";
		}
	}
}
