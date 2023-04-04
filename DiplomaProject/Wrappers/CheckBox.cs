using OpenQA.Selenium;

namespace DiplomaProject.Wrappers;

public class CheckBox
{
    private UiElement _uiElement;

    public CheckBox(IWebDriver driver, By by)
    {
        _uiElement = new UiElement(driver, by);
    }
    
    private IWebElement FindElement(By by)
    {
        return _uiElement.FindElement(by);
    }

    public IWebElement GetCheckBoxByValue(string checkBoxValue)
    {
        try
        {
            return FindElement(By.XPath($"//*[text()='{checkBoxValue}']"));
        }
        catch (NoSuchElementException e)
        {
            Console.WriteLine("CheckBox with such value doesn't exist.");
            
            throw;
        }
    }
}
