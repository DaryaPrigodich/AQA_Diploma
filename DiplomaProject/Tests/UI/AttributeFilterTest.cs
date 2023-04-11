using Allure.Commons;
using Diploma.Models.Enum;
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
[AllureFeature("Attribute filter")]
public class AttributeFilterTest : BaseUiTest
{
    private Project _project = null!;
    private TestCase _testCase = null!;

    private ProjectOverviewPage _projectOverviewPage = null!;
    
    [SetUp]
    [Description("Execution of pre-condition steps")]
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
    [Category("Positive")]
    [AllureSeverity(SeverityLevel.normal)]
    [TestCase("Cases matching your criteria are not found.")]
    [AllureName("Test filter functionality for test case attributes")]
    [AllureTms("https://app.qase.io/project/DIPLOMA?case=3&previewMode=modal&suite=3")]
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
    [Description("Execution of post-condition steps")]
    public void SetUpPostConditionSteps()
    {
        ProjectService.DeleteProject(_project.Code.ToUpper());
    }
}
