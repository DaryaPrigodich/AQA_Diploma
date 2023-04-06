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

    [SetUp]
    public void SetUpPreconditionSteps()
    {
        _project = new ProjectFaker().Generate();
        ProjectService.CreateProject(_project);
    }

    [Test]
    public void CreateTestCase()
    {
        var testCaseToCreate = new TestCaseFaker().Generate();
        var response = TestCaseService
            .CreateTestCase(_project.Code.ToUpper(), testCaseToCreate).Result;
        
        _testCaseId = response.Result.Id;
        
       response.Status.Should().BeTrue("Test case hasn't created.");
    }
    
    [Test]
    public void GetTestCase()
    {
        var testCaseToCreate = new TestCaseFaker().Generate();
        _testCaseId = TestCaseService
            .CreateTestCase(_project.Code.ToUpper(), testCaseToCreate).Result.Result.Id;

        var response = TestCaseService.GetTestCase(_project.Code.ToUpper(), _testCaseId).Result;

        response.Result.Id.Should().Be(_testCaseId, "Test case hasn't received.");
    }
    
    [Test]
    public void UpdateTestCase()
    {
        var testCaseToCreate = new TestCaseFaker().Generate();
        _testCaseId = TestCaseService
            .CreateTestCase(_project.Code.ToUpper(), testCaseToCreate).Result.Result.Id;

        var testCaseToUpdate = new TestCaseFaker().Generate();
        
        var response = TestCaseService
            .UpdateTestCase(_project.Code.ToUpper(),_testCaseId, testCaseToUpdate).Result;
        
        response.Status.Should().BeTrue("Test case hasn't updated.");
    }
    
    [Test]
    public void DeleteTestCase()
    {
        var testCaseToCreate = new TestCaseFaker().Generate();
        _testCaseId = TestCaseService
            .CreateTestCase(_project.Code.ToUpper(), testCaseToCreate).Result.Result.Id;

        var statusCode = TestCaseService.DeleteTestCase(_project.Code.ToUpper(), _testCaseId);

        statusCode.Should().Be(HttpStatusCode.OK, "Test case hasn't deleted.");
    }
    
    [TearDown]
    public void SetUpPostConditionSteps()
    {
        ProjectService.DeleteProject(_project.Code.ToUpper());
    }
}
