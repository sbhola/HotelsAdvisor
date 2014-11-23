using AppacitiveAutomationFramework;
using HoteladvisorUIAutomation.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteladvisorUIAutomation.Pages
{
    public class RegisterPage : UIPage
    {
        internal bool IsVisible()
        {
            var div = WaitAndGetBySelector("divRegister", ApplicationSettings.TimeOut.Fast);
            return div != null && div.Displayed;
        }
        internal void EnterEmailId(string emailId)
        {
            var div = WaitAndGetBySelector("emailId", ApplicationSettings.TimeOut.Fast);
            div.SendKeys(emailId);
        }
        internal void EnterPassword(string password)
        {
            var passworddiv = WaitAndGetBySelector("password", ApplicationSettings.TimeOut.Fast);
            passworddiv.SendKeys(password);
        }
        internal void EnterConfirmPassword(string confirmPassword)
        {
            var confirmPassworddiv = WaitAndGetBySelector("confirmPassword", ApplicationSettings.TimeOut.Fast);
            confirmPassworddiv.SendKeys(confirmPassword);
        }
        internal void EnterDisplayName(String displayName)
        {
            var displayNamediv = WaitAndGetBySelector("displayName", ApplicationSettings.TimeOut.Fast);
            displayNamediv.SendKeys(displayName);
        }
        internal void ClickRegister()
        {
            var registerbuttonOnRegisterPage = WaitAndGetBySelector("registerbuttonOnRegisterPage", ApplicationSettings.TimeOut.Fast);
            registerbuttonOnRegisterPage.Click();
        }
        internal bool IsValidationMessageDisplayedForInvalidEmailId()
        {
            var msgForInvalidInput = WaitAndGetBySelector("msgForInavalidInput", ApplicationSettings.TimeOut.Fast);
            return msgForInvalidInput != null && msgForInvalidInput.Displayed && msgForInvalidInput.Text == "Invalid Email Address";
        }
        internal bool IsValidationMessageDisplayedForDifferentConfirmPassword()
        {
            var msgForInvalidInput = WaitAndGetBySelector("msgForInavalidInput", ApplicationSettings.TimeOut.Fast);
            return msgForInvalidInput != null && msgForInvalidInput.Displayed && msgForInvalidInput.Text == "'Confirm password' and 'Password' do not match.";
        }
        internal bool IsValidationMessageDisplayedForInvalidPassword()
        {

            var msgForInvalidInput = WaitAndGetBySelector("msgForInavalidInput", ApplicationSettings.TimeOut.Fast);
            return msgForInvalidInput != null && msgForInvalidInput.Displayed && msgForInvalidInput.Text == "The Password must be at least 6 characters long.";
        }
        internal bool IsValidationMessageDisplayedForEmptyDisplayName()
        {

            var msgForInvalidInput = WaitAndGetBySelector("msgForInavalidInput", ApplicationSettings.TimeOut.Fast);
            return msgForInvalidInput != null && msgForInvalidInput.Displayed && msgForInvalidInput.Text == "The DisplayName field is required.";
        }
        internal bool IsValidationMessageDisplayedForEmptyEmaiId()
        {

            var msgForInvalidInput = WaitAndGetBySelector("msgForInavalidInput", ApplicationSettings.TimeOut.Fast);
            return msgForInvalidInput != null && msgForInvalidInput.Displayed && msgForInvalidInput.Text == "The Email field is required.";
        }
        internal bool IsValidationMessageDisplayedForEmptyPassword()
        {

            var msgForInvalidInput = WaitAndGetBySelector("msgForInavalidInput", ApplicationSettings.TimeOut.Fast);
            return msgForInvalidInput != null && msgForInvalidInput.Displayed && msgForInvalidInput.Text == "The Password field is required.";
        }
        internal void ClickHeaderOfRegisterPage()
        {
            var header = WaitAndGetBySelector("Registereader", ApplicationSettings.TimeOut.Fast);
            header.Click();
        }

        //internal bool IsVisible()
        //{
        //    var registerForm = WaitAndGetBySelector("registerForm", ApplicationSettings.TimeOut.Slow);
        //    return registerForm != null && registerForm.Displayed;
        //}
    }
}