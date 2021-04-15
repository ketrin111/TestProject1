using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestProject1.PageObjects.Page
{
    public class ServicesPage
    {
        public IWebDriver driver { get; }

        public ServicesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement HeadLineServicesPage() => driver.FindElement(By.XPath("//span[@class='source-sans-light']"));
    }
}