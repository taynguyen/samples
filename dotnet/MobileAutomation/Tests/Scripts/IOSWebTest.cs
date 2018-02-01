using System;
using System.Threading;
using MobileAutomation.Config;
using OpenQA.Selenium.Remote;
using Xunit;

namespace MobileAutomation.Tests.Scripts
{
    public class WebTestIOS : BaseTest
    {
        public WebTestIOS()
        {
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability("username", username);
            capabilities.SetCapability("accessKey", apiKey);
            capabilities.SetCapability("sessionName", "iOS Web Test");
            capabilities.SetCapability("sessionDescription", "Kobiton sample sesion");
            capabilities.SetCapability("deviceOrientation", "portrait");
            capabilities.SetCapability("captureScreenshots", true);
            capabilities.SetCapability("browserName", "safari");
            capabilities.SetCapability("deviceName", "iPhone X");
            capabilities.SetCapability("platformName", "iOS");

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
