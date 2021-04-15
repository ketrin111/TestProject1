using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace TestProject1.PageObjects.Page
{
    public class HomePage
    {
        public IWebDriver driver { get; }

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement NavigationItem(string text) => 
            driver.FindElement(By.XPath("//a[@class='top-navigation__item-link'][contains(text(),'"+text+"')]"));

        public IWebElement SearchForm() => driver.FindElement(By.Id("new_form_search"));

        public IList<IWebElement> ListOfElements() 
        {
            return driver.FindElements(By.XPath("//span[@class='top-navigation__item-text']//a"));
        }

        public IWebElement ListOfElement()
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='top-navigation__item-text']")));
        }

        public IWebElement LanguageButtons() => driver.FindElement(By.XPath("//button[@class='location-selector__button']"));

        //public IWebElement RuLanguageButton() => driver.FindElement(By.XPath("//ul[@class='header__controls']//a[contains(text(),'Россия')]"));

        public IWebElement SearchButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return wait.Until(ExpectedConditions.
                ElementToBeClickable(By.XPath("//button[@class='header-search__button header__icon']")));
        }

        public IWebElement RuLanguageButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return wait.Until(ExpectedConditions.
                ElementToBeClickable(By.XPath("//ul[@class='header__controls']//a[contains(text(),'Россия')]")));
        }

        public IWebElement SubmitButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return wait.Until(ExpectedConditions.
                ElementToBeClickable(By.XPath("//button[@class='header-search__submit']")));
        }
    }
}