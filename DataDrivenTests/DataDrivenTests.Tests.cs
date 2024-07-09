using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataDrivenTests
{
	public class DataDrivenTests
	{
		WebDriver driver;
		IWebElement textBoxFirstNum;
		IWebElement dropDownOperation;
		IWebElement textBoxSecondNum;
		IWebElement calcBtn;
		IWebElement resetBtn;
		IWebElement divResult;

		[OneTimeSetUp]
		public void Setup()
		{
			driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			driver.Url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";

			dropDownOperation = driver.FindElement(By.Id("operation"));
			textBoxFirstNum = driver.FindElement(By.Id("number1"));
			textBoxSecondNum = driver.FindElement(By.Id("number2"));
			calcBtn = driver.FindElement(By.Id("calcButton"));
			resetBtn = driver.FindElement(By.Id("resetButton"));
			divResult = driver.FindElement(By.Id("result"));
		}

		[OneTimeTearDown]
		public void TearDown()
		{
			driver.Quit();
			driver.Dispose();
		}

		[Test]
		public void Test1()
		{
			Assert.Pass();
		}

		public void PerformCalculation(string firstNumber, string operation, string  secondNumber, string expectedResult)
		{
			resetBtn.Click();
		}
	}
}