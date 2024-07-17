using OpenQA.Selenium;

namespace StudentsRegistryPOM.Pages
{
	public class AddStudentPage : BasePage
	{
        public AddStudentPage(IWebDriver driver) : base(driver)
        {
            
        }

		public override string PageUrl =>
			"http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:82/add-student";

		public IWebElement NameField => driver.FindElement(By.Id("name"));
		public IWebElement EmailField => driver.FindElement(By.Id("email"));
		public IWebElement AddButtonElement => driver.FindElement(By.XPath("//button[@type='submit']"));
		public IWebElement ErrorMsgElement => driver.FindElement(By.XPath("//div"));

		public void AddStudent(string name, string email)
		{
			this.NameField.SendKeys(name);
			this.EmailField.SendKeys(email);
			this.AddButtonElement.Click();
		}

		public string GetErrorMsg()
		{
			return ErrorMsgElement.Text;
		}
	}
}