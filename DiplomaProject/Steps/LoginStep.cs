using DiplomaProject.Pages;
using OpenQA.Selenium;

namespace DiplomaProject.Steps;

public class LoginStep : BaseStep
{
    public LoginStep(IWebDriver driver) : base(driver)
    {
    }

    public ProjectOverviewPage LoginWithValidCredentials(string username,string password)
    {
        FrontPage.ClickLoginButton()
            .InputUsernameAndPassword(username,password)
            .SubmitLoginForm();
        
        return new ProjectOverviewPage(Driver, false);
    }
    public string LoginWithInvalidCredentials(string username,string password)
    {
        var loginErrorMessage = FrontPage.ClickLoginButton()
            .InputUsernameAndPassword(username,password)
            .SubmitLoginForm()
            .GetLoginErrorMessage();
        
        return loginErrorMessage ;
    }
}
