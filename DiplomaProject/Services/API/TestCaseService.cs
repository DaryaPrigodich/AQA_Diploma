using System.Net;
using DiplomaProject.Clients;
using DiplomaProject.Models;
using RestSharp;

namespace DiplomaProject.Services.API;

public class TestCaseService : IDisposable
{
    private readonly RestClientExtended _client;

    public TestCaseService(RestClientExtended client)
    {
        _client = client;
    }
    
    public Task<Response> CreateTestCase(string projectCode, TestCase testCase)
    {
        var request = new RestRequest("v1/case/{code}", Method.Post)
            .AddUrlSegment("code", projectCode)
            .AddJsonBody(testCase);

        return _client.ExecuteAsync<Response>(request);
    }
    
    public Task<Response> GetTestCase(string projectCode, int testCaseId)
    {
        var request = new RestRequest("v1/case/{code}/{id}")
            .AddUrlSegment("code", projectCode)
            .AddUrlSegment("id", testCaseId);

        return _client.ExecuteAsync<Response>(request);
    }
    
    public Task<Response> UpdateTestCase(string projectCode, int testCaseId, TestCase testCase)
    {
        var request = new RestRequest("v1/case/{code}/{id}", Method.Patch)
            .AddUrlSegment("code", projectCode)
            .AddUrlSegment("id", testCaseId)
            .AddJsonBody(testCase);

        return _client.ExecuteAsync<Response>(request);
    }
    
    public HttpStatusCode DeleteTestCase(string projectCode, int testCaseId)
    {
        var request = new RestRequest("v1/case/{code}/{id}", Method.Delete)
            .AddUrlSegment("code", projectCode)
            .AddUrlSegment("id", testCaseId);

        return _client.ExecuteAsync(request).Result.StatusCode;
    }
  
    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }
}
