using System;
using OpenQA.Selenium.Remote;
using Xunit;

namespace MobileAutomation.Tests
{
    public abstract class BaseTest : IDisposable
    {
        protected string username;
        protected string apiKey;
        private string automationUrl;
        private string hostName = "api.kobiton.com";

        protected RemoteWebDriver driver;

        public BaseTest() 
        {
            this.username = Environment.GetEnvironmentVariable("KOBITON_USERNAME");
            this.apiKey = Environment.GetEnvironmentVariable("KOBITON_API_KEY");

            var envHostname = Environment.GetEnvironmentVariable("KOBITON_AUTOMATION_HOSTNAME");
            if (!string.IsNullOrEmpty(envHostname))
            {
                this.hostName = envHostname;
            }

            if (!string.IsNullOrEmpty(this.username) && !string.IsNullOrEmpty(this.apiKey)) {
                this.automationUrl = string.Format("https://{0}/wd/hub", hostName);
            }

            Assert.False(string.IsNullOrEmpty(username));
            Assert.False(string.IsNullOrEmpty(apiKey));
        }

        public void Dispose()
        {
            Console.WriteLine("Driver quit. :D");
            if (driver != null)
            {
                driver.Quit();
            }
        }

        protected Uri AutomationUri {
            get {
                return new Uri(automationUrl);
            }
        }
    }
}
