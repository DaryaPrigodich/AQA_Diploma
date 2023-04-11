﻿using DiplomaProject.Pages;
using OpenQA.Selenium;

namespace DiplomaProject.Steps;

public class BaseStep
{
    protected IWebDriver Driver;
    
    protected FrontPage FrontPage;

    public BaseStep(IWebDriver driver)
    {
        Driver = driver;
        
        FrontPage = new FrontPage(Driver,true);
    }
}
