using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPractice.PageObjects
{
    public class HomePage
    {

    readonly IWebDriver driver;

        public By singIn = By.ClassName("login");
        public By dresses = By.CssSelector(".sf-menu [title = 'Dresses']");

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("index")));
        }
    }
}
