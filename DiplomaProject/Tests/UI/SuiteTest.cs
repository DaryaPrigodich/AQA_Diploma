using Allure.Commons;
using DiplomaProject.Configuration;
using DiplomaProject.Fakers;
using DiplomaProject.Models;
using DiplomaProject.Pages;
using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace DiplomaProject.Tests.UI;

[AllureNUnit]
[AllureParentSuite("UI")]
[AllureFeature("Suite Case")]
public class SuiteTest : BaseUiTest
{
    private Project _project = null!;

    private ProjectOverviewPage _projectOverviewPage = null!;
    
    [SetUp]
    [Description("Execution of pre-condition steps")]
    public void SetUpPreconditionSteps()
    {
        _project = new ProjectFaker().Generate();
        ProjectService.CreateProject(_project);
       
        _projectOverviewPage = LoginSteps
            .LoginWithValidCredentials(Configurator.Admin.Username, Configurator.Admin.Password);
    }
    
    [Test]
    [Category("Negative")][Category("Boundary")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureName("Leave required input field blank")]
    [AllureTms("https://app.qase.io/project/DIPLOMA?case=4&previewMode=modal&suite=4")]
    public void CreateSuiteWithBlankRequiredInput()
    {
        var isSuiteNotCreated = _projectOverviewPage
            .OpenProjectByTittle(_project.Title)
            .ClickAddSuiteButton()
            .ClickCreateButton()
            .IsCreateSuiteFormVisible();
        
        isSuiteNotCreated.Should().BeTrue("Suite has created with blank required suite name input.");
    }
    
    [Test]
    [Category("Positive")][Category("Boundary")]
    [AllureSeverity(SeverityLevel.critical)]
    [TestCase(1), TestCase(254), TestCase(255)]
    [AllureName("Create a new suite with an allowed lenght of name")]
    [AllureTms("https://app.qase.io/project/DIPLOMA?case=5&previewMode=modal&suite=6")]
    public void CreateSuitePassingAllowedNumberOfCharacters(int lengthOfSuiteName)
    {
        var lengthOfCreatedSuiteName = _projectOverviewPage
            .OpenProjectByTittle(_project.Title)
            .ClickAddSuiteButton()
            .CreateSuiteWithLengthOfSuiteName<int>(lengthOfSuiteName);
        
        lengthOfCreatedSuiteName.Should().Be(lengthOfSuiteName,"Suite hasn't created with allowed number of characters in suite name input.");
    }
    
    [Test]
    [Category("Negative")][Category("Boundary")]
    [AllureSeverity(SeverityLevel.critical)]
    [TestCase(256,"The title may not be greater than 255 characters.")]
    [AllureName("Create a new suite with a not allowed lenght of name")]
    [AllureTms("https://app.qase.io/project/DIPLOMA?case=6&previewMode=modal&suite=6")]
    public void CreateSuiteWithInvalidNumberOfCharactersInSuiteNameInput(int lengthOfSuiteName, string expectedErrorMessage)
    {
        var errorMessage = _projectOverviewPage
            .OpenProjectByTittle(_project.Title)
            .ClickAddSuiteButton()
            .CreateSuiteWithLengthOfSuiteName<string>(lengthOfSuiteName);

        errorMessage.Should().Be(expectedErrorMessage,"Suite has created with invalid number of characters in suite name input.");
    }

    [TearDown]
    [Description("Execution of post-condition steps")]
    public void SetUpPostConditionSteps()
    {
        ProjectService.DeleteProject(_project.Code.ToUpper());
    }
}
