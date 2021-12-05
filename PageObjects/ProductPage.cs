using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPractice.PageObjects
{
    public class ProductPage
    {
        readonly IWebDriver driver;

        public By pdDialog = By.ClassName("primary_block");
        public By addToCart = By.Id("add_to_cart");
        public By productName = By.XPath("//h1[@itemprop='name']");
        public By quantity = By.Id("quantity_wanted");

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(pdDialog));
        }
    }
}
