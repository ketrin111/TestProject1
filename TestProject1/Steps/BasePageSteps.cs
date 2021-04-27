using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using System;
using TechTalk.SpecFlow;
using TestProject1.PageObjects.Page;

namespace TestProject1.Steps
{
    [Binding]
    public class BasePageSteps
    {

        protected IWebDriver driver;

        public BasePageSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}