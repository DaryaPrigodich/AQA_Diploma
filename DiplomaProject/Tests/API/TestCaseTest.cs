using System.Net;
using DiplomaProject.Fakers;
using DiplomaProject.Models;
using FluentAssertions;
using NUnit.Framework;

namespace DiplomaProject.Tests.API;

public class TestCaseTest : BaseApiTest
{
    private Project _project = null!;
   
    private int _testCaseId;

    [OneTimeSetUp]
    public void SetUpPreconditionSteps()
    {
        _project = new ProjectFaker().Generate();
        ProjectService.CreateProject(_project);
    }

    [Test]
    [Order(1)]
    public void CreateTestCase()
    {
        var testCaseToCreate = new TestCaseFaker().Generate();
        var response = TestCaseService.CreateTestCase(_project.Code.ToUpper(), testCaseToCreate).Result;
        
        _testCaseId = response.Result.Id;
        
       response.Status.Should().BeTrue("Test case hasn't created.");
    }
}
