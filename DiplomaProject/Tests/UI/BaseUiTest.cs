using DiplomaProject.Clients;
using DiplomaProject.Configuration;
using DiplomaProject.Models.Enum;
using DiplomaProject.Services.API;
using DiplomaProject.Services.UI;
using DiplomaProject.Steps;
using NUnit.Framework;
using OpenQA.Selenium;

namespace DiplomaProject.Tests.UI;

public class BaseUiTest
{
    protected static IWebDriver Driver;
    
    protected LoginStep LoginSteps = null!;
    
    protected ProjectService? ProjectService;
    protected TestCaseService? TestCaseService;
    
    [SetUp]
    public void SetupBrowser()
    {
        Driver = new BrowserService(Configurator.AppSettings.Browser).WebDriver;
        
        var restClient = new RestClientExtended(UserType.Admin);
        ProjectService = new ProjectService(restClient);
        TestCaseService = new TestCaseService(restClient);
        
        LoginSteps = new LoginStep(Driver);
    }
    
    [TearDown]
    public void CloseBrowser()
    {
        Driver.Quit();
    }
}
