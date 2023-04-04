using DiplomaProject.Configuration;
using FluentAssertions;
using NUnit.Framework;

namespace DiplomaProject.Tests.UI;

public class AuthorizationTest: BaseUiTest
{
    [Test]
    [Category("Positive")]
    public void AuthorizationUsingValidCredentials()
    {
        var projectOverviewPage = LoginSteps
            .LoginWithValidCredentials(Configurator.Admin.Username, Configurator.Admin.Password);

        projectOverviewPage.IsPageOpened().Should().BeTrue("User credentials are invalid.");
    }
    
    [Test]
    [Category("Negative")]
    [TestCase("invalid@email", "123", "These credentials do not match our records.")]
    public void AuthorizationUsingInvalidCredentials(string username, string password, string errorMessage)
    {
        var loginErrorMessage = LoginSteps
            .LoginWithInvalidCredentials(username,password);

        loginErrorMessage.Should().Be(errorMessage, "User with invalid credentials has an access to the app.");
    }
}
