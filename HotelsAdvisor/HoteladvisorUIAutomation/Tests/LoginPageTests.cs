
using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HoteladvisorUIAutomation.Application;
using HoteladvisorUIAutomation.Utility;
using AppacitiveAutomationFramework;

namespace HoteladvisorUIAutomation.Tests
{
    /// <summary>
    /// Summary description for LoginPageTests
    /// </summary>
    [TestClass]
    public class LoginPageTests
    {
        private static HotelsAdvisorApp _hotelsApp;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _hotelsApp = TestHelper.HotelsApp;
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _hotelsApp.Dispose();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            TestHelper.LoginPageInitialize();
            if (_hotelsApp.LoginPage.IsUserLoggedIn())
            {
                _hotelsApp.LoginPage.LogOutUser();
            }
            _hotelsApp.LoginPage.NavigateToLoginPage();
            
            Assert.IsTrue(_hotelsApp.LoginPage.IsVisible(), "Could not load Login Page!");
            Thread.Sleep(500);
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        [TestCategory("Sanity")]
        public void ShouldShowLoginPage()
        {
            Assert.IsTrue(_hotelsApp.LoginPage.IsVisible(), "Login was unavailable");
        }

        [TestMethod]
        public void RegisteredUserShouldSuccessfullyLogin()
        {
            Assert.IsTrue(_hotelsApp.LoginPage.IsVisible(), "Login was unavailable");
            _hotelsApp.LoginPage.EnterUserName("yellow@yel.com");
            _hotelsApp.LoginPage.EnterPassword("111111");
            _hotelsApp.LoginPage.ClickSubmitButton();
            Assert.IsTrue(_hotelsApp.LoginPage.IsSuccessfullyLoggedIn(),"User not logges in");
        }

        [TestMethod]
        public void ShouldRedirectToLoginPageForInvalidEmail()
        {
            Assert.IsTrue(_hotelsApp.LoginPage.IsVisible(),"Login was unavailable");
            _hotelsApp.LoginPage.EnterUserName("yell@yel.com");
            _hotelsApp.LoginPage.EnterPassword("111111");
            Assert.IsTrue(_hotelsApp.LoginPage.IsVisible(),"Login was unavailable");
        }

        [TestMethod]
        public void ShouldRedirectToLoginPageForInvalidPassword()
        {
            Assert.IsTrue(_hotelsApp.LoginPage.IsVisible(), "Login was unavailable");
            _hotelsApp.LoginPage.EnterUserName("yellow@yel.com");
            _hotelsApp.LoginPage.EnterPassword("111112");
            Assert.IsTrue(_hotelsApp.LoginPage.IsVisible(), "Login was unavailable");
        }

        [TestMethod]
        public void ShouldRedirectToLoginPageForInvalidEmailAndInvalidPassword()
        {
            Assert.IsTrue(_hotelsApp.LoginPage.IsVisible(), "Login was unavailable");
            _hotelsApp.LoginPage.EnterUserName("yell@yel.com");
            _hotelsApp.LoginPage.EnterPassword("111112");
            Assert.IsTrue(_hotelsApp.LoginPage.IsVisible(), "Login was unavailable");
        }

        [TestMethod]
        public void ShouldRedirectToRegisterPageWhenUserClicksOnRegisterLink()
        {
            Assert.IsTrue(_hotelsApp.LoginPage.IsVisible(), "Login was unavailable");
            _hotelsApp.LoginPage.ClickRegisterLink();
            Assert.IsTrue(_hotelsApp.LoginPage.IsRegisterPageOpen(),"Register Page was not opened");
        }

        [TestMethod]
        public void ShouldRedirectToLoginPageWhenUserClicksOnLoginLink()
        {
            _hotelsApp.LoginPage.ClickLoginLink();
            Assert.IsTrue(_hotelsApp.LoginPage.IsVisible(), "Login was unavailable");
            _hotelsApp.LoginPage.ClickLoginLink();
            Assert.IsTrue(_hotelsApp.LoginPage.IsVisible(), "Login was unavailable");
        }

        [TestMethod]
        public void ShouldRedirectToAuthenticationPageOfGmailWhenGmailButtonClickedAndUserSessionDoesNotExistsInBrowser()
        {
            Assert.IsTrue(_hotelsApp.LoginPage.IsVisible(), "Login was unavailable");
            _hotelsApp.LoginPage.ClickGmailLoginButton();
            Assert.IsTrue(_hotelsApp.LoginPage.IsGoogleAuthenticationPageOpen());
        }

        [TestMethod]
        public void ShouldRedirectToAuthenticationPageOfFacebookWhenFbButtonClickedAndUserSessionDoesNotExistsInBrowser()
        {
            Assert.IsTrue(_hotelsApp.LoginPage.IsVisible(), "Login was unavailable");
            _hotelsApp.LoginPage.ClickFacebookLoginButton();
            Assert.IsTrue(_hotelsApp.LoginPage.IsFaceBookAuthenticationPageOpen());
        }

        [TestMethod]
        public void ShouldRedirectToHomePageWhenDiscountHotelsButtonClicked()
        {
            Assert.IsTrue(_hotelsApp.LoginPage.IsVisible(), "Login was unavailable");
            _hotelsApp.LoginPage.ClickDiscountHotelButton();
            Assert.IsTrue(_hotelsApp.LoginPage.IsHomePageDisplayed());
        }

        [TestMethod]
        public void ShouldRedirectToLoginPageWhenPageRefreshDone()
        {
            Assert.IsTrue(_hotelsApp.LoginPage.IsVisible(), "Login was unavailable");
            _hotelsApp.LoginPage.RefreshLoginPage();
            Assert.IsTrue(_hotelsApp.LoginPage.IsVisible(), "Login was unavailable");
        }

    }
}
