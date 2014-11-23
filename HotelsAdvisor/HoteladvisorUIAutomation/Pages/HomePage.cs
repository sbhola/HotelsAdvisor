using HoteladvisorUIAutomation.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tavisca.Testing.Platform;
using AppacitiveAutomationFramework;
using System.Threading;
namespace HoteladvisorUIAutomation.Pages
{
    public class HomePage : AppacitiveAutomationFramework.UIPage
    {
        internal bool IsVisible()
        {
            var div = WaitAndGetBySelector("divHome", ApplicationSettings.TimeOut.Slow);
            return div != null && div.Displayed;
        }
        internal void EnterTextInAutoCompleteSearchBox(string input)
        {
            var autocompleteSearchBox = WaitAndGetBySelector("AutocompeteSearchBox", ApplicationSettings.TimeOut.Slow);
            autocompleteSearchBox.Clear();
            autocompleteSearchBox.SendKeys(input);
        }

        //Add method IsSearchButtonEnabled
        internal void ClickSearchButton()
        {
            var autocompleteSearchButton = WaitAndGetBySelector("SearchButton", ApplicationSettings.TimeOut.Fast);
            autocompleteSearchButton.Click();
        }

        internal bool IsSearchButtonEnabled()
        {
            var autocompleteSearchButton = WaitAndGetBySelector("SearchButton", ApplicationSettings.TimeOut.Fast);
            return autocompleteSearchButton.Enabled;
        }

        internal void SelectOptionInDropDownMenu(int index)
        {
            Thread.Sleep(1000);
            var list = GetUIElements("FirstItem");
            list[index].Click();
        }

        internal bool IsValidationMessageDisplayed()
        {
            var optionOnEnteringSpaces = WaitAndGetBySelector("OptionOnEnteringSpaces", ApplicationSettings.TimeOut.Fast);
            return optionOnEnteringSpaces != null && optionOnEnteringSpaces.Displayed;
        }

        internal void ClickThumbnail(int index)
        {
            var list = GetUIElements("FirstThumbNail");
            list[index].Click();
        }

        internal void ClickLoginButton()
        {
            var loginLink = WaitAndGetBySelector("loginLink", ApplicationSettings.TimeOut.Fast);
            loginLink.Click();
        }

        internal bool IsLogOffButtonVisible()
        {
            var logoff = WaitAndGetBySelector("LogOff", ApplicationSettings.TimeOut.Fast);
            return logoff != null && logoff.Displayed;
        }
        internal void ClickLogOff()
        {
            var logoff = WaitAndGetBySelector("LogOff", ApplicationSettings.TimeOut.Fast);
            logoff.Click();
        }
        internal bool IsRegisterButtonVisible()
        {
            var register = WaitAndGetBySelector("registerLink", ApplicationSettings.TimeOut.Fast);
            return register != null && register.Displayed;
        }
        internal void ClickRegisterButton()
        {
            var register = WaitAndGetBySelector("registerLink", ApplicationSettings.TimeOut.Fast);
            register.Click();
        }
        internal bool IsLoginButtonVisible()
        {
            var loginLink = WaitAndGetBySelector("loginLink", ApplicationSettings.TimeOut.Fast);
            return loginLink != null && loginLink.Displayed;
        }
        internal bool IsUserNameVisibleAfterLoggedIn()
        {
            var username = WaitAndGetBySelector("username", ApplicationSettings.TimeOut.Fast);
            return username != null && username.Displayed;
        }

        internal string GetValueOfAutocompleteSearchBox()
        {
            var autocompleteSearchButton = WaitAndGetBySelector("SearchButton", ApplicationSettings.TimeOut.Fast);
            return autocompleteSearchButton.Text;

        }


        //Saif Methods

        //internal bool IsVisible()
        //{
        //    var div = GetUIElementBySelector("divHome");
        //    return div != null && div.Displayed;
        //}

        internal void SearchByLocation(string text)
        {
            var input = WaitAndGetBySelector("inputSearch", ApplicationSettings.TimeOut.Slow);

            if (input == null || !input.Displayed)
            {
                Assert.Fail("Input Search Box not displayed.");
            }

            input.SendKeys(text);
            Thread.Sleep(1000);
            var anchorTag = WaitAndGetBySelector("anchorTag", ApplicationSettings.TimeOut.Slow);
            anchorTag.Click();

            Thread.Sleep(500);

            var searchButton = WaitAndGetBySelector("SearchButton", ApplicationSettings.TimeOut.Slow);

            if (searchButton == null || !searchButton.Displayed)
            {
                Assert.Fail("Search Button not displayed.");
            }

            Thread.Sleep(500);
            searchButton.Click();
        }

        internal void SearchByHotelName(string text)
        {
            var input = WaitAndGetBySelector("inputSearch", ApplicationSettings.TimeOut.Slow);

            if (input == null || !input.Displayed)
            {
                Assert.Fail("Input Search Box not displayed.");
            }

            input.SendKeys(text);
            Thread.Sleep(1000);
            var anchorTag = WaitAndGetBySelector("anchorTag", ApplicationSettings.TimeOut.Slow);
            anchorTag.Click();

            Thread.Sleep(500);

            var searchButton = WaitAndGetBySelector("SearchButton", ApplicationSettings.TimeOut.Slow);

            if (searchButton == null || !searchButton.Displayed)
            {
                Assert.Fail("Search Button not displayed.");
            }

            Thread.Sleep(500);
            searchButton.Click();
        }

        internal bool IsRegisterAndloginLinkShownIfUserNotLoggedIn()
        {
            var registerLink = WaitAndGetBySelector("registerLink", ApplicationSettings.TimeOut.Slow);
            var loginLink = WaitAndGetBySelector("loginLink", ApplicationSettings.TimeOut.Slow);

            return registerLink != null && loginLink != null && registerLink.Displayed && loginLink.Displayed;
        }

        internal void Loggoff()
        {
            var logoutForm = GetUIElementBySelector("logoutForm");
            logoutForm.Click();
        }

        internal bool Login(string userName, string password)
        {
            var loginLink = WaitAndGetBySelector("loginLink", ApplicationSettings.TimeOut.Slow);
            if (loginLink == null || !loginLink.Displayed)
            {
                Assert.Fail("Login Link Not Displayed");
            }
            loginLink.Click();
            Thread.Sleep(500);

            var inputUserName = WaitAndGetBySelector("inputUserName", ApplicationSettings.TimeOut.Slow);

            if (inputUserName == null || !inputUserName.Displayed)
            {
                Assert.Fail("UserName Text Box Not Displayed");
            }

            inputUserName.SendKeys(userName);
            Thread.Sleep(500);
            var inputPassword = WaitAndGetBySelector("inputPassword", ApplicationSettings.TimeOut.Slow);

            if (inputPassword == null || !inputPassword.Displayed)
            {
                Assert.Fail("Password Text Box Not Displayed");
            }
            inputPassword.SendKeys(password);
            Thread.Sleep(500);

            var loginButton = WaitAndGetBySelector("loginButton", ApplicationSettings.TimeOut.Slow);

            if (loginButton == null || !loginButton.Displayed)
            {
                Assert.Fail("Login Button Not Displayed");
            }

            loginButton.Click();
            Thread.Sleep(1000);

            return IsVisible();
        }
    }
}