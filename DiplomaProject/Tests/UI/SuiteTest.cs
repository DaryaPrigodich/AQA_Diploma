using DiplomaProject.Configuration;
using DiplomaProject.Fakers;
using DiplomaProject.Models;
using DiplomaProject.Pages;
using FluentAssertions;
using NUnit.Framework;

namespace DiplomaProject.Tests.UI;

public class SuiteTest : BaseUiTest
{
    private Project _project = null!;

    private ProjectOverviewPage _projectOverviewPage = null!;
    
    [SetUp]
    public void SetUpPreconditionSteps()
    {
        _project = new ProjectFaker().Generate();
        ProjectService.CreateProject(_project);
       
        _projectOverviewPage = LoginSteps
            .LoginWithValidCredentials(Configurator.Admin.Username, Configurator.Admin.Password);
    }
    
    [Test]
    [Category("Negative")]
    [TestCase("")]
    public void CreateSuiteWithBlankRequiredInput(string suiteName)
    {
        var isSuiteNotCreated = _projectOverviewPage
            .OpenProjectByTittle(_project.Title)
            .ClickAddSuiteButton()
            .CreateSuiteWithOnlyRequiredInputs(suiteName)
            .IsCreateSuiteFormVisible();
        
        isSuiteNotCreated.Should().BeTrue("Suite has created with blank required suite name input.");
    }
    
    [Test]
    [Category("Boundary")]
    [TestCase(1), TestCase(254), TestCase(255)]
    public void CreateSuitePassingAllowedNumberOfCharacters(int lengthOfSuiteName)
    {
        var lengthOfCreatedSuiteName = _projectOverviewPage
            .OpenProjectByTittle(_project.Title)
            .ClickAddSuiteButton()
            .CreateSuiteWithLengthOfSuiteName<int>(lengthOfSuiteName);
        
        lengthOfCreatedSuiteName.Should().Be(lengthOfSuiteName,"Suite hasn't created with allowed number of characters in suite name input.");
    }
    
    [Test]
    [Category("Boundary")]
    [TestCase(256,"The title may not be greater than 255 characters.")]
    public void CreateSuiteWithInvalidNumberOfCharactersInSuiteNameInput(int lengthOfSuiteName, string expectedErrorMessage)
    {
        var errorMessage = _projectOverviewPage
            .OpenProjectByTittle(_project.Title)
            .ClickAddSuiteButton()
            .CreateSuiteWithLengthOfSuiteName<string>(lengthOfSuiteName);

        errorMessage.Should().Be(expectedErrorMessage,"Suite has created with invalid number of characters in suite name input.");
    }

    [TearDown]
    public void SetUpPostConditionSteps()
    {
        ProjectService.DeleteProject(_project.Code.ToUpper());
    }
}
