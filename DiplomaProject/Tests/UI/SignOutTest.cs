using Allure.Commons;
using DiplomaProject.Configuration;
using DiplomaProject.Pages;
using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace DiplomaProject.Tests.UI;

[AllureNUnit]
[AllureParentSuite("UI")]
[AllureFeature("Sign out")]
public class SignOutTest : BaseUiTest
{
    private ProjectOverviewPage _projectOverviewPage = null!;
    
    private LoginPage _loginPage = null!;

    [SetUp]
    [Description("Execution of pre-condition steps")]
    public void SetUpPreconditionSteps()
    {
        _projectOverviewPage = LoginSteps
            .LoginWithValidCredentials(Configurator.Admin.Username, Configurator.Admin.Password);
    }

    [Test]
    [Category("Positive")][Category("Security")]
    [AllureSeverity(SeverityLevel.blocker)]
    [TestCase("Sign out")]
    [AllureName("Sign out from the application")]
    [AllureTms("https://app.qase.io/project/DIPLOMA?case=7&previewMode=modal&suite=7")]
    public void SignOut(string optionValue)
    {
        _loginPage = _projectOverviewPage
            .OpenUserMenu()
            .SelectUserMenuOptionByValue(optionValue);

        _loginPage.IsPageOpened().Should().BeTrue("User hasn't logged out.");
    }
}
