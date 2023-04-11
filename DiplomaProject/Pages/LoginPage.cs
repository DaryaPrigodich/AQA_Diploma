using DiplomaProject.Configuration;
using DiplomaProject.Wrappers;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace DiplomaProject.Pages;

public class LoginPage : BasePage
{
    private const string Endpoint = "/login";
    
    private UiElement EmailInput => new (Driver, By.Id("inputEmail"));
    private UiElement PasswordInput => new (Driver, By.Id("inputPassword"));
    private Button Login => new (Driver, By.Id("btnLogin"));
    private UiElement ErrorMessage => new (Driver, By.XPath("//*[@data-qase-test='login-error']"));

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
    
    public bool IsPageOpened()
    {
        try
        {
            return Login.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    [AllureStep("In the login form enter login \"{0}\" and password \"{1}\"")]
    public LoginPage InputUsernameAndPassword(string username, string password)
    {
        EmailInput.SendKeys(username);
        PasswordInput.SendKeys(password);

        return this;
    }

    [AllureStep("Click \"Login\" button")]
    public LoginPage SubmitLoginForm()
    {
        Login.Click();
        
        return this;
    }
    
    public string GetLoginErrorMessage()
    {
        return ErrorMessage.Text; 
    }
}
