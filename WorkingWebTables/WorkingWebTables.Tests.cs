using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WorkingWebTables
{
	public class WorkingWebTablesTests
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
		public void Test1()
		{
			IWebElement productTable = driver.FindElement(By.XPath("//*[@id=\"bodyContent\"]/div/div[2]/table"));
			var tableRows = productTable.FindElements(By.XPath("//tbody/tr"));

			string path = System.IO.Directory.GetCurrentDirectory() + "/productinformation.csv";
			if (File.Exists(path))
			{
				File.Delete(path);
			}

            foreach (var row in tableRows)
            {
				var tableCols = row.FindElements(By.XPath("td"));

                foreach (var col in tableCols)
                {
                    string data = col.Text;
					string[] productInfo = data.Split('\n');
					string printProductInfo = productInfo[0].Trim() + ", " + productInfo[1].Trim() + "\n";

					File.AppendAllText(path, printProductInfo);
                }
            }

			Assert.IsTrue(File.Exists(path), "CSV file was not created");
			Assert.IsTrue(new FileInfo(path).Length > 0, "CSV file is empty");
        }
	}
}