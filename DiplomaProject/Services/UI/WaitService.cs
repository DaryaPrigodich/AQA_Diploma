using DiplomaProject.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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
    
    public IWebElement GetExistElement(By by)
    {
        return _waitService.Until(ExpectedConditions.ElementExists(by));
    }
    
    public IWebElement GetVisibleElement(By by)
    {
        return _waitService.Until(ExpectedConditions.ElementIsVisible(by));
    }
    
    public IWebElement WaitElementIsClickable(IWebElement webElement)
    {
        return _waitService.Until(ExpectedConditions.ElementToBeClickable(webElement));
    }
}
