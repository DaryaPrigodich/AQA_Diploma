using DiplomaProject.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DiplomaProject.Services.UI;

public class WaitService
{
    private IWebDriver _driver;

    private readonly WebDriverWait _waitService;

    public WaitService(IWebDriver driver)
    {
        _driver = driver;
        _waitService = new WebDriverWait(_driver, TimeSpan.FromSeconds(Configurator.AppSettings.WaitTimeout));
    }
}
