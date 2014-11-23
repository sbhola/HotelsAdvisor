using System.Threading;
using AppacitiveAutomationFramework;
using HoteladvisorUIAutomation.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HoteladvisorUIAutomation.Pages
{
    public class HotelListingPage : UIPage
    {
        internal bool IsVisible()
        {
            var pAddress = WaitAndGetBySelector("pAddress", ApplicationSettings.TimeOut.Slow);
            return pAddress != null && pAddress.Displayed;
        }

        internal void ClickOnDiscountHotelLogoImage()
        {
            var logoImg = GetUIElementBySelector("logoImg");
            if (logoImg == null || !logoImg.Displayed)
            {
                Assert.Fail("Logo Image Not Displayed");
            }
            logoImg.Click();
            Thread.Sleep(500);
        }

        internal bool IsRegisterAndloginLinkShown()
        {
            var registerLink = WaitAndGetBySelector("registerLink", ApplicationSettings.TimeOut.Slow);
            var loginLink = WaitAndGetBySelector("loginLink", ApplicationSettings.TimeOut.Slow);

            return registerLink != null && loginLink != null && registerLink.Displayed && loginLink.Displayed;
        }

        internal bool IsUserNameAndLogOffLinkShow()
        {
            Thread.Sleep(500);
            var displayUserName = WaitAndGetBySelector("displayUserName", ApplicationSettings.TimeOut.Slow);
            var logoutForm = WaitAndGetBySelector("logoutForm", ApplicationSettings.TimeOut.Slow);

            return displayUserName != null && logoutForm != null && displayUserName.Displayed && logoutForm.Displayed;
        }

        internal void ClickOnRegisterLink()
        {
            var registerLink = WaitAndGetBySelector("registerLink", ApplicationSettings.TimeOut.Slow);

            if (registerLink == null || !registerLink.Displayed)
            {
                Assert.Fail("Register Link Not Displayed");
            }

            //Thread.Sleep(500);
            registerLink.Click();
            Thread.Sleep(500);
        }


        internal void ClickOnLoginLink()
        {
            var loginLink = WaitAndGetBySelector("loginLink", ApplicationSettings.TimeOut.Slow);
            if (loginLink == null || !loginLink.Displayed)
            {
                Assert.Fail("Login Link Not Displayed");
            }
            Thread.Sleep(2000);
            loginLink.Click();
            Thread.Sleep(500);
        }

        internal void ClickOnLogOffLink()
        {
            var logoutForm = WaitAndGetBySelector("logoutForm", ApplicationSettings.TimeOut.Slow);
            if (logoutForm == null || !logoutForm.Displayed)
            {
                Assert.Fail("LogOff Link Not Displayed");
            }
            logoutForm.Click();
        }

        internal bool SearchByLocationWhenHotelDoesNotExistShouldRedirectToErrorPage()
        {
            Thread.Sleep(500);
            var h1ErrorPage = WaitAndGetBySelector("h1ErrorPage", ApplicationSettings.TimeOut.Slow);
            return h1ErrorPage != null && h1ErrorPage.Text.Equals("Error.");
        }

        internal bool CheckForHotelCount()
        {
            var hotelCount = WaitAndGetBySelector("pHotelCount", ApplicationSettings.TimeOut.Slow);
            //checking for wing,al,us which has 6 hotels in our database

            if (hotelCount.Displayed && hotelCount.Text != null)
            {
                var hotelDisplayDiv = GetUIElements("hotelDisplayDiv");
                if (hotelCount.Text.Contains(hotelDisplayDiv.Count.ToString()))
                {
                    return true;
                }
            }
            return false;

            //if (hotelCount.Displayed && hotelCount.Text.Contains("6"))
            //{
            //    var hotelDisplayDiv = GetUIElements("hotelDisplayDiv");
            //    if (hotelDisplayDiv.Count == 6)
            //    {
            //        return true;
            //    }
            //}
            //return false;
        }

        internal void ClickOnHotelImage()
        {
            var imgClick = WaitAndGetBySelector("imgClick", ApplicationSettings.TimeOut.Slow);
            if (imgClick == null || !imgClick.Displayed)
            {
                Assert.Fail("Hotel Image Not Displayed");
            }

            Thread.Sleep(1000);
            imgClick.Click();
            Thread.Sleep(1000);

        }

        internal bool IsImageDisplayedInPopUpWindow()
        {
            var cboxPhoto = WaitAndGetBySelector("imgCboxPhoto", ApplicationSettings.TimeOut.Slow);
            return cboxPhoto != null && cboxPhoto.Displayed;
        }

        internal bool ClickOnPopUpWindowCloseButton()
        {
            var cboxClose = WaitAndGetBySelector("imgCboxClose", ApplicationSettings.TimeOut.Slow);
            if (cboxClose != null && cboxClose.Displayed)
            {
                Thread.Sleep(1000);
                cboxClose.Click();
                Thread.Sleep(1000);
                return true;
            }
            return false;
        }

        internal void ClickOnHotelNameLink()
        {

            var hotelNameLink = WaitAndGetBySelector("hotelNameLink", ApplicationSettings.TimeOut.Slow);
            if (hotelNameLink == null || !hotelNameLink.Displayed)
            {
                Assert.Fail("Hotel Name Link Not Displayed");
            }
            hotelNameLink.Click();

            Thread.Sleep(1000);
        }

        internal void ClickOnShowDetailsButton()
        {
            var showDetailsButton = WaitAndGetBySelector("showDetailsButton", ApplicationSettings.TimeOut.Slow);
            if (showDetailsButton == null || !showDetailsButton.Displayed)
            {
                Assert.Fail("Show Details Button Not Displayed");
            }
            Thread.Sleep(1000);

            showDetailsButton.Click();
            Thread.Sleep(1000);
        }

    }
}