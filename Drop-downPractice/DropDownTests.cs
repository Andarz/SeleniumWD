using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Drop_downPractice
{
	public class Tests
	{
		private IWebDriver driver;

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
		public void DropDownTests()
		{
			string path = Directory.GetCurrentDirectory() + "/manufacturer.txt";
			if (File.Exists(path))
			{
				File.Delete(path);
			}

			SelectElement dropManufacturers = new SelectElement(driver.FindElement(By.Name("manufacturers_id")));
			var manufacturers = dropManufacturers.Options;
			List<string> names = new List<string>();

			foreach (var name in manufacturers)
			{
				names.Add(name.Text);
			}
			names.RemoveAt(0);

			foreach (var name in names)
			{
				dropManufacturers.SelectByText(name);
				dropManufacturers = new SelectElement(driver.FindElement(By.XPath("//select[@name='manufacturers_id']")));

				if (driver.PageSource.Contains("There are no products available in this category."))
				{
					File.AppendAllText(path, $"The manufacturer {name} has no products\n");
				}
				else
				{
					var productTable = driver.FindElement(By.ClassName("productListingData"));

					File.AppendAllText(path, $"\n\nThe manufacturer {name} products are listed--\n");
					var rows = productTable.FindElements(By.XPath("//tbody/tr"));

					foreach (var row in rows)
					{
						File.AppendAllText(path, row.Text + "\n");
					}
				}
			}
		}
	}
}
		