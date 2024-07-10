using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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
		[TestCase("2", "+ (sum)", "8", "Result: 10")]
		[TestCase("2.5", "- (subtract)", "1.1", "Result: 1.4")]
		[TestCase("2", "* (multiply)", "8", "Result: 16")]
		[TestCase("8", "/ (divide)", "2", "Result: 4")]
		[TestCase("2", "/ (divide)", "0", "Result: Infinity")]
		[TestCase("invalid", "+ (sum)", "8", "Result: invalid input")]
		[TestCase("2e2", "* (multiply)", "1.5", "Result: 300")]

		public void PerformCalculation(string firstNumber, string operation, string  secondNumber, string expectedResult)
		{
			resetBtn.Click();

			if (!string.IsNullOrEmpty(firstNumber))
			{
				textBoxFirstNum.SendKeys(firstNumber);
			}

			if (!string.IsNullOrEmpty(secondNumber))
			{
				textBoxSecondNum.SendKeys(secondNumber);
			}

			if (!string.IsNullOrEmpty(operation))
			{
				new SelectElement(dropDownOperation).SelectByText(operation);
			}

			calcBtn.Click();

			Assert.That(divResult.Text, Is.EqualTo(expectedResult));
		}
		public void TestCalcOperations(string firstNumber, string operation, string secondNumber, string expectedResult)
		{
			PerformCalculation(firstNumber, operation, secondNumber, expectedResult);
		}
	}
}