using DiplomaProject.Pages;
using OpenQA.Selenium;

namespace DiplomaProject.Steps;

public class LoginStep : BaseStep
{
    public LoginStep(IWebDriver driver) : base(driver)
    {
    }

    public ProjectOverviewPage LoginWithValidData(string username,string password)
    {
        FrontPage.ClickLoginButton()
            .InputUsernameAndPassword(username,password)
            .SubmitLoginForm();
        
        return new ProjectOverviewPage(Driver, false);
    }
}
