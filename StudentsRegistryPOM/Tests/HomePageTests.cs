using StudentsRegistryPOM.Pages;

namespace StudentsRegistryPOM.Tests
{
	public class HomePageTests : BaseTests
	{
		[Test]
		public void Test_HomePage()
		{
			var page = new HomePage(driver);
			page.Open();

			Assert.That("MVC Example", Is.EqualTo(page.GetPageTitle()));
			Assert.That("Students Registry", Is.EqualTo(page.GetPageHeadingText()));

			page.GetStudentsCount();

			Assert.True(page.GetStudentsCount() > 0);
		}

		[Test]
		public void Test_HomePage_Links()
		{
			var page = new HomePage(driver);
			page.Open();
			page.HomePageLink.Click();
			Assert.IsTrue(new HomePage(driver).IsOpen());

			page.Open();
			page.AddStudentLink.Click();
			Assert.IsTrue(new AddStudentPage(driver).IsOpen());

			page.Open();
			page.ViewStudentsLink.Click();
			Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
		}
	}
}
