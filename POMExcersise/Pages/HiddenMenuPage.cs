using OpenQA.Selenium;

namespace POMExcersise.Pages
{
	public class HiddenMenuPage : BasePage
	{
        public HiddenMenuPage(IWebDriver driver) : base(driver)
        {
            
        }

        private readonly By menuButton = By.Id("react-burger-menu-btn");
        private readonly By logoutButton = By.LinkText("Logout");

        public void ClickMenuButton()
        {
            Click(menuButton);
        }

        public void ClickLogoutButton()
        {
            Click(logoutButton);
        }

        public bool IsMenuOpen()
        {
            return FindElement(logoutButton).Displayed;
        }
    }
}
