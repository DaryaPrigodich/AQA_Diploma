using DiplomaProject.Pages;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace DiplomaProject.Steps;

public class LoginStep : BaseStep
{
    public LoginStep(IWebDriver driver) : base(driver)
    {
    }

    [AllureStep("Log in with valid credentials, login - {0} and password - {1}")]
    public ProjectOverviewPage LoginWithValidCredentials(string username,string password)
    {
        FrontPage.ClickLoginButton()
            .InputUsernameAndPassword(username,password)
            .SubmitLoginForm();
        
        return new ProjectOverviewPage(Driver);
    }
    
    [AllureStep("Log in with invalid credentials, login - {0} and password - {1}")]
    public string LoginWithInvalidCredentials(string username,string password)
    {
        var loginErrorMessage = FrontPage.ClickLoginButton()
            .InputUsernameAndPassword(username,password)
            .SubmitLoginForm()
            .GetLoginErrorMessage();
        
        return loginErrorMessage ;
    }
}
