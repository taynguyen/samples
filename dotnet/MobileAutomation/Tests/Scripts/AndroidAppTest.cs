using System;
using System.Threading;
using MobileAutomation.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using Xunit;

namespace MobileAutomation.Tests.Scripts
{
    public class AppTestAndroid : BaseTest
    {
        public AppTestAndroid()
        {
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability("username", username);
            capabilities.SetCapability("accessKey", apiKey);
            capabilities.SetCapability("sessionName", "Android App Test");
            capabilities.SetCapability("sessionDescription", "Kobiton sample session");
            capabilities.SetCapability("deviceOrientation", "portrait");
            capabilities.SetCapability("captureScreenshots", true);
            capabilities.SetCapability("app", "https://appium.github.io/appium/assets/ApiDemos-debug.apk");
            capabilities.SetCapability("deviceName", "Galaxy J7");
            capabilities.SetCapability("platformName", "Android");
            driver = new AndroidDriver<IWebElement>(AutomationUri,
                                                    capabilities,
                                                    TimeSpan.FromSeconds(Configs.SESSION_TIMEOUT));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        private AndroidDriver<IWebElement> GetAndroidDriver()
        {
            return (AndroidDriver<IWebElement>)driver;
        }

        [Fact]
        public void TestShouldShowAppLabel()
        {
            Thread.Sleep(2000);
            var text = driver.FindElementByClassName("android.widget.TextView").Text;

            Assert.Equal(text, "API Demos");
        }
    }
}
