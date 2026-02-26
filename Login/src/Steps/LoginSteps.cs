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
        private LoginPage _loginPage;
    }


}