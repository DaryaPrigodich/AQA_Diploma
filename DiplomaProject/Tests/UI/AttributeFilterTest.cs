using Diploma.Models.Enum;
using DiplomaProject.Configuration;
using DiplomaProject.Fakers;
using DiplomaProject.Models;
using DiplomaProject.Pages;
using FluentAssertions;
using NUnit.Framework;

namespace DiplomaProject.Tests.UI;

public class AttributeFilterTest : BaseUiTest
{
    private Project _project = null!;
    private TestCase _testCase = null!;

    private ProjectOverviewPage _projectOverviewPage = null!;
    
    [SetUp]
    public void SetUpPreconditionSteps()
    {
        _project = new ProjectFaker().Generate();
        ProjectService.CreateProject(_project);
        
        _testCase = new TestCaseFaker().Generate();
        _testCase.Priority = Convert.ToInt32(Priority.Low);
        TestCaseService.CreateTestCase(_project.Code.ToUpper(), _testCase);
        
        _projectOverviewPage = LoginSteps
            .LoginWithValidCredentials(Configurator.Admin.Username, Configurator.Admin.Password);
    }

    [Test]
    [TestCase("Cases matching your criteria are not found.")]
    public void TestCaseAttributeFilter(string expectedMessage)
    {
        var matchingCasesMessage = _projectOverviewPage
            .OpenProjectByTittle(_project.Title)
            .OpenFilterOptions()
            .SelectOptionByValue(TestCaseFilter.Priority.ToString())
            .SelectCheckBoxByValue(Priority.High.ToString())
            .GetMissingMatchingCasesMessage();
        
        matchingCasesMessage.Should().Be(expectedMessage, "Filter doesn't filter based on selected options.");
    }

    [TearDown]
    public void SetUpPostConditionSteps()
    {
        ProjectService.DeleteProject(_project.Code.ToUpper());
    }
}
