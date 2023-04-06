using DiplomaProject.Clients;
using DiplomaProject.Models.Enum;
using DiplomaProject.Services.API;
using NUnit.Framework;

namespace DiplomaProject.Tests.API;

public class BaseApiTest
{
    protected ProjectService ProjectService;
    protected TestCaseService TestCaseService;
    protected MilestoneService MilestoneService;

    [OneTimeSetUp]
    public void SetUpApi()
    {
        var restClient = new RestClientExtended(UserType.Admin);

        ProjectService = new ProjectService(restClient);
        TestCaseService = new TestCaseService(restClient);
        MilestoneService = new MilestoneService(restClient);
    }
}
