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

    [TearDown]
    public void SetUpPostConditionSteps()
    {
        ProjectService.DeleteProject(_project.Code.ToUpper());
    }
}
