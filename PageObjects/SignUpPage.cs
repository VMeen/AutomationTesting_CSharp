using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;


namespace AutomationPractice.PageObjects 
{
    public class SignUpPage
    {
        readonly IWebDriver driver;

        public By FirstName = By.Id("customer_firstname");
        public By LastName = By.Id("customer_lastname");
        public By PassWord = By.Id("passwd");
        public By FirstNameAddress = By.Id("firstname");
        public By LastNameAdress = By.Id("lastname");
        public By Address = By.Id("address1");
        public By City = By.Id("city");
        public By State = By.Id("id_state");
        public By Postalcode = By.Id("postcode");
        public By Country = By.Id("id_country");
        public By MobilePhone = By.Id("phone_mobile");
        public By AliasAddr = By.Id("alias");
        public By RegisterButton = By.Id("submitAccount");

        public SignUpPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("account-creation_form")));
        }
    }
}
