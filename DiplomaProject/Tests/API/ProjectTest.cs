using System.Net;
using DiplomaProject.Fakers;
using DiplomaProject.Models;
using FluentAssertions;
using NUnit.Framework;

namespace DiplomaProject.Tests.API;

public class ProjectTest : BaseApiTest
{
    private Project _project = null!;
    private TestCase _testCase = null!;

    [Test]
    [Category("Negative")] 
    [TestCase("!@#$")]
    public void CreateProject(string unacceptableCharacters)
    {
        _project = new ProjectFaker().Generate();
        _project.Code = unacceptableCharacters;
        
        var statusCode = ProjectService.CreateProject(_project);

        statusCode.Should().Be(HttpStatusCode.BadRequest, "Project has created with not allowed special characters."); 
    }
}
