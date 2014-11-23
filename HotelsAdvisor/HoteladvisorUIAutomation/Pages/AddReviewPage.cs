using System.Threading;
using AppacitiveAutomationFramework;
using HoteladvisorUIAutomation.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HoteladvisorUIAutomation.Pages
{
    public class AddReviewPage : UIPage
    {
        internal bool IsVisible()
        {
            var frmAddReview = WaitAndGetBySelector("frmAddReview", ApplicationSettings.TimeOut.Fast);
            return frmAddReview != null && frmAddReview.Displayed;
        }

        internal void ClickDiscountHotelLogoImage()
        {
            Thread.Sleep(500);
            var logoImg = WaitAndGetBySelector("logoImg", ApplicationSettings.TimeOut.Fast);
            if (logoImg == null || !logoImg.Displayed)
            {
                Assert.Fail("Logo Image Not Displayed");
            }
            logoImg.Click();
        }

        internal void ClickLogOffLink()
        {
            Thread.Sleep(500);
            var logoutForm = WaitAndGetBySelector("logoutForm", ApplicationSettings.TimeOut.Slow);
            if (logoutForm == null || !logoutForm.Displayed)
            {
                Assert.Fail("LogOff Link Not Displayed");
            }
           
            logoutForm.Click();
        }

        internal void ClickHotelDetailsLink()
        {
            var hotelDetailsLink = WaitAndGetBySelector("hotelDetailsLink", ApplicationSettings.TimeOut.Fast);

            if (hotelDetailsLink == null || !hotelDetailsLink.Displayed)
            {
                Assert.Fail("Hotel Details Link Not Displayed");
            }

            Thread.Sleep(500);
            hotelDetailsLink.Click();
        }

        internal void ClickAddReviewButton()
        {
            var reviewButton = WaitAndGetBySelector("reviewButton", ApplicationSettings.TimeOut.Fast);
            if (reviewButton == null || !reviewButton.Displayed)
            {
                Assert.Fail("Add Review Button Not Displayed");
            }
            reviewButton.Click();
        }

        internal bool IsTitleValidationDisplayed()
        {
            var titleValidation = GetUIElementBySelector("titleValidation");
            return titleValidation != null && titleValidation.Displayed;
        }

        internal bool IsDescriptionValidationDisplayed()
        {
            var descriptionValidation = GetUIElementBySelector("descriptionValidation");
            return descriptionValidation != null && descriptionValidation.Displayed;
        }


        internal bool IsOverallRatingValidationDisplayed()
        {
            var ratingValidation = GetUIElementBySelector("ratingValidation");
            var overallRatingText = ratingValidation.Text;
            return !string.IsNullOrEmpty(overallRatingText) && ratingValidation.Displayed;
        }

        internal void EnterTextInTitleField(string text)
        {
            var titleTextBox = WaitAndGetBySelector("titleTextBox", ApplicationSettings.TimeOut.Fast);

            if (titleTextBox == null || !titleTextBox.Displayed)
            {
                Assert.Fail("Title TextBox Not Displayed");
            }

            Thread.Sleep(500);
            titleTextBox.SendKeys(text);
            Thread.Sleep(1000);
        }

        internal void EnterTextInDescriptionField(string text)
        {
            var descriptionTextArea = WaitAndGetBySelector("descriptionTextArea", ApplicationSettings.TimeOut.Fast);

            if (descriptionTextArea == null || !descriptionTextArea.Displayed)
            {
                Assert.Fail("Title TextBox Not Displayed");
            }

            Thread.Sleep(500);
            descriptionTextArea.SendKeys(text);
            Thread.Sleep(1000);
        }

        internal void ClickOverallRatingStar()
        {
            var overallRating = WaitAndGetBySelector("overallRating", ApplicationSettings.TimeOut.Fast);

            if (overallRating == null || !overallRating.Displayed)
            {
                Assert.Fail("Overall Rating Star Not Displayed");
            }

            Thread.Sleep(500);
            overallRating.Click();
            Thread.Sleep(1000);
        }

        internal bool IsColorChangeOfOverallRatingStar()
        {
            var overallRating = WaitAndGetBySelector("overallRating", ApplicationSettings.TimeOut.Fast);

            if (overallRating == null || !overallRating.Displayed)
            {
                Assert.Fail("Overall Rating Star Not Displayed");
            }

            Thread.Sleep(500);
            var starColor = overallRating.GetCssValue("color");
            return starColor.Equals("rgba(213, 133, 18, 1)");
        }


        internal void ClickServiceStar()
        {
            var serviceRating = WaitAndGetBySelector("serviceRating", ApplicationSettings.TimeOut.Fast);

            if (serviceRating == null || !serviceRating.Displayed)
            {
                Assert.Fail("Service Rating Stars Not Displayed");
            }

            serviceRating.Click();
            Thread.Sleep(1000);
        }

        internal void ClickLocationStar()
        {
            var locationRating = WaitAndGetBySelector("locationRating", ApplicationSettings.TimeOut.Fast);

            if (locationRating == null || !locationRating.Displayed)
            {
                Assert.Fail("Service Rating Stars Not Displayed");
            }

            locationRating.Click();
            Thread.Sleep(1000);
        }


        internal void ClickRoomsStar()
        {
            var roomsRating = WaitAndGetBySelector("roomsRating", ApplicationSettings.TimeOut.Fast);

            if (roomsRating == null || !roomsRating.Displayed)
            {
                Assert.Fail("Service Rating Stars Not Displayed");
            }

            roomsRating.Click();
            Thread.Sleep(1000);
        }

        internal void ClickCleanlinessStar()
        {
            var cleanlinessRating = WaitAndGetBySelector("cleanlinessRating", ApplicationSettings.TimeOut.Fast);

            if (cleanlinessRating == null || !cleanlinessRating.Displayed)
            {
                Assert.Fail("Service Rating Stars Not Displayed");
            }

            cleanlinessRating.Click();
            Thread.Sleep(1000);
        }

        internal void ClickValueStar()
        {
            var valueRating = WaitAndGetBySelector("valueRating", ApplicationSettings.TimeOut.Fast);

            if (valueRating == null || !valueRating.Displayed)
            {
                Assert.Fail("Service Rating Stars Not Displayed");
            }

            valueRating.Click();
            Thread.Sleep(1000);
        }



        internal bool IsColorChangeOfServiceRatingStar()
        {
            var serviceRating = WaitAndGetBySelector("serviceRating", ApplicationSettings.TimeOut.Fast);

            if (serviceRating == null || !serviceRating.Displayed)
            {
                Assert.Fail("Overall Rating Star Not Displayed");
            }

            Thread.Sleep(500);
            var starColor = serviceRating.GetCssValue("color");
            return starColor.Equals("rgba(213, 133, 18, 1)");
        }


        internal bool IsColorChangeOfLocationRatingStar()
        {
            var locationRating = WaitAndGetBySelector("locationRating", ApplicationSettings.TimeOut.Fast);

            if (locationRating == null || !locationRating.Displayed)
            {
                Assert.Fail("Overall Rating Star Not Displayed");
            }

            Thread.Sleep(500);
            var starColor = locationRating.GetCssValue("color");
            return starColor.Equals("rgba(213, 133, 18, 1)");
        }

        internal bool IsColorChangeOfRoomsRatingStar()
        {
            var roomsRating = WaitAndGetBySelector("roomsRating", ApplicationSettings.TimeOut.Fast);

            if (roomsRating == null || !roomsRating.Displayed)
            {
                Assert.Fail("Overall Rating Star Not Displayed");
            }

            Thread.Sleep(500);
            var starColor = roomsRating.GetCssValue("color");
            return starColor.Equals("rgba(213, 133, 18, 1)");
        }

        internal bool IsColorChangeOfCleanlinessRatingStar()
        {
            var cleanlinessRating = WaitAndGetBySelector("cleanlinessRating", ApplicationSettings.TimeOut.Fast);

            if (cleanlinessRating == null || !cleanlinessRating.Displayed)
            {
                Assert.Fail("Overall Rating Star Not Displayed");
            }

            Thread.Sleep(500);
            var starColor = cleanlinessRating.GetCssValue("color");
            return starColor.Equals("rgba(213, 133, 18, 1)");
        }

        internal bool IsColorChangeOfValueRatingStar()
        {
            var valueRating = WaitAndGetBySelector("valueRating", ApplicationSettings.TimeOut.Fast);

            if (valueRating == null || !valueRating.Displayed)
            {
                Assert.Fail("Overall Rating Star Not Displayed");
            }

            Thread.Sleep(500);
            var starColor = valueRating.GetCssValue("color");
            return starColor.Equals("rgba(213, 133, 18, 1)");
        }
    }
}