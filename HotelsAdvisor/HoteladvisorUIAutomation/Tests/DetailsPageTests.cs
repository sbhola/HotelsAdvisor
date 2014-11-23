
using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HoteladvisorUIAutomation.Application;
using HoteladvisorUIAutomation.Utility;
using AppacitiveAutomationFramework;

namespace HoteladvisorUIAutomation.Tests
{
    /// <summary>
    /// Summary description for DetailsPageTests
    /// </summary>
    [TestClass]
    public class DetailsPageTests
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
            TestHelper.DetailsPageInitialize();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            //if the user is logged in then log him out
            TestHelper.DetailsPageInitialize();
            if (_hotelsApp.DetailsPage.IsSuccessfullyLoggedIn())
            {
                _hotelsApp.DetailsPage.LogOutUser();
            }
        }

        [TestMethod]
        public void TestIsDetailsPageLoaded()
        {
            Assert.IsTrue(_hotelsApp.DetailsPage.IsVisible(),"could not load details page");
        }

        [TestMethod]
        public void ShouldRedirectToRegisterPageWhenUserClicksOnRegisterLink()
        {
            Assert.IsTrue(_hotelsApp.DetailsPage.IsVisible(),"could not load details page");
            _hotelsApp.DetailsPage.ClickRegisterLink();
            Assert.IsTrue(_hotelsApp.DetailsPage.IsRegisterPageOpen(),"Register page not loaded");
        }

        [TestMethod]
        public void ShouldRedirectToLoginPageWhenUserClicksOnLoginLink()
        {
            Assert.IsTrue(_hotelsApp.DetailsPage.IsVisible(), "could not load details page");
            _hotelsApp.DetailsPage.ClickLoginLink();
            Assert.IsTrue(_hotelsApp.DetailsPage.IsLoginPageVisible(),"could not load login page");
        }

        [TestMethod]
        public void ShouldRedirectToHomePageWhenDiscountHotelsButtonClicked()
        {
            Assert.IsTrue(_hotelsApp.DetailsPage.IsVisible(),"could not load details page");
            _hotelsApp.DetailsPage.ClickDiscountHotelButton();
            Assert.IsTrue(_hotelsApp.DetailsPage.IsHomePageDisplayed(),"could not load home page");
        }

        [TestMethod]
        public void ShouldOpenImageInPopUpGalleryWhenHotelsMainImageClicked()
        {
            Assert.IsTrue(_hotelsApp.DetailsPage.IsVisible());
            _hotelsApp.DetailsPage.ClickHotelsMainImage();
            Assert.IsTrue(_hotelsApp.DetailsPage.IsImageOpenedInGallery(),"Image did not load in gallery");
        }

        [TestMethod]
        public void ShouldOpenImageInPopUpGalleryWhenHotelsImageGalleryClicked()
        {
            Assert.IsTrue(_hotelsApp.DetailsPage.IsVisible());
            Thread.Sleep(3000);
            _hotelsApp.DetailsPage.ClickHotelImageGallery();
            Assert.IsTrue(_hotelsApp.DetailsPage.IsImageOpenedInGallery(), "Image did not load in gallery");
        }

        [TestMethod]
        public void ShouldAutoPlayImagesWhenPlayButtonOnGalleryClicked()
        {
            Assert.IsTrue(_hotelsApp.DetailsPage.IsVisible());
            Thread.Sleep(3000);
            _hotelsApp.DetailsPage.ClickHotelImageGallery();
            Assert.IsTrue(_hotelsApp.DetailsPage.IsImageOpenedInGallery(),"Image did not open in gallery");
            _hotelsApp.DetailsPage.ClickOnAutoplayButtonOfImageGallery();
            Assert.IsTrue(_hotelsApp.DetailsPage.IsGalleryAutoplayWorkingCorrectly(),"gallery autplay not working correctly");
        }

        [TestMethod]
        public void ShouldOpenNextImageInGalleryWhenNextButtonOfGalleryClicked()
        {
            Assert.IsTrue(_hotelsApp.DetailsPage.IsVisible(),"details page is not visible");
            _hotelsApp.DetailsPage.ClickHotelsMainImage();
            Assert.IsTrue(_hotelsApp.DetailsPage.IsImageOpenedInGallery(), "Image did not open in gallery");
            _hotelsApp.DetailsPage.ClickOnNextButtonOfGallery();
            Assert.IsTrue(_hotelsApp.DetailsPage.IsNextImageOpened(),"next image did not open");
        }

        [TestMethod]
        public void ShoulOpenPreviousImageInGalleryWhenPreviousdButtonOfGalleryClicked()
        {
            Assert.IsTrue(_hotelsApp.DetailsPage.IsVisible(),"details page not visible");
            Thread.Sleep(3000);
            _hotelsApp.DetailsPage.ClickHotelImageGallery();
            Assert.IsTrue(_hotelsApp.DetailsPage.IsImageOpenedInGallery(),"Image gallery did not open");
            _hotelsApp.DetailsPage.ClickOnPreviousButtonOfGallery();
            Thread.Sleep(1000);
            Assert.IsTrue(_hotelsApp.DetailsPage.IsPreviousImageLoaded(),"previous image did not load");
        }

        [TestMethod]
        public void ShouldCloseGalleryContainerWhenCloseButtonOfGalleryClicked()
        {
            Assert.IsTrue(_hotelsApp.DetailsPage.IsVisible(), "details page not visible");
            Thread.Sleep(3000);
            _hotelsApp.DetailsPage.ClickHotelImageGallery();
            Assert.IsTrue(_hotelsApp.DetailsPage.IsImageOpenedInGallery(), "Image gallery did not open");
            _hotelsApp.DetailsPage.ClickCloseButtonOfGallery(); 
            Assert.IsFalse(_hotelsApp.DetailsPage.IsImageOpenedInGallery(),"Gallery did not close");
        }

        [TestMethod]
        public void ShouldRedirectToLoginPageWhenAddReviewButtonClickedAndUserIsNotLoggedIn()
        {
            Assert.IsTrue(_hotelsApp.DetailsPage.IsVisible(), "details page not visible");
            _hotelsApp.DetailsPage.ClickOnAddReviewButton();
            Assert.IsTrue(_hotelsApp.DetailsPage.IsLoginPageVisible(),"login page did not open");
        }

        [TestMethod]
        public void ShouldRedirectToAddReviewPageIfUserIsLoggedInAndClicksOnAddReviewButton()
        {
            Assert.IsTrue(_hotelsApp.DetailsPage.IsVisible(), "details page not visible");
            _hotelsApp.DetailsPage.ClickLoginLink();
            Assert.IsTrue(_hotelsApp.DetailsPage.IsLoginPageVisible(),"login page did not open");
            _hotelsApp.DetailsPage.EnterUserName("yellow@yel.com");
            _hotelsApp.DetailsPage.EnterPassword("111111");
            _hotelsApp.DetailsPage.ClickSubmitButtonOfLoginPage();
            Assert.IsTrue(_hotelsApp.DetailsPage.IsSuccessfullyLoggedIn(),"Login Unsuccessful");
            TestHelper.DetailsPageInitialize();
            _hotelsApp.DetailsPage.ClickOnAddReviewButton();
            Assert.IsTrue(_hotelsApp.DetailsPage.IsAddReviewPageDisplayed(),"Add Review Page did not open");
        }

        [TestMethod]
        public void ShouldDisassociateUserWhenLogOffClicked()
        {
            Assert.IsTrue(_hotelsApp.DetailsPage.IsVisible(), "details page not visible");
            _hotelsApp.DetailsPage.ClickLoginLink();
            Assert.IsTrue(_hotelsApp.DetailsPage.IsLoginPageVisible(), "login page did not open");
            _hotelsApp.DetailsPage.EnterUserName("yellow@yel.com");
            _hotelsApp.DetailsPage.EnterPassword("111111");
            _hotelsApp.DetailsPage.ClickSubmitButtonOfLoginPage();
            Assert.IsTrue(_hotelsApp.DetailsPage.IsSuccessfullyLoggedIn(), "Login Unsuccessful");
            TestHelper.DetailsPageInitialize();
            _hotelsApp.DetailsPage.LogOutUser();
            Assert.IsFalse(_hotelsApp.DetailsPage.IsSuccessfullyLoggedIn(),"user did not log out");
            Assert.IsTrue(_hotelsApp.DetailsPage.IsHomePageDisplayed(),"home page did not open");
        }

        [TestMethod]
        public void ShouldShowGoogleMapWhenUserClickesOnMapTab()
        {
            Assert.IsTrue(_hotelsApp.DetailsPage.IsVisible(), "details page not visible");
            //click on map tab
            _hotelsApp.DetailsPage.ClickOnMapTab();
            Assert.IsTrue(_hotelsApp.DetailsPage.IsMapVisible(),"Map did not load");
        }

        [TestMethod]
        public void ShouldShowInfoWindowWithHotelDetailsWhenMarkerClicked()
        {
        }

        [TestMethod]
        public void ShouldShowHotelDescriptionWhenUserClicksOnOverviewTab()
        {
            Assert.IsTrue(_hotelsApp.DetailsPage.IsVisible(), "details page not visible");
            _hotelsApp.DetailsPage.ClickOnOverviewTab();
            Assert.IsTrue(_hotelsApp.DetailsPage.IsDescriptionTabShown(),"description tab did not open");
        }

        [TestMethod]
        public void ShouldLoadReviewsTabByDefaultOnPageLoad()
        {
            Assert.IsTrue(_hotelsApp.DetailsPage.IsVisible(), "details page not visible");
            Assert.IsTrue(_hotelsApp.DetailsPage.IsReviewsTabActive(),"Review tab is not active");
        }

    }
}

