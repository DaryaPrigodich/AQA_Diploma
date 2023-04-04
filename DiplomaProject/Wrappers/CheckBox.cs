using OpenQA.Selenium;

namespace DiplomaProject.Wrappers;

public class CheckBox
{
    private UiElement _uiElement;

    public CheckBox(IWebDriver driver, By by)
    {
        _uiElement = new UiElement(driver, by);
    }
}
