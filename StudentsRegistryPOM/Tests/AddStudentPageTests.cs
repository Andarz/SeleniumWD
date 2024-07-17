using StudentsRegistryPOM.Pages;

namespace StudentsRegistryPOM.Tests
{
	public class AddStudentPageTests : BaseTests
	{
		[Test]
		public void Test_TestAddStudentPage_Content()
		{
			var page = new AddStudentPage(driver);
			page.Open();

			Assert.That("Add Student", Is.EqualTo(page.GetPageTitle()));
			Assert.That("Register New Student",Is.EqualTo(page.GetPageHeadingText()));
			Assert.That(page.NameField.Text, Is.EqualTo(""));
			Assert.That(page.EmailField.Text, Is.EqualTo(""));
			Assert.That(page.AddButtonElement.Text, Is.EqualTo("Add"));
		}

		[Test]
		public void Test_TestAddStudentPage_Links()
		{
			var page = new AddStudentPage(driver);
			
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

		[Test]
		public void Test_TestAddStudentPage_AddValidStudent()
		{
			var page = new AddStudentPage(driver);
			page.Open();

			string name = "New student" + DateTime.Now.Ticks;
			string email = "email" + DateTime.Now.Ticks + "@email.com";

			page.AddStudent(name, email);

			var viewPage = new ViewStudentsPage(driver);
			viewPage.Open();

			Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());

			var newStudent = name + " (" + email + ")";
			var students = viewPage.GetStudentsList();

			Assert.That(students, Does.Contain(newStudent));
		}
	}
}
