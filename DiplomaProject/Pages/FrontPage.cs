using DiplomaProject.Configuration;
using DiplomaProject.Wrappers;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace DiplomaProject.Pages;

public class FrontPage: BasePage
{
    private const string Endpoint = "";
    
    private Button LoginButton => new (Driver, By.Id("signin"));
    
    public FrontPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }
    
    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.AppSettings.UiUrl + Endpoint);
    }
    
    [AllureStep("Click \"Login\" button to navigate to the login page")]
    public LoginPage ClickLoginButton()
    {
        LoginButton.Click();

        return new LoginPage(Driver);
    }
}
