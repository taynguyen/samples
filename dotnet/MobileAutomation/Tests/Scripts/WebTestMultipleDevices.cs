using System;
using System.Collections.Generic;
using System.Threading;
using MobileAutomation.Config;
using OpenQA.Selenium.Remote;
using Xunit;

namespace MobileAutomation.Tests.Scripts
{
    public class WebTestAndroidMultipleDeviceDataSource : BaseTest
    {
        public static IEnumerable<DesiredCapabilities[]> GetCapabilities()
        {
            var firstCaps = new DesiredCapabilities();
            firstCaps.SetCapability("sessionName", "Android Web Test - Multiple device [1]");
            firstCaps.SetCapability("sessionDescription", "Kobiton sample session");
            firstCaps.SetCapability("deviceOrientation", "portrait");
            firstCaps.SetCapability("captureScreenshots", true);
            firstCaps.SetCapability("browserName", "chrome");
            firstCaps.SetCapability("deviceName", "Galaxy S5");
            firstCaps.SetCapability("platformName", "Android");
            yield return new DesiredCapabilities[] { firstCaps };


            var secondCaps = new DesiredCapabilities();
            secondCaps.SetCapability("sessionName", "Android Web Test - Multiple device [2]");
            secondCaps.SetCapability("sessionDescription", "Kobiton sample session");
            secondCaps.SetCapability("deviceOrientation", "portrait");
            secondCaps.SetCapability("captureScreenshots", true);
            secondCaps.SetCapability("browserName", "safari");
            secondCaps.SetCapability("deviceName", "iPhone X");
            secondCaps.SetCapability("platformName", "iOS");
            yield return new DesiredCapabilities[] { secondCaps };
        }
    }

    public class WebTestMultipleDevices : BaseTest
    {
        [Theory]
        [MemberData(nameof(WebTestAndroidMultipleDeviceDataSource.GetCapabilities), MemberType = typeof(WebTestAndroidMultipleDeviceDataSource))]
        public void TestSearchKobitonOnGoogle(DesiredCapabilities caps)
        {
            caps.SetCapability("username", username);
            caps.SetCapability("accessKey", apiKey);
            driver = new RemoteWebDriver(AutomationUri,
                                         caps,
                                         TimeSpan.FromSeconds(Configs.SESSION_TIMEOUT));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            try
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
            finally
            {
                if (driver != null) {
                    driver.Quit();
                }
            }

        }
    }
}
