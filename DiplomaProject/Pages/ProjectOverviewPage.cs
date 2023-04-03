using DiplomaProject.Configuration;
using OpenQA.Selenium;

namespace DiplomaProject.Pages;

public class ProjectOverviewPage : BasePage
{
    private const string Endpoint = "/projects";
    
    private IWebElement Projects => Driver.FindElement(By.XPath("//table"));

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
    
    public bool IsPageOpened()
    {
        try
        {
            return Projects.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}
