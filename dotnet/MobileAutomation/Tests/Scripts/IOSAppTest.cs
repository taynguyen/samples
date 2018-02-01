using System;
using MobileAutomation.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;
using Xunit;

namespace MobileAutomation.Tests.Scripts
{
    public class AppTestIOS : BaseTest
    {
        public AppTestIOS()
        {
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability("username", username);
            capabilities.SetCapability("accessKey", apiKey);
            capabilities.SetCapability("sessionName", "iOS App Test");
            capabilities.SetCapability("sessionDescription", "Kobiton sample session");
            capabilities.SetCapability("deviceOrientation", "portrait");
            capabilities.SetCapability("captureScreenshots", true);
            capabilities.SetCapability("app", "https://s3-ap-southeast-1.amazonaws.com/kobiton-devvn/apps-test/UIKitCatalog-Test-Adhoc.ipa");
            capabilities.SetCapability("deviceName", "iPhone X");
            capabilities.SetCapability("platformName", "iOS");

            driver = new IOSDriver<IWebElement>(AutomationUri,
                                                capabilities,
                                                TimeSpan.FromSeconds(Configs.SESSION_TIMEOUT));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        IOSDriver<IWebElement> GetIOSDriver()
        {
            return (IOSDriver<IWebElement>)driver;
        }

        [Fact]
        public void TestGetTextUIKitCatalog()
        {
            var text = driver.FindElementByXPath("//UIAStaticText").Text;
            Assert.Equal("UIKitCatalog", text);
        }
    }
}
