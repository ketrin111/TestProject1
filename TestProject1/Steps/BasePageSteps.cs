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
            this.driver = GetDriver();
        }

        private static IWebDriver GetDriver()
        {

            //var capabilities = new DesiredCapabilities();
            //capabilities.SetCapability(CapabilityType.BrowserName, "UNKNOWN");
            //capabilities.SetCapability(CapabilityType.BrowserVersion, "");
            //var driver = new RemoteWebDriver(new Uri("http://selenoid-uri:4444/wd/hub"), capabilities);

            IWebDriver webDriver = null;
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--start-maximized");
            chromeOptions.AddArguments("--test-type");
            chromeOptions.AddArguments("--no-sandbox");
            chromeOptions.AddAdditionalCapability("enableVNC", true, true);
            chromeOptions.AddAdditionalCapability("version", "89.0", true);
            chromeOptions.AddAdditionalCapability("platform", new Platform(PlatformType.Any), true);
            webDriver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub/"), chromeOptions);
            //var eventFiringWebDriver = new EventFiringWebDriver(webDriver);
            return webDriver;
        }

    }
}