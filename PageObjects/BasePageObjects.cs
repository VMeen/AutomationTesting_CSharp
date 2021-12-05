using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;
using AutomationPractice.Helpers;

namespace AutomationPractice.PageObjects
{
    [Binding]
    public class BasePageObjects
    {

        //The Selenium web driver to automate the browser
        //private readonly IWebDriver Driver;
        public static IWebDriver Driver { get; private set; }
        public static string EmailAddress { get; set; }

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        private static IWebDriver CreateWebDriver(string browser)
        {
            if (browser == "")
            {
                browser = "Chrome";
            }
            string driverPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            switch (browser)
            {
                case "Chrome":
                    {
                        var chromeOptions = new ChromeOptions();
                        var chromeDriver = new ChromeDriver((driverPath + @"\drivers\"), chromeOptions);
                        return chromeDriver;
                    }
                case "Firefox":
                    {
                        IWebDriver firfoxDriver = new FirefoxDriver(driverPath + @"\drivers\");
                        return firfoxDriver;
                    }
                case "IE":
                    {
                        IWebDriver IEDriver = new FirefoxDriver(driverPath + @"\drivers\");
                        return IEDriver;
                    }
                default:
                    {
                        var chromeOptions = new ChromeOptions();
                        var chromeDriver = new ChromeDriver((driverPath + @"\drivers\"), chromeOptions);
                        return chromeDriver;
                    }
            }
        }

        //[BeforeScenario]
        [BeforeFeature]
        public static void BeforeScenario()
        {             
            Driver = CreateWebDriver(TestData.Browser);
            Driver.Manage().Window.Maximize();
            var url = TestData.TestPage;
            Driver.Url = url;
        }

        //[AfterScenario]
        [AfterFeature]
        public static void AfterScenario()
        {
            //Driver.Quit();
        }


    }
}
