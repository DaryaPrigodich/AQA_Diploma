using OpenQA.Selenium;

namespace DiplomaProject.Wrappers;

public class Table
{
    private UiElement _uiElement;

    public Table(IWebDriver driver,By by)
    {
        _uiElement = new UiElement(driver, by);
    }
    
    private IWebElement FindElement(By by)
    {
        return _uiElement.FindElement(by);
    }
    
    public bool Displayed => _uiElement.Displayed;
    
    public IWebElement GetProjectByTittle(string projectTittle) => FindElement(By.XPath($"//tbody//a[text()='{projectTittle}']"));

    
    
    
   

    /*public int CountRow()
    {
        return _rowList.Count;
    }

    private ReadOnlyCollection<IWebElement> Headers => _uiElement.FindElements(By.TagName("th"));
    private ReadOnlyCollection<IWebElement> Rows => _uiElement.FindElements(By.XPath("//tbody/tr"));
    private ReadOnlyCollection<IWebElement> Cells(IWebElement row) => row.FindElements(By.TagName("td"));

    public IWebElement GetElementFromCell(string columnHeader, string columnValue, string targetColumnHeader)
    {
        var indexColumnHeader = Headers.TakeWhile(header => !header.Text.Normalize().Equals(columnHeader)).Count();
        var indexTargetColumnHeader = Headers.TakeWhile(header => !header.Text.Normalize().Equals(targetColumnHeader)).Count();

        foreach (var row in Rows)
        {
            var cells = Cells(row);
            if (cells[indexColumnHeader].Text.Normalize().Equals(columnValue))
            {
                return cells[indexTargetColumnHeader];
            }
        }
        return null;
    }*/
}
