using Allure.Commons;
using DiplomaProject.Fakers;
using DiplomaProject.Models;
using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace DiplomaProject.Tests.API;

[AllureNUnit]
[AllureParentSuite("API")]
[AllureFeature("Milestone")]
public class MilestoneTest : BaseApiTest
{
    private Project _project = null!;
    private Milestone _milestone = null!;

    [SetUp]
    [Description("Execution of pre-condition steps")]
    public void SetUpPreconditionSteps()
    {
        _project = new ProjectFaker().Generate();
        
        ProjectService.CreateProject(_project);
    }

    [Test]
    [Category("Positive")][Category("Boundary")]
    [AllureSeverity(SeverityLevel.blocker)]
    [TestCase(1), TestCase(254), TestCase(255)]
    [AllureName("Create a milestone passing allowed number of characters")]
    [AllureTms("https://app.qase.io/project/DIPLOMA?case=16&previewMode=modal&suite=11")]
    public void CreateMilestonePassingAllowedNumberOfCharacters(int lengthOfTitle)
    {
        _milestone = new MilestoneFaker(lengthOfTitle).Generate();

        var response = MilestoneService.CreateMilestone(_project.Code.ToUpper(), _milestone).Result;

        response.Status.Should().BeTrue("Milestone hasn't created with allowed number of characters in title input.");
    }

    [Test]
    [Category("Negative")][Category("Boundary")]
    [AllureSeverity(SeverityLevel.blocker)]
    [TestCase(0), TestCase(256)]
    [AllureName("Create a milestone passing not allowed number of characters")]
    [AllureTms("https://app.qase.io/project/DIPLOMA?case=17&previewMode=modal&suite=11")]
    public void CreateMilestonePassingNotAllowedNumberOfCharacters(int lengthOfTitle)
    {
        _milestone = new MilestoneFaker(lengthOfTitle).Generate();

        var response = MilestoneService.CreateMilestone(_project.Code.ToUpper(), _milestone).Result;

        response.Status.Should().BeFalse("Milestone has created with not allowed number of characters in title input.");
    }
    
    [TearDown]
    [Description("Execution of post-condition steps")]
    public void SetUpPostConditionSteps()
    {
        ProjectService.DeleteProject(_project.Code.ToUpper());
    }
}
