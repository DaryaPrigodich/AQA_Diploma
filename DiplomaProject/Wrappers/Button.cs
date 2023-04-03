using OpenQA.Selenium;

namespace DiplomaProject.Wrappers;

public class Button
{
    private UiElement _uiElement;

    public Button(IWebDriver driver,By by)
    {
        _uiElement = new UiElement(driver, by);
    }
    
    public bool Displayed => _uiElement.Displayed;
    
    public void Click() => _uiElement.Click();
}
