using DiplomaProject.Clients;
using DiplomaProject.Models;
using NUnit.Allure.Attributes;
using RestSharp;

namespace DiplomaProject.Services.API;

public class MilestoneService : IDisposable
{
    private readonly RestClientExtended _client;

    public MilestoneService(RestClientExtended client)
    {
        _client = client;
    }
    
    [AllureStep("Create milestone using API endpoint")]
    public Task<Response> CreateMilestone(string projectCode, Milestone milestone)
    {
        var request = new RestRequest("v1/milestone/{code}", Method.Post)
            .AddUrlSegment("code", projectCode)
            .AddJsonBody(milestone);

        return _client.ExecuteAsync<Response>(request);
    }
    
    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }
}
