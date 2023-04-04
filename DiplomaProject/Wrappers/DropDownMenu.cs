using DiplomaProject.Services.UI;
using OpenQA.Selenium;

namespace DiplomaProject.Wrappers;

public class DropDownMenu
{
    private UiElement _uiElement;
    private readonly WaitService _waitService;

    public DropDownMenu(IWebDriver driver, By by)
    {
        _uiElement = new UiElement(driver, by);
        _waitService = new WaitService(driver);
    }
}
