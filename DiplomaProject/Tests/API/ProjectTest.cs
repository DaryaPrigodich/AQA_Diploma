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
[AllureFeature("Project")]
public class ProjectTest : BaseApiTest
{
    private Project _project = null!;
    private TestCase _testCase = null!;

    [Test]
    [Category("Negative")][Category("Boundary")]
    [AllureSeverity(SeverityLevel.critical)]
    [TestCase("!@#$")]
    [AllureName("Create a project passing not allowed special characters")]
    [AllureTms("https://app.qase.io/project/DIPLOMA?case=14&previewMode=modal&suite=10")]
    public void CreateProjectPassingNotAllowedCharacters(string unacceptableCharacters)
    {
        _project = new ProjectFaker().Generate();
        _project.Code = unacceptableCharacters;
        
        var statusCode = ProjectService.CreateProject(_project);

        statusCode.Should().Be(HttpStatusCode.BadRequest, "Project has created with not allowed special characters."); 
    }
    
    [Test]
    [Category("Negative")]
    [AllureSeverity(SeverityLevel.normal)]
    [TestCase("nonexistent project")]
    [AllureName("Delete a nonexistent project")]
    [AllureTms("https://app.qase.io/project/DIPLOMA?case=15&previewMode=modal&suite=10")]
    public void DeleteNonexistentProject(string nonexistentProjectCode)
    {
        var statusCode = ProjectService.DeleteProject(nonexistentProjectCode);

        statusCode.Should().Be(HttpStatusCode.NotFound,"Status code is invalid.");
    }
}
