using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.IO;
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
            chromeOptions.AddUserProfilePreference("download.default_directory",
               Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ""));
            chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads",
                1);
            chromeOptions.AddAdditionalCapability("enableVNC", true, true);
            chromeOptions.AddAdditionalCapability("version", "90.0", true);
            chromeOptions.AddAdditionalCapability("platform", new Platform(PlatformType.Any), true);  
          
            webDriver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub/"), chromeOptions);  
            webDriver.Manage().Window.Maximize();
            var eventFiringWebDriver = new EventFiringWebDriver(webDriver);
          
            return eventFiringWebDriver;
        }
    }
}
