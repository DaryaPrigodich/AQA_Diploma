using DiplomaProject.Configuration;
using OpenQA.Selenium;

namespace DiplomaProject.Pages;

public class FrontPage: BasePage
{
    private const string Endpoint = "";
    
    private IWebElement LoginButton => Driver.FindElement(By.Id("signin"));
    
    public FrontPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }
    
    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.AppSettings.UiUrl + Endpoint);
    }
    
    public void ClickLoginButton()
    {
        LoginButton.Click();
    }
}
