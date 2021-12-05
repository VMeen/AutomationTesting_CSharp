using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPractice.PageObjects
{
    public class MyAccountPage 
    {
        readonly IWebDriver driver;
        public By logOut = By.ClassName("logout");
        public By wishlist = By.ClassName("lnk_wishlist");        

        //  public By accFullName = By.ClassName("account");
        public MyAccountPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("my-account")));
        }
    }
}
