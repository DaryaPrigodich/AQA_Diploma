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
    
    [Test]
    [Order(2)]
    public void GetTestCase()
    {
        var response = TestCaseService.GetTestCase(_project.Code.ToUpper(), _testCaseId).Result;

        response.Result.Id.Should().Be(_testCaseId, "Test case hasn't received.");
    }
    
    [Test]
    [Order(3)]
    public void UpdateTestCase()
    {
        var testCaseToUpdate = new TestCaseFaker().Generate();
        
        var response = TestCaseService
            .UpdateTestCase(_project.Code.ToUpper(),_testCaseId, testCaseToUpdate).Result;
        
        response.Status.Should().BeTrue("Test case hasn't updated.");
    }
    
    [OneTimeTearDown]
    public void SetUpPostConditionSteps()
    {
        ProjectService.DeleteProject(_project.Code.ToUpper());
    }
}
