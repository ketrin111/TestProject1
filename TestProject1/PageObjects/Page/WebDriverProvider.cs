using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace TestProject1.PageObjects.Page
{
    [Binding]
    public class WebDriverSupport
    {
        private readonly IObjectContainer objectContainer;
        private IWebDriver driver;

        public WebDriverSupport(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            driver = GetDriver();
            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void ThenICloseWebDriver()
        {
            driver.Close();
            driver.Quit();
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
