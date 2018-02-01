using System;
using System.Threading;
using MobileAutomation.Config;
using OpenQA.Selenium.Remote;
using Xunit;

namespace MobileAutomation.Tests.Scripts
{
    public class WebTestAndroid : BaseTest
    {
        public WebTestAndroid()
        {
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability("username", username);
            capabilities.SetCapability("accessKey", apiKey);
            capabilities.SetCapability("sessionName", "Android Web Test");
            capabilities.SetCapability("sessionDescription", "Kobiton sample session");
            capabilities.SetCapability("deviceOrientation", "portrait");
            capabilities.SetCapability("captureScreenshots", true);
            capabilities.SetCapability("browserName", "chrome");
            capabilities.SetCapability("deviceName", "Galaxy S6");
            capabilities.SetCapability("platformName", "Android");

            driver = new RemoteWebDriver(AutomationUri,
                                         capabilities,
                                         TimeSpan.FromSeconds(Configs.SESSION_TIMEOUT));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        [Fact]
        public void TestSearchKobitonOnGoogle()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            Thread.Sleep(5000);
            driver.FindElementByName("q")
                  .SendKeys("Kobiton");
            Thread.Sleep(3000);
            driver.FindElementByName("btnG")
                  .Click();

            var title = driver.Title;
            Assert.Equal("Kobiton - Google Search", title);
        }
    }
}
