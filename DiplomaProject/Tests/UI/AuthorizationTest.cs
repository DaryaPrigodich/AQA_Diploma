using Allure.Commons;
using DiplomaProject.Configuration;
using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace DiplomaProject.Tests.UI;

[AllureNUnit]
[AllureParentSuite("UI")]
[AllureFeature("Login")]
public class AuthorizationTest: BaseUiTest
{
    [Test]
    [Category("Positive")][Category("Security")]
    [AllureSeverity(SeverityLevel.blocker)]
    [AllureName("Authorization with valid credentials")]
    [AllureTms("https://app.qase.io/project/DIPLOMA?case=1&previewMode=modal&suite=3")]
    public void AuthorizationUsingValidCredentials()
    {
        var projectOverviewPage = LoginSteps
            .LoginWithValidCredentials(Configurator.Admin.Username, Configurator.Admin.Password);

        projectOverviewPage.IsPageOpened().Should().BeTrue("User credentials are invalid.");
    }
    
    [Test]
    [Category("Negative")][Category("Security")]
    [AllureSeverity(SeverityLevel.blocker)]
    [AllureName("Authorization with invalid credentials")]
    [TestCase("invalid@email", "123", "These credentials do not match our records.")]
    [AllureTms("https://app.qase.io/project/DIPLOMA?case=2&previewMode=modal&suite=4")]
    public void AuthorizationUsingInvalidCredentials(string username, string password, string errorMessage)
    {
        var loginErrorMessage = LoginSteps
            .LoginWithInvalidCredentials(username,password);

        loginErrorMessage.Should().Be(errorMessage, "User with invalid credentials has an access to the app.");
    }
}
