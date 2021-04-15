using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TestProject1.PageObjects.Page;

namespace TestProject1.Steps
{
    [Binding]
    public class HomePageSteps : BasePageSteps
    {
        private HomePage homePage;

        public HomePageSteps(IWebDriver driver) : base(driver)
        {
            homePage = new HomePage(driver);
        }

        [Given(@"I am on the Home Page")]
        public void GivenIAmOnTheHomePage()
        {
            driver.Navigate().GoToUrl("https://www.epam.com/");
            driver.Manage().Window.Maximize();
        }

        [When(@"I see '(.*)' in the navigation table")]
        public void WhenISeeInTheNavigationTable(string header)
        {
            Assert.IsTrue(homePage.NavigationItem(header).Displayed);
        }

        [When(@"I click on Find button on the search popup")]
        public void WhenIClickOnFindButtonOnTheSearchPopup()
        {
            homePage.SubmitButton().Click();
        }

        [When(@"I click search button")]
        public void WhenIClickSearchButton()
        {
            homePage.SearchButton().Click();
        }

        [When(@"I enter '(.*)' in the search field")]
        public void WhenIEnterInTheSearchField(string text)
        {
            homePage.SearchForm().SendKeys(text);
        }

        [When(@"I click on '(.*)' in the navigation table")]
        public void WhenIClickOnInTheNavigationTable(string navigationButton)
        {
            homePage.NavigationItem(navigationButton).Click();
        }

        [When(@"I click on localtion button")]
        public void WhenIClickOnLocaltionButton()
        {
            homePage.LanguageButtons().Click();
        }

        [When(@"I switch to RU language")]
        public void WhenISwitchToRULanguage()
        {
            homePage.RuLanguageButton().Click();
        }

        [Then(@"a '(.*)' is displayed on Home Page")]
        public void ThenAIsDisplayedOnHomePage(string header)
        {
            Assert.IsTrue(homePage.NavigationItem(header).Text.Equals(header, StringComparison.OrdinalIgnoreCase));
        }

        [Then(@"the following menu items should be displayed:")]
        public void ThenTheFollowingMenuItemsShouldBeDisplayed(string expextedMenuItems)
        {
            homePage.ListOfElement();
            string actualMenuItems = GetItemsFromTheNavigationMenu();
            Assert.AreEqual(expextedMenuItems, actualMenuItems, "Menu items are different.");
        }

        private string GetItemsFromTheNavigationMenu()
        {
            homePage.ListOfElement();
            List<string> navigationItems = (from a in homePage.ListOfElements()
                                             where a.Text.Contains("")
                                             select a.Text).ToList();

            return string.Join(", ", navigationItems);
        }
    }
}