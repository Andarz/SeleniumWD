using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HandlingInputForm
{
	public class Tests
	{
		WebDriver driver;

		[OneTimeSetUp]
		public void Setup()
		{ 
			driver = new ChromeDriver();
			driver.Navigate().GoToUrl("http://practice.bpbonline.com/");
		}

		[OneTimeTearDown]
		public void TearDown()
		{
			driver.Quit();
			driver.Dispose();
		}

		[Test]
		public void HandlingInputForm()
		{
			var myaccountBtn = driver.FindElement(By.CssSelector("#tdb3 > span.ui-button-text"));
			myaccountBtn.Click();
			driver.FindElement(By.LinkText("Continue")).Click();
			driver.FindElement(By.CssSelector("#bodyContent > form > div > div:nth-child(2) > table > tbody > tr:nth-child(1) > td.fieldValue > input[type=radio]:nth-child(1)")).Click();
			driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='firstname']")).SendKeys("Andrey");
			driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='lastname']")).SendKeys("Arz");
			driver.FindElement(By.Id("dob")).SendKeys("07/07/2007");

			Random random = new Random();
			int randomNumber = random.Next(1000, 9999);
			string email = "arz" + randomNumber.ToString() + "@abv.bg";

			driver.FindElement(By.Name("email_address")).SendKeys(email);
			driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='company']")).SendKeys("Test Company");
			driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='street_address']")).SendKeys("Lenina 7");
			driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='suburb']")).SendKeys("Gorubljane");
			driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='postcode']")).SendKeys("1532");
			driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='city']")).SendKeys("Sofia");
			driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='state']")).SendKeys("Sofia");
			driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='state']")).SendKeys("Sofia");

			//IWebElement dropdown = driver.FindElement(By.XPath("//select[@name='country']"));
			//SelectElement selectCountry = new SelectElement(dropdown);
			//selectCountry.SelectByText("Bulgaria");

			new SelectElement(driver.FindElement(By.XPath("//select[@name='country']"))).SelectByText("Bulgaria");

			driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='telephone']")).SendKeys("1234567890");
			driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='fax']")).SendKeys("1234567890");
			driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='newsletter']")).Click();

			driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='password']")).SendKeys("test_Password");
			driver.FindElement(By.XPath("//td[@class='fieldValue']//input[@name='confirmation']")).SendKeys("test_Password");

			driver.FindElement(By.Id("tdb4")).Click();

            Console.WriteLine($"User Account Created with email: {email}");

            Assert.That(driver.FindElement(By.XPath("//div[@id='bodyContent']//h1")).Text, Is.EqualTo("Your Account Has Been Created!"));

			driver.FindElement(By.XPath("//*[@id=\"tdb4\"]/span")).Click();
			driver.FindElement(By.XPath("//*[@id=\"tdb4\"]/span[2]")).Click();
		}
	}
}