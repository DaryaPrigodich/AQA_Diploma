using System.Net;
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
[AllureFeature("Test Case")]
public class TestCaseTest : BaseApiTest
{
    private Project _project = null!;
   
    private int _testCaseId;

    [SetUp]
    [Description("Execution of pre-condition steps")]
    public void SetUpPreconditionSteps()
    {
        _project = new ProjectFaker().Generate();
        ProjectService.CreateProject(_project);
    }

    [Test]
    [Category("Positive")]
    [AllureSeverity(SeverityLevel.blocker)]
    [AllureName("Create a test case using API endpoint")]
    [AllureTms("https://app.qase.io/project/DIPLOMA?case=8&previewMode=modal&suite=9")]
    public void CreateTestCase()
    {
        var testCaseToCreate = new TestCaseFaker().Generate();
        var response = TestCaseService
            .CreateTestCase(_project.Code.ToUpper(), testCaseToCreate).Result;
        
        _testCaseId = response.Result.Id;
        
       response.Status.Should().BeTrue("Test case hasn't created.");
    }
    
    [Test]
    [Category("Positive")]
    [AllureSeverity(SeverityLevel.blocker)]
    [AllureName("Get a test case using API endpoint")]
    [AllureTms("https://app.qase.io/project/DIPLOMA?case=9&previewMode=modal&suite=9")]
    public void GetTestCase()
    {
        var testCaseToCreate = new TestCaseFaker().Generate();
        _testCaseId = TestCaseService
            .CreateTestCase(_project.Code.ToUpper(), testCaseToCreate).Result.Result.Id;

        var response = TestCaseService.GetTestCase(_project.Code.ToUpper(), _testCaseId).Result;

        response.Result.Id.Should().Be(_testCaseId, "Test case hasn't received.");
    }
    
    [Test]
    [Category("Positive")]
    [AllureSeverity(SeverityLevel.blocker)]
    [AllureName("Update a test case using API endpoint")]
    [AllureTms("https://app.qase.io/project/DIPLOMA?case=10&previewMode=modal&suite=9")]
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
    [Category("Positive")]
    [AllureSeverity(SeverityLevel.blocker)]
    [AllureName("Delete a test case using API endpoint")]
    [AllureTms("https://app.qase.io/project/DIPLOMA?case=11&previewMode=modal&suite=9")]
    public void DeleteTestCase()
    {
        var testCaseToCreate = new TestCaseFaker().Generate();
        _testCaseId = TestCaseService
            .CreateTestCase(_project.Code.ToUpper(), testCaseToCreate).Result.Result.Id;

        var statusCode = TestCaseService.DeleteTestCase(_project.Code.ToUpper(), _testCaseId);

        statusCode.Should().Be(HttpStatusCode.OK, "Test case hasn't deleted.");
    }
    
    [TearDown]
    [Description("Execution of post-condition steps")]
    public void SetUpPostConditionSteps()
    {
        ProjectService.DeleteProject(_project.Code.ToUpper());
    }
}
