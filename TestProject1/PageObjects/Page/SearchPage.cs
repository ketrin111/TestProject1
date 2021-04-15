using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestProject1.PageObjects.Page
{
    public class SearchPage 
    {
        private IWebDriver driver;

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SearchResults()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h2[@class='search-results__counter']")));
        }
    }
}