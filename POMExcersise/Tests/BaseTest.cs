﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POMExcersise.Pages;

namespace POMExcersise.Tests
{
	public class BaseTest
	{
		protected IWebDriver driver;

		[SetUp]
		public void SetUp()
		{
			//this.driver = driver;
			var chromeOptions = new ChromeOptions();
			chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
			driver = new ChromeDriver(chromeOptions);
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
		}

		[TearDown]
		public void TearDown()
		{
			if (driver != null)
			{
				driver.Quit();
				driver.Dispose();
			}
		}

		protected void Login(string username, string password)
		{
			driver.Navigate().GoToUrl("https://www.saucedemo.com/");
			var loginPage = new LoginPage(driver);
			loginPage.LoginUser(username, password);
		}
	}
}
