using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPractice.PageObjects
{
    public class CartOverlayPage
    {
        readonly IWebDriver driver;
        public By ProceedToCheckout = By.CssSelector(".btn-default[title='Proceed to checkout']");

        public CartOverlayPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("layer_cart")));
        }
    }
}
