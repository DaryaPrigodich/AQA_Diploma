using System.Collections.ObjectModel;
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
    
    private IWebElement FindElement(By by)
    {
        return _uiElement.FindElement(by);
    }

    private ReadOnlyCollection<IWebElement> FindElements(By by)
    {
        return _uiElement.FindElements(by);
    }

    private bool IsOptionsVisible()
    {
        try
        {
            var options = FindElements(By.XPath("//ul"));

            _waitService.GetAllVisibleElements(options);

            return true;
        }
        catch
        {
            return false;
        }
    }

    private void OpenDropDownMenu()
    {
        var isOptionVisible = IsOptionsVisible();

        if (isOptionVisible)
        {
            throw new InvalidOperationException("Dropdown is already open.");
        }

        _uiElement.Click();
    }

    public IWebElement GetOptionByValue(string optionValue)
    {
        OpenDropDownMenu();
        
        try
        {
            return FindElement(By.XPath($"//*[text()='{optionValue}']"));
        }
        catch (NoSuchElementException e)
        {
            Console.WriteLine("Option with such value doesn't exist.");

            throw;
        }
    }
}
