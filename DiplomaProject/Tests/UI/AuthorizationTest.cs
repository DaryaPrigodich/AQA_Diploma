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
}
