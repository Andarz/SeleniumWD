using StudentsRegistryPOM.Pages;

namespace StudentsRegistryPOM.Tests
{
	public class ViewStudentsPageTests : BaseTests
	{
		[Test]
		public void Test_ViewStudentsPage_Content()
		{
			var page = new ViewStudentsPage(driver);
			page.Open();

			Assert.AreEqual("Students", page.GetPageTitle());
			Assert.That("Registered Students", Is.EqualTo(page.GetPageHeadingText()));

			var students = page.GetStudentsList();

			foreach (var student in students)
			{
				Assert.IsTrue(student.IndexOf("(") > 0);
				Assert.IsTrue(student.IndexOf(")") == student.Length - 1);
			}
		}

		[Test]
		public void Test_ViewStudentsPage_Links()
		{
			var page = new ViewStudentsPage(driver);
			
			page.Open();
			page.HomePageLink.Click();
			Assert.IsTrue(new HomePage(driver).IsOpen());

			page.Open();
			page.ViewStudentsLink.Click();
			Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());

			page.Open();
			page.AddStudentLink.Click();
			Assert.IsTrue(new AddStudentPage(driver).IsOpen());
		}
	}
}
