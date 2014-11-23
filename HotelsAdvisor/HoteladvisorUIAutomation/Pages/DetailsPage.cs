using System;
using System.Linq.Expressions;
using System.Threading;
using AppacitiveAutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HoteladvisorUIAutomation.Application;
using HoteladvisorUIAutomation.Configuration;
using HoteladvisorUIAutomation.Utility;

namespace HoteladvisorUIAutomation.Pages
{
    public class DetailsPage:UIPage
    {
        internal bool IsVisible()
        {
            var divHotelName = WaitAndGetBySelector("divHotelName", ApplicationSettings.TimeOut.Fast);
            return divHotelName != null && divHotelName.Displayed && (!(string.IsNullOrEmpty(divHotelName.Text)));
        }

        internal void ClickRegisterLink()
        {
            var lnkRegister = WaitAndGetBySelector("lnkRegister", ApplicationSettings.TimeOut.Fast);
            lnkRegister.Click();
        }

        internal bool IsRegisterPageOpen()
        {
            var divCreateAccount = WaitAndGetBySelector("divCreateAccount", ApplicationSettings.TimeOut.Slow);
            return divCreateAccount != null && divCreateAccount.Displayed && divCreateAccount.Text.StartsWith("Create a new");
        }

        internal void ClickLoginLink()
        {
            var lnkLogin = WaitAndGetBySelector("lnkLogin", ApplicationSettings.TimeOut.Fast);
            lnkLogin.Click();
        }

        internal bool IsLoginPageVisible()
        {
            var div = WaitAndGetBySelector("divHome", ApplicationSettings.TimeOut.Slow);
            return div != null && div.Displayed;
        }

        internal void ClickDiscountHotelButton()
        {
            var btnHome = WaitAndGetBySelector("lnkHome", ApplicationSettings.TimeOut.SuperFast);
            btnHome.Click();
        }

        internal bool IsHomePageDisplayed()
        {
            var banerHome = WaitAndGetBySelector("banerHome", ApplicationSettings.TimeOut.Fast);
            return banerHome != null && banerHome.Displayed && banerHome.Text.StartsWith("Browse Hotels");
        }

        internal void ClickHotelsMainImage()
        {
            Thread.Sleep(1000);
            var hotelMainImage = WaitAndGetBySelector("hotelMainImage", ApplicationSettings.TimeOut.Slow);
            hotelMainImage.Click();
        }

        internal void ClickHotelImageGallery()
        {
            var firstImageOfGallery = WaitAndGetBySelector("firstImageOfGallery", ApplicationSettings.TimeOut.Slow);
            firstImageOfGallery.Click();
        }

        internal bool IsImageOpenedInGallery()
        {
            Thread.Sleep(1000);
            var galleryContainer = WaitAndGetBySelector("galleryContainer", ApplicationSettings.TimeOut.Slow);
            return galleryContainer != null && galleryContainer.Displayed;
        }

        internal void ClickOnAutoplayButtonOfImageGallery()
        {
            var autoplayButton = WaitAndGetBySelector("autoplayButton", ApplicationSettings.TimeOut.Slow);
            autoplayButton.Click();
        }

        internal bool IsGalleryAutoplayWorkingCorrectly()
        {
            var count = 0;
            var imageSrc = WaitAndGetBySelector("imageSrc", ApplicationSettings.TimeOut.Fast);
            var imageSrctext = imageSrc.GetAttribute("src");
                
            while (count<5)
            {
                Thread.Sleep(2000);
                var imageSrcNext = WaitAndGetBySelector("imageSrc", ApplicationSettings.TimeOut.Fast);
                var imageSrctextNext = imageSrcNext.GetAttribute("src");
                if (imageSrctext!=imageSrctextNext)
                {
                    return true;
                }
                count ++;
            }
            return false;
        }

        internal bool IsNextImageOpened()
        {
            var imageSrc = WaitAndGetBySelector("imageSrc",ApplicationSettings.TimeOut.Fast);
            var imageSrctext = imageSrc.GetAttribute("src");
            return imageSrctext.Equals("http://images.travelnow.com/hotelimages/s/043000/043462A.jpg");
        }

        internal void ClickOnNextButtonOfGallery()
        {
            var aNextButton = WaitAndGetBySelector("aNextButton", ApplicationSettings.TimeOut.SuperFast);
            aNextButton.Click();
        }

        internal void ClickOnPreviousButtonOfGallery()
        {
            var aPreviousButton = WaitAndGetBySelector("aPreviousButton", ApplicationSettings.TimeOut.SuperFast);
            aPreviousButton.Click();
        }

        internal bool IsPreviousImageLoaded()
        {
            var imageSrc = WaitAndGetBySelector("imageSrc", ApplicationSettings.TimeOut.Fast);
            var imageSrctext = imageSrc.GetAttribute("src");
            return imageSrctext.Equals("http://images.travelnow.com/hotelimages/s/043000/043462A.jpg");
        }

        internal void ClickCloseButtonOfGallery()
        {
            var aCloseButton = WaitAndGetBySelector("aCloseButton", ApplicationSettings.TimeOut.SuperFast);
            aCloseButton.Click();
        }

        internal void ClickOnAddReviewButton()
        {
            var btnAddReview = WaitAndGetBySelector("btnAddReview", ApplicationSettings.TimeOut.SuperFast);
            btnAddReview.Click();
        }

        internal bool IsLoginPageOpen()
        {
            var titleLoginPage = WaitAndGetBySelector("titleLoginPage", ApplicationSettings.TimeOut.Slow);
            return titleLoginPage != null && titleLoginPage.Displayed &&
                   titleLoginPage.Text.ToLower().StartsWith("sign in");
        }

        internal void EnterUserName(string userName)
        {
            var divUserName = WaitAndGetBySelector("userName", ApplicationSettings.TimeOut.SuperFast);
            divUserName.SendKeys(userName);
        }

        internal void EnterPassword(string password)
        {
            var divPassword = WaitAndGetBySelector("password", ApplicationSettings.TimeOut.SuperFast);
            divPassword.SendKeys(password);
        }

        internal void ClickSubmitButtonOfLoginPage()
        {
            var btn = WaitAndGetBySelector("submitButton", ApplicationSettings.TimeOut.SuperFast);
            btn.Click();
        }

        internal Boolean IsSuccessfullyLoggedIn()
        {
            var userName = WaitAndGetBySelector("lnkUserName", ApplicationSettings.TimeOut.Fast);
            return userName != null && userName.Displayed && userName.Text.StartsWith("HELLO");
        }

        internal bool IsAddReviewPageDisplayed()
        {
            var formAddReview = WaitAndGetBySelector("formAddReview", ApplicationSettings.TimeOut.Slow);
            return formAddReview != null && formAddReview.Displayed;
        }

        internal void LogOutUser()
        {
            var aLogOff = WaitAndGetBySelector("aLogOff", ApplicationSettings.TimeOut.SuperFast);
            aLogOff.Click();
        }

        internal void ClickOnMapTab()
        {
            var lnkMap = WaitAndGetBySelector("lnkMap", ApplicationSettings.TimeOut.SuperFast);
            lnkMap.Click();
        }

        internal bool IsMapVisible()
        {
            var map_canvas = WaitAndGetBySelector("map_canvas", ApplicationSettings.TimeOut.Fast);
            return map_canvas != null && map_canvas.Displayed;
        }

        internal void ClickOnOverviewTab()
        {
            var tabOverview = WaitAndGetBySelector("tabOverview", ApplicationSettings.TimeOut.Fast);
            tabOverview.Click();
        }

        internal bool IsDescriptionTabShown()
        {
            var titleDescription = WaitAndGetBySelector("titleDescription", ApplicationSettings.TimeOut.Fast);
            return titleDescription != null && titleDescription.Displayed &&
                   titleDescription.Text.ToLower().Equals("description");
        }

        internal bool IsReviewsTabActive()
        {
            var tabActive = WaitAndGetBySelector("tabActive", ApplicationSettings.TimeOut.Fast);
            return tabActive != null && tabActive.Displayed;
        }
    }
}


