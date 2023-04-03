using DiplomaProject.Configuration;
using OpenQA.Selenium;

namespace DiplomaProject.Pages;

public class LoginPage : BasePage
{
    private const string Endpoint = "/login";
    
    private IWebElement EmailInput => Driver.FindElement(By.Id("inputEmail"));
    private IWebElement PasswordInput => Driver.FindElement( By.Id("inputPassword"));
    private IWebElement LoginButton => Driver.FindElement( By.Id("btnLogin"));

    public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }
    
    public LoginPage(IWebDriver driver) : base(driver,false)
    {
    }
    
    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.AppSettings.UiUrl + Endpoint);
    }
 
    public LoginPage InputUsernameAndPassword(string username, string password)
    {
        EmailInput.SendKeys(username);
        PasswordInput.SendKeys(password);

        return this;
    }

    public LoginPage SubmitLoginForm()
    {
        LoginButton.Click();
        
        return this;
    }
}
