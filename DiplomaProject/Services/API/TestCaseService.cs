using System.Net;
using DiplomaProject.Clients;
using DiplomaProject.Models;
using NUnit.Allure.Attributes;
using RestSharp;

namespace DiplomaProject.Services.API;

public class TestCaseService : IDisposable
{
    private readonly RestClientExtended _client;

    public TestCaseService(RestClientExtended client)
    {
        _client = client;
    }
    
    [AllureStep("Create test case using API endpoint")]
    public Task<Response> CreateTestCase(string projectCode, TestCase testCase)
    {
        var request = new RestRequest("v1/case/{code}", Method.Post)
            .AddUrlSegment("code", projectCode)
            .AddJsonBody(testCase);

        return _client.ExecuteAsync<Response>(request);
    }
    
    [AllureStep("Get test case using API endpoint")]
    public Task<Response> GetTestCase(string projectCode, int testCaseId)
    {
        var request = new RestRequest("v1/case/{code}/{id}")
            .AddUrlSegment("code", projectCode)
            .AddUrlSegment("id", testCaseId);

        return _client.ExecuteAsync<Response>(request);
    }
    
    [AllureStep("Update test case using API endpoint")]
    public Task<Response> UpdateTestCase(string projectCode, int testCaseId, TestCase testCase)
    {
        var request = new RestRequest("v1/case/{code}/{id}", Method.Patch)
            .AddUrlSegment("code", projectCode)
            .AddUrlSegment("id", testCaseId)
            .AddJsonBody(testCase);

        return _client.ExecuteAsync<Response>(request);
    }
    
    [AllureStep("Delete test case using API endpoint")]
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
