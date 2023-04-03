using DiplomaProject.Configuration;
using OpenQA.Selenium;

namespace DiplomaProject.Pages;

public class ProjectOverviewPage : BasePage
{
    private const string Endpoint = "/projects";
    
    public ProjectOverviewPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    public ProjectOverviewPage(IWebDriver driver) : base(driver, false)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.AppSettings.UiUrl + Endpoint);
    }
}
