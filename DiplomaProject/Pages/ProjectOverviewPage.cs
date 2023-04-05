using DiplomaProject.Configuration;
using DiplomaProject.Wrappers;
using OpenQA.Selenium;

namespace DiplomaProject.Pages;

public class ProjectOverviewPage : BasePage
{
    private const string Endpoint = "/projects";
    
    private Table Projects => new(Driver, By.XPath("//table"));
    private DropDownMenu UserMenu => new(Driver, By.XPath("//*[@class='Eb2vGG']"));

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
    
    public ProjectPage OpenProjectByTittle(string projectTittle)
    {
        Projects.GetProjectByTittle(projectTittle).Click();

        return new ProjectPage(Driver, false);
    }
    
    public ProjectOverviewPage OpenUserMenu()
    {
        UserMenu.OpenDropDownMenu();

        return this;
    }
    
    public LoginPage SelectUserMenuOptionByValue(string optionValue)
    {
        UserMenu.GetOptionByValue(optionValue).Click();

        return new LoginPage(Driver, false);
    }
}
