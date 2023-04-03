using DiplomaProject.Configuration;
using DiplomaProject.Wrappers;
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
    
    public LoginPage ClickLoginButton()
    {
        LoginButton.Click();

        return new LoginPage(Driver, false);
    }
}
