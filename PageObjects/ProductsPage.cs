using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPractice.PageObjects
{
    public class ProductsPage
    {
        readonly IWebDriver driver;
        public By firstdress = By.CssSelector(".product_img_link .replace-2x");
        public By ProceedToCheckout = By.CssSelector(".btn-default[title='Proceed to checkout']");

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("category")));
        }
    }
}
