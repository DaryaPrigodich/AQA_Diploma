using OpenQA.Selenium;

namespace DiplomaProject.Wrappers;

public class Table
{
    private UiElement _uiElement;

    public Table(IWebDriver driver,By by)
    {
        _uiElement = new UiElement(driver, by);
    }
    
    public bool Displayed => _uiElement.Displayed;
    
    private IWebElement FindElement(By by)
    {
        return _uiElement.FindElement(by);
    }
    
    public IWebElement GetProjectByTittle(string projectTittle) => 
        FindElement(By.XPath($"//tbody//a[text()='{projectTittle}']"));
}
