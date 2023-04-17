using DiplomaProject.Configuration;
using DiplomaProject.Wrappers;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace DiplomaProject.Pages;

public class ProjectPage : BasePage
{
    private const string Endpoint = "project/";
    
    private UiElement AddFilterButton => new (Driver, By.ClassName("add-filter-button"));
    private DropDownMenu FilterOptions => new (Driver, By.XPath("//*[contains(@class,'filters-menu')]"));
    private CheckBox PriorityOptions => new (Driver, By.XPath("//*[@class='filter-checkboxes']"));
    private UiElement MissingMatchingCasesMessage => new (Driver, By.XPath("//*[contains(text(),'not found')]"));
    private UiElement AddSuiteButton => new(Driver, By.Id("create-suite-button"));
    private UiElement SuiteNameInput => new(Driver, By.Id("title"));
    private UiElement CreateSuiteButton => new (Driver, By.XPath("//*[@type='submit']"));
    private UiElement CreateSuiteForm => new (Driver, By.XPath("(//*[@role='dialog'])[2]"));
    private UiElement SideSuite => new (Driver, By.XPath("//*[contains(@class,'Pane')]//a"));
    private UiElement ErrorMessage => new (Driver, By.XPath("//*[contains(text(),'255 characters')]"));
    
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

    [AllureStep("Click on \"AddFilter\" button")]
    public ProjectPage OpenFilterOptions()
    {
        AddFilterButton.Click();

        return this;
    }
    
    [AllureStep("Click on \"{0}\" attribute")]
    public ProjectPage SelectOptionByValue(string optionValue)
    {
        FilterOptions.GetOptionByValue(optionValue).Click();
        
        return this;
    }

    [AllureStep("Click on \"{0}\" checkbox")]
    public ProjectPage SelectCheckBoxByValue(string checkBoxValue)
    {
        PriorityOptions.GetCheckBoxByValue(checkBoxValue).Click();
        
        return this;
    }

    public string GetMissingMatchingCasesMessage()
    {
        return MissingMatchingCasesMessage.Text;
    }
    
    [AllureStep("Click on \"+Suite\" button")]
    public ProjectPage ClickAddSuiteButton()
    {
        AddSuiteButton.Click();

        return this;
    }

    [AllureStep("Click \"Create\" button")]
    public ProjectPage ClickCreateButton()
    {
        CreateSuiteButton.Click();
        
        return this;
    }

    public bool IsCreateSuiteFormVisible()
    {
        return CreateSuiteForm.Displayed;
    }
    
    [AllureStep("Create suite with \"{0}\" characters in suite name input")]
    public T CreateSuiteWithLengthOfSuiteName<T>(int lengthOfSuiteName)
    {
        const int MaxAllowableLength = 255;
        
        var suiteName = new Bogus.Faker().Lorem.Letter(lengthOfSuiteName);

        SuiteNameInput.SendKeys(suiteName);
        CreateSuiteButton.Click();

        if (lengthOfSuiteName > MaxAllowableLength)
        {
            return (T)Convert.ChangeType(ErrorMessage.Text, typeof(T));
        }
        
        return (T)Convert.ChangeType(SideSuite.Text.Length, typeof(T));
    }
}
