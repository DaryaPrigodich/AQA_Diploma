using DiplomaProject.Configuration;
using DiplomaProject.Wrappers;
using OpenQA.Selenium;

namespace DiplomaProject.Pages;

public class ProjectPage : BasePage
{
    private const string Endpoint = "project/";
    
    private Button AddFilter => new (Driver, By.ClassName("add-filter-button"));
    private DropDownMenu FilterOptions => new (Driver, By.XPath("//*[@class='filters-menu WHRMzV']"));
    private CheckBox PriorityOptions => new (Driver, By.XPath("//*[@class='filter-checkboxes']"));
    private UiElement MissingMatchingCasesMessage => new (Driver, By.XPath("//*[contains(text(),'not found')]"));

    public ProjectPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }
    
    public ProjectPage(IWebDriver driver) : base(driver,false)
    {
    }
    
    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.AppSettings.UiUrl + Endpoint);
    }

    public ProjectPage OpenFilterOptions()
    {
        AddFilter.Click();

        return this;
    }
}
