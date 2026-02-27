using NUnit.Framework;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using PageObject.Pages;
using PageObject.Drivers;

namespace PageObject.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver? _driver;
        private LoginPage? _loginPage;

    private IWebDriver Driver =>
        _driver ?? throw new InvalidOperationException("WebDriver is not initialized.");

    // Only ScenarioContext is injected now; browser choice is hard‑coded or configurable elsewhere.
    public LoginSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        // use Chrome by default; modify as needed or read from config/env
        _driver = DriverFactory.Create(Browser.Chrome);
        _driver.Manage().Window.Maximize();
    }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver?.Quit();
        }

        [Given(@"the user is in the login page")]
        public void GivenTheUserIsInTheLoginPage()
        {
            _loginPage = new PageObject.Pages.LoginPage(Driver);
            _loginPage.Open();
        }

        [Given(@"the user types an invalid username")]
        public void GivenTheUserTypesAnInvalidUsername()
        {
            var loginPage = new PageObject.Pages.LoginPage(Driver);
            loginPage.EnterUsername("any_username");
        }

        [Given(@"the user types an invalid password")]
        public void GivenTheUserTypesAnInvalidPassword()
        {
            var loginPage = new PageObject.Pages.LoginPage(Driver);
            loginPage.EnterPassword("password123");
        }

        [Given(@"the user types a valid username")]
        public void GivenTheUserTypesAValidUsername()
        {
            var loginPage = new PageObject.Pages.LoginPage(Driver);
            loginPage.EnterUsername("standard_user");
        }

        [Given(@"the user types a valid password")]
        public void GivenTheUserTypesAValidPassword()
        {
            var loginPage = new PageObject.Pages.LoginPage(Driver);
            loginPage.EnterPassword("secret_sauce");
        }

        [When(@"the user clears the username field")]
        public void WhenTheUserClearsTheUsernameField()
        {
            var loginPage = new PageObject.Pages.LoginPage(Driver);
            loginPage.ClearUsername();
        }

        [When(@"the user clears the password field")]
        public void WhenTheUserClearsThePasswordField()
        {
            var loginPage = new PageObject.Pages.LoginPage(Driver);
            loginPage.ClearPassword();
        }

        [When(@"the user clicks the login button")]
        public void WhenTheUserClicksTheLoginButton()
        {
            var loginPage = new PageObject.Pages.LoginPage(Driver);
            loginPage.ClickLogin();
        }

        [Then(@"an error message should be displayed: ""(.*)""")]
        public void ThenAnErrorMessageShouldBeDisplayed(string expected)
        {
            var actual = _loginPage?.GetErrorMessageText();
            // site prepends "Epic sadface:" so just ensure expected text appears
            Assert.That(actual, Does.Contain(expected));
        }

        [Then(@"the user should see the title: ""(.*)"" in the dashboard")]
        public void ThenTheUserShouldSeeTheTitleInTheDashboard(string expected)
        {
            var actual = _loginPage?.GetTitleHomePage();
            Assert.That(actual, Is.EqualTo(expected));
        }

    }


}