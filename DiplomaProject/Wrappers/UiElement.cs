using System.Collections.ObjectModel;
using System.Drawing;
using DiplomaProject.Services.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DiplomaProject.Wrappers;

public class UiElement : IWebElement
{
    private IWebElement _webElement;
    private IWebDriver _driver;
    private By _by;
    private Actions _actions;
    private IJavaScriptExecutor _jsExecutor;
    private readonly WaitService _waitService;

    public UiElement(IWebDriver driver, By by)
    {
        _driver = driver;
        _by = by;
        _actions = new Actions(_driver);
        _waitService = new WaitService(_driver);
        _webElement = _waitService.GetExistElement(_by);
        _jsExecutor = (IJavaScriptExecutor)driver;
    }
    
    public IWebElement FindElement(By by)
    {
        return _webElement.FindElement(by);
    }

    public ReadOnlyCollection<IWebElement> FindElements(By by)
    {
        return _webElement.FindElements(by);
    }

    public void Clear()
    {
        _webElement.Clear();
    }

    public void SendKeys(string text)
    {
        _waitService.GetVisibleElement(_by).SendKeys(text);
    }

    public void Submit()
    {
        _webElement.Submit();
    }

    public void Click()
    {
        try
        {
           _waitService.WaitElementIsClickable(_webElement).Click();
        }
        catch (Exception e)
        {
            try
            {
               _actions.MoveToElement(_webElement).Click().Build().Perform();
            }
            catch (Exception exception)
            {
                _jsExecutor.ExecuteScript("arguments[0].click()", _webElement);
            }
        }
    }

    public string GetAttribute(string attributeName)
    {
        return _webElement.GetAttribute(attributeName);
    }

    public string GetDomAttribute(string attributeName)
    {
        return _webElement.GetDomAttribute(attributeName);
    }

    public string GetDomProperty(string propertyName)
    {
        return _webElement.GetDomProperty(propertyName);
    }

    public string GetCssValue(string propertyName)
    {
        return _webElement.GetCssValue(propertyName);
    }

    public ISearchContext GetShadowRoot()
    {
        return _webElement.GetShadowRoot();
    }

    public string TagName => _webElement.TagName;

    public string Text => _webElement.Text;

    public bool Enabled => _webElement.Enabled;

    public bool Selected => _webElement.Selected;

    public Point Location => _webElement.Location;

    public Size Size => _webElement.Size;

    public bool Displayed => _webElement.Displayed;
}
