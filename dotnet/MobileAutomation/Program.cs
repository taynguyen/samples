using System;
using MobileAutomation.Tests.Scripts;

namespace MobileAutomation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("------------------------Android Web Test------------------------");
            var webTestAndroid = new WebTestAndroid();
            webTestAndroid.TestSearchKobitonOnGoogle();
            webTestAndroid.Dispose();

            Console.WriteLine();
            Console.WriteLine("------------------------Android App Test------------------------");
            var appTestAndroid = new AppTestAndroid();
            appTestAndroid.TestShouldShowAppLabel();
            appTestAndroid.Dispose();

            Console.WriteLine();
            Console.WriteLine("------------------------iOS Web Test------------------------");
            var webTestIOS = new WebTestIOS();
            webTestIOS.TestSearchKobitonOnGoogle();
            webTestIOS.Dispose();

            Console.WriteLine();
            Console.WriteLine("------------------------iOS App Test------------------------");
            var appTestIOS = new AppTestIOS();
            appTestIOS.TestGetTextUIKitCatalog();
            appTestIOS.Dispose();
        }
    }
}
