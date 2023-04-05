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
  
    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }
}
