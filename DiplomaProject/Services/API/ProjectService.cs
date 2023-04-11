using System.Net;
using DiplomaProject.Clients;
using DiplomaProject.Models;
using NUnit.Allure.Attributes;
using RestSharp;

namespace DiplomaProject.Services.API;

public class ProjectService : IDisposable
{
    private readonly RestClientExtended _client;

    public ProjectService(RestClientExtended client)
    {
        _client = client;
    }

    [AllureStep("Create project using API endpoint")]
    public HttpStatusCode CreateProject(Project project)
    {
        var request = new RestRequest("v1/project", Method.Post)
            .AddJsonBody(project);

        return _client.ExecuteAsync(request).Result.StatusCode;
    }

    [AllureStep("Delete project using API endpoint")]
    public HttpStatusCode DeleteProject(string projectCode)
    {
        var request = new RestRequest("v1/project/{code}", Method.Delete)
            .AddUrlSegment("code", projectCode);

        return _client.ExecuteAsync(request).Result.StatusCode;
    }

    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }
}
