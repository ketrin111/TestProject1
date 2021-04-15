using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TestProject1.PageObjects.Page;

namespace TestProject1.Steps
{
    [Binding]
    public class SearchPageSteps : BasePageSteps
    {
        private SearchPage searchPagePage;

        public SearchPageSteps(IWebDriver driver) : base(driver)
        {
            searchPagePage = new SearchPage(driver);
        }

        [Then(@"'(.*)' header should be displayed on the Search Page")]
        public void ThenHeaderShouldBeDisplayedOnTheSearchPage(string textResult)
        {
            Assert.IsTrue(searchPagePage.SearchResults().Text.Contains(textResult, StringComparison.OrdinalIgnoreCase));
        }
    }
}