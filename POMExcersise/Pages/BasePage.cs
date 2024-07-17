using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace POMExcersise.Pages
{
	public class BasePage
	{
		protected IWebDriver driver;
		protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

		protected IWebElement FindElement(By by)
		{
			return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
		}
    }
}
