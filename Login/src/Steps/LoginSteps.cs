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
        private readonly Browser _browser;
        private IWebDriver? _driver;
        private LoginPage _loginPage;

        private IWebDriver Driver =>
        _driver ?? throw new InvalidOperationException("WebDriver is not initialized.");

        public LoginSteps(Browser browser) => _browser = browser;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        
        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = DriverFactory.Create(_browser);
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
            var loginPage = new PageObject.Pages.LoginPage(_driver);
            loginPage.Open();
        }

        [Given(@"the user types an invalid username")]
        public void GivenTheUserTypesAnInvalidUsername()
        {
            var loginPage = new PageObject.Pages.LoginPage(_driver);
            loginPage.EnterUsername("any_username");
        }

        [Given(@"the user types an invalid password")]
        public void GivenTheUserTypesAnInvalidPassword()
        {
            var loginPage = new PageObject.Pages.LoginPage(_driver);
            loginPage.EnterPassword("password123");
        }

        [Given(@"the user types a valid username")]
        public void GivenTheUserTypesAValidUsername()
        {
            var loginPage = new PageObject.Pages.LoginPage(_driver);
            loginPage.EnterUsername("standard_user");
        }

        [Given(@"the user types a valid password")]
        public void GivenTheUserTypesAValidPassword()
        {
            var loginPage = new PageObject.Pages.LoginPage(_driver);
            loginPage.EnterPassword("secret_sauce");
        }

        [When(@"the user clears the username field")]
        public void WhenTheUserClearsTheUsernameField()
        {
            var loginPage = new PageObject.Pages.LoginPage(_driver);
            loginPage.ClearUsername();
        }

        [When(@"the user clears the password field")]
        public void WhenTheUserClearsThePasswordField()
        {
            var loginPage = new PageObject.Pages.LoginPage(_driver);
            loginPage.ClearPassword();
        }

        [When(@"the user clicks the login button")]
        public void WhenTheUserClicksTheLoginButton()
        {
            var loginPage = new PageObject.Pages.LoginPage(_driver);
            loginPage.ClickLogin();
        }

        [Then("@an error message should be displayed: ""(.*)""")]
        public void ThenAnErrorMessageShouldBeDisplayed(string expectedMessage)
        {
            var actual = _loginPage.GetErrorMessageText();
            Assert.AreEqual(expectedMessage, actual);
        }
    }


}