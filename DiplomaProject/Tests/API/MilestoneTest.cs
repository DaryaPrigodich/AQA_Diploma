using DiplomaProject.Fakers;
using DiplomaProject.Models;
using FluentAssertions;
using NUnit.Framework;

namespace DiplomaProject.Tests.API;

public class MilestoneTest : BaseApiTest
{
    private Project _project = null!;
    private Milestone _milestone = null!;

    [SetUp]
    public void SetUpPreconditionSteps()
    {
        _project = new ProjectFaker().Generate();
        
        ProjectService.CreateProject(_project);
    }

    [Test]
    [Category("Positive")][Category("Boundary")]
    [TestCase(1), TestCase(254), TestCase(255)]
    public void CreateMilestonePassingAllowedNumberOfCharacters(int lengthOfTitle)
    {
        _milestone = new MilestoneFaker(lengthOfTitle).Generate();

        var response = MilestoneService.CreateMilestone(_project.Code.ToUpper(), _milestone).Result;

        response.Status.Should().BeTrue("Milestone hasn't created with allowed number of characters in title input.");
    }

    [TearDown]
    public void SetUpPostConditionSteps()
    {
        ProjectService.DeleteProject(_project.Code.ToUpper());
    }
}
