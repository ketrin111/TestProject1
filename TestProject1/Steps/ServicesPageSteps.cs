using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestProject1.PageObjects.Page;

namespace TestProject1.Steps
{
     [Binding]
    public class ServicesPageSteps : BasePageSteps
    {
 
        private ServicesPage servicesPage;

        public ServicesPageSteps(IWebDriver driver) : base(driver)
        {
            servicesPage = new ServicesPage(driver);
        }

        [Then(@"'(.*)' should be displayed on Services Page")]
        public void ThenShouldBeDisplayedOnServicesPage(string textHeadLine)
        {
            servicesPage.HeadLineServicesPage().Text.Equals(textHeadLine);
        }
    }
}