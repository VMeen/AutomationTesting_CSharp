using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using AutomationPractice.PageObjects;
using AutomationPractice.Steps;
using AutomationPractice.Helpers;
using System.Threading;
using NUnit.Framework;


namespace AutomationPractice.Steps
{
    [Binding]
    public class TestSteps : BasePageObjects
    {
        private IWebDriver driver;
        public string fullname = "";

        [Given(@"user opens sign in page")]
        public void GivenUserOpensSignInPage()
        {
             Utilities ut = new Utilities(Driver);
             HomePage hp = new HomePage(Driver);
             ut.ClickOnElement(hp.singIn);
        }

        [Given(@"initiates a flow for creating an account")]
        public void GivenInitiatesAFlowForCreatingAnAccount()
        {
            Utilities ut = new Utilities(Driver);
            AuthenticationPage ap = new AuthenticationPage(Driver);
            string userName = ut.GenerateRandomMail();
            FeatureContext.Current.Add(TestData.UserEmail, userName);
            ut.EnterTxtInElement(ap.emailfield, userName);
            ut.ClickOnElement(ap.createAcc);
        }

        [Given(@"user enters all required personal details")]
        public void GivenUserEntersAllRequiredPersonalDetails()
        {
             Utilities ut = new Utilities(Driver);
            SignUpPage sup = new SignUpPage(Driver);

            ut.EnterTxtInElement(sup.FirstName, TestData.FirstName);
            ut.EnterTxtInElement(sup.LastName, TestData.LastName);
            fullname = TestData.FirstName + " " + TestData.LastName;
            ut.EnterTxtInElement(sup.PassWord, TestData.password);
            ut.EnterTxtInElementAfterClearing(sup.FirstNameAddress, TestData.FirstName);
            ut.EnterTxtInElementAfterClearing(sup.LastNameAdress, TestData.LastName);
            ut.EnterTxtInElement(sup.Address, TestData.Address);
            ut.EnterTxtInElement(sup.City, TestData.City);
            ut.DropdownSelect(sup.State, TestData.State);
            ut.EnterTxtInElement(sup.Postalcode, TestData.ZipCode);
            ut.EnterTxtInElement(sup.MobilePhone, TestData.MobilePhone);
            ut.EnterTxtInElementAfterClearing(sup.AliasAddr, TestData.AddressAlias);
        }

        [When(@"sbumits the sign up form")]
        public void WhenSbumitsTheSignUpForm()
        {
             Utilities ut = new Utilities(Driver);
             SignUpPage sup = new SignUpPage(Driver);
             ut.ClickOnElement(sup.RegisterButton); 
        }

        [Then(@"user will be logged in")]
        [Given(@"user lands on the logged on page")]
        [Given(@"user logged in")]
        public void ThenUserWillBeLoggedIn()
        {
            Utilities ut = new Utilities(Driver);
            MyAccountPage ma = new MyAccountPage(Driver);
            Assert.True(ut.ElementDisplayed(ma.logOut), "User is not logged in");
        }

        [When(@"user logout")]
        public void WhenUserLogout()
        {
            Utilities ut = new Utilities(Driver);
            MyAccountPage ma = new MyAccountPage(Driver);
            ut.ClickOnElement(ma.logOut);
        }

        [Then(@"sign in page is opened")]
        [Given(@"user opens authentication page")]
        public void ThenSignInPageIsOpened()
        {
            Utilities ut = new Utilities(Driver);
            AuthenticationPage ap = new AuthenticationPage(Driver);
            Assert.True(ut.ElementDisplayed(ap.signInBtn), "User is logged in");
        }

        [Then(@"User's full name will be displayed")]
        public void ThenUserSFullNameWillBeDisplayed()
        {
            Utilities ut = new Utilities(Driver);
            Assert.True(ut.TextPresentInElement(fullname).Displayed, "User's full name is not displayed");
        }

        [Given(@"enters correct credentials")]
        public void GivenEntersCorrectCredentials()
        {
            Utilities ut = new Utilities(Driver);
            AuthenticationPage ap = new AuthenticationPage(Driver);
            string userID = FeatureContext.Current.Get<string>(TestData.UserEmail);
            ut.EnterTxtInElement(ap.username, userID);
            ut.EnterTxtInElement(ap.password, TestData.password);
        }

        [When(@"user submits the login form")]
        public void WhenUserSubmitsTheLoginForm()
        {
            Utilities ut = new Utilities(Driver);
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.ClickOnElement(ap.signInBtn);
        }

        [Given(@"user adds product to cart from dress section")]
        public void GivenUserAddsProductToCartFromDressSection()
        {
            Utilities ut = new Utilities(Driver);
            //MyAccountPage ma = new MyAccountPage(Driver);
            //ut.ClickOnElement(ma.dresses);
            //IList<IWebElement> dresses = Driver.FindElements(ma.dresses);
            //dresses[1].Click();
            HomePage hp = new HomePage(Driver);
            //ut.ClickOnElement(hp.dresses);
            IList<IWebElement> dresses = Driver.FindElements(hp.dresses);
            dresses[1].Click();
            ProductsPage pds = new ProductsPage(Driver);
            ut.ClickOnElement(pds.firstdress);
            Driver.SwitchTo().Frame(Driver.FindElement(By.ClassName("fancybox-iframe")));
            ProductPage pd = new ProductPage(Driver);            
            string productName = ut.ReturnTextFromElement(pd.productName);
            ScenarioContext.Current.Add(TestData.ProductName, productName);
            ut.ClickOnElement(pd.addToCart);
        }

        [When(@"user proceeds to checkout and continue till payments")]
        public void WhenUserProceedsToCheckoutAndContinueTillPayments()
        {
            Utilities ut = new Utilities(Driver);
            //ProductsPage pds = new ProductsPage(Driver);
            CartOverlayPage cop = new CartOverlayPage(Driver);
            ut.ClickOnElement(cop.ProceedToCheckout);
        }

        [Then(@"on the payments page verify the product details are correct")]
        public void ThenOnThePaymentsPageVerifyTheProductDetailsAreCorrect()
        {
            Utilities ut = new Utilities(Driver);
            SummaryPage sp = new SummaryPage(Driver);
            string productName = ScenarioContext.Current.Get<string>(TestData.ProductName);
            Assert.AreEqual(ut.ReturnTextFromElement(sp.prdName), productName, "Expected product is not in the cart");            
        }



    }
}
