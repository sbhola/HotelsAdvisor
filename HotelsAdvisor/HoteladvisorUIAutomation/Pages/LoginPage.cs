using System;
using System.Threading;
using AppacitiveAutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using HoteladvisorUIAutomation.Application;
using HoteladvisorUIAutomation.Configuration;
using HoteladvisorUIAutomation.Utility;

namespace HoteladvisorUIAutomation.Pages
{
    public class LoginPage : UIPage
    {
        internal bool IsVisible()
        {
            Thread.Sleep(5000);
            var div = WaitAndGetBySelector("divHome", ApplicationSettings.TimeOut.Slow);
            return div != null && div.Displayed;
        }

        internal Boolean IsSuccessfullyLoggedIn()
        {
            var userName = WaitAndGetBySelector("lnkUserName", ApplicationSettings.TimeOut.Fast);
            return userName != null && userName.Displayed && userName.Text.StartsWith("HELLO");
        }

        internal void LogOutUser()
        {
            var aLogOff = WaitAndGetBySelector("aLogOff", ApplicationSettings.TimeOut.Fast);
            aLogOff.Click();
        }

        internal void EnterUserName(string userName)
        {
            var divUserName = WaitAndGetBySelector("userName", ApplicationSettings.TimeOut.Fast);
            divUserName.SendKeys(userName);
        }

        internal void EnterPassword(string password)
        {
            var divPassword = WaitAndGetBySelector("password", ApplicationSettings.TimeOut.Fast);
            divPassword.SendKeys(password);
        }

        internal void ClickSubmitButton()
        {
            var btn = WaitAndGetBySelector("submitButton", ApplicationSettings.TimeOut.Fast);
            btn.Click();
        }

        internal void ClickRegisterLink()
        {
            var lnkRegister = WaitAndGetBySelector("lnkRegister", ApplicationSettings.TimeOut.Fast);
            lnkRegister.Click();
        }

        internal bool IsRegisterPageOpen()
        {
            var divCreateAccount = WaitAndGetBySelector("divCreateAccount", ApplicationSettings.TimeOut.Fast);
            return divCreateAccount != null && divCreateAccount.Displayed && divCreateAccount.Text.StartsWith("Create a new");
        }

        internal void ClickLoginLink()
        {
            var lnkLogin = WaitAndGetBySelector("lnkLogin", ApplicationSettings.TimeOut.Fast);
            lnkLogin.Click();
        }

        internal void ClickGmailLoginButton()
        {
            var btnGoogle = WaitAndGetBySelector("btnGoogle", ApplicationSettings.TimeOut.SuperFast);
            btnGoogle.Click();
        }

        internal bool IsGoogleAuthenticationPageOpen()
        {
            var googleBaner = WaitAndGetBySelector("googleBaner", ApplicationSettings.TimeOut.Fast);
            return googleBaner != null && googleBaner.Displayed &&
                   googleBaner.Text.Equals("Sign in with your Google Account");
        }

        internal void ClickFacebookLoginButton()
        {
            var btnFacebook = WaitAndGetBySelector("btnFacebook", ApplicationSettings.TimeOut.Fast);
            btnFacebook.Click();
        }

        internal bool IsFaceBookAuthenticationPageOpen()
        {
            var fbContainer = WaitAndGetBySelector("facebookContainer",ApplicationSettings.TimeOut.Fast);
            return fbContainer != null && fbContainer.Displayed;
        }

        internal void ClickDiscountHotelButton()
        {
            var btnHome = WaitAndGetBySelector("lnkHome", ApplicationSettings.TimeOut.Fast);
            btnHome.Click();
        }

        internal bool IsHomePageDisplayed()
        {
            var banerHome = WaitAndGetBySelector("banerHome", ApplicationSettings.TimeOut.Fast);
            return banerHome != null && banerHome.Displayed && banerHome.Text.StartsWith("Browse Hotels");
        }

        internal void RefreshLoginPage()
        {
            var divHome = WaitAndGetBySelector("userName", ApplicationSettings.TimeOut.Fast);
            divHome.SendKeys(Keys.F5);
        }

        internal Boolean IsUserLoggedIn()
        {
            var lnkUserName = WaitAndGetBySelector("lnkUserName", ApplicationSettings.TimeOut.Fast);
            return lnkUserName!=null && lnkUserName.Text.ToLower().StartsWith("hello");
        }


        internal void NavigateToLoginPage()
        {
            ExecuteJavascript("window.location.href='" + ApplicationSettings.LoginUrl + "'");
        }

        internal bool IsSuccessfullyLoggedInCheckForAddReviewPage()
        {
            var displayUserName = GetUIElementBySelector("displayUserName");
            var logoutForm = GetUIElementBySelector("logoutForm");

            return displayUserName != null && logoutForm != null && displayUserName.Displayed && logoutForm.Displayed;
        }
    }
}
