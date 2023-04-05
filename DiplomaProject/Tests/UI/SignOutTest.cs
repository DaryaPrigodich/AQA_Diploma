using DiplomaProject.Configuration;
using DiplomaProject.Pages;
using FluentAssertions;
using NUnit.Framework;

namespace DiplomaProject.Tests.UI;

public class SignOutTest : BaseUiTest
{
    private ProjectOverviewPage _projectOverviewPage = null!;
    
    private LoginPage _loginPage = null!;

    [SetUp]
    public void SetUpPreconditionSteps()
    {
        _projectOverviewPage = LoginSteps
            .LoginWithValidCredentials(Configurator.Admin.Username, Configurator.Admin.Password);
    }

    [Test]
    [Category("Positive")][Category("Security")]
    [TestCase("Sign out")]
    public void SignOut(string optionValue)
    {
        _loginPage = _projectOverviewPage
            .OpenUserMenu()
            .SelectUserMenuOptionByValue(optionValue);

        _loginPage.IsPageOpened().Should().BeTrue("User hasn't logged out.");
    }
}
