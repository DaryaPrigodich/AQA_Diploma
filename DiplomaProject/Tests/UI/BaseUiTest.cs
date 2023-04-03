using DiplomaProject.Configuration;
using DiplomaProject.Services.UI;
using DiplomaProject.Steps;
using NUnit.Framework;
using OpenQA.Selenium;

namespace DiplomaProject.Tests.UI;

public class BaseUiTest
{
    protected static IWebDriver Driver;
    
    protected LoginStep LoginSteps = null!;

    private WaitService _waitService;
    
    [SetUp]
    public void Setup()
    {
        Driver = new BrowserService(Configurator.AppSettings.Browser).WebDriver;
        _waitService = new WaitService(Driver);
        
        LoginSteps = new LoginStep(Driver);
    }
    
    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
}
