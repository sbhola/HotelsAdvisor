using System.Threading;
using HoteladvisorUIAutomation.Application;
using HoteladvisorUIAutomation.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HoteladvisorUIAutomation.Tests
{
    [TestClass]
    public class HotelListingPageTests
    {
        private static HotelsAdvisorApp _app;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _app = TestHelper.HotelsApp;
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        [TestInitialize]
        public void TestInitialize()
        {
            TestHelper.IndexPageInitialize();
            Assert.IsTrue(_app.HomePage.IsVisible(), "Could not Load Home Page!");
            Thread.Sleep(500);

            if (!_app.HomePage.IsRegisterAndloginLinkShownIfUserNotLoggedIn())
            {
                _app.LoginPage.LogOutUser();
            }
            Thread.Sleep(2000);
            //_app.HomePage.EnterTextAndSelectFirstOption();
            _app.HomePage.SearchByLocation("Windsor");

        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void ClickOnDiscountHotelLogoImageShouldRedirectToIndexPage()
        {
            _app.HotelListingPage.ClickOnDiscountHotelLogoImage();
            Thread.Sleep(5000);
            Assert.IsTrue(_app.HomePage.IsVisible());
        }

        [TestMethod]
        public void HotelListingPageVisibleOrNot()
        {
            Assert.IsTrue(_app.HotelListingPage.IsVisible(), "Could not Load Hotel Listing Page!");
        }

        [TestMethod]
        public void IfUserNotLoggedInThenShouldShowRegisterAndLoginLink()
        {
            Assert.IsTrue(_app.HotelListingPage.IsRegisterAndloginLinkShown(), "Register & Login Link Not displayed");
        }

        [TestMethod]
        public void IfUserLoggedInThenShouldShowUserNameAndLogOffLink()
        {
            Assert.IsTrue(_app.HomePage.Login("saif@gmail.com", "saif2752"), "Login Error Occured");
            Thread.Sleep(500);
            _app.HomePage.SearchByLocation("Windsor");
            Assert.IsTrue(_app.HotelListingPage.IsUserNameAndLogOffLinkShow(), "UserName & LogOff Link Not Displayed");
        }

        [TestMethod]
        public void ClickOnRegisterLinkShouldRedirectToRegisterPage()
        {
            _app.HotelListingPage.ClickOnRegisterLink();
            Assert.IsTrue(_app.RegisterPage.IsVisible(), "Not Redirect to Register Page");
        }

        [TestMethod]
        public void ClickOnLoginLinkShouldRedirectToLoginPage()
        {
            _app.HotelListingPage.ClickOnLoginLink();
            Assert.IsTrue(_app.LoginPage.IsVisible(), "Not Redirect to Login Page");
        }

        [TestMethod]
        public void ClickOnLogOffLinkShouldLoggoutAndRedirectToIndexPage()
        {
            Assert.IsTrue(_app.HomePage.Login("saif@gmail.com", "saif2752"), "Login Error Occured");
            Thread.Sleep(1000);
            _app.HomePage.SearchByLocation("Windsor");
            Thread.Sleep(1000);
            Assert.IsTrue(_app.HotelListingPage.IsUserNameAndLogOffLinkShow(), "UserName & LogOff Link Not Displayed");
            _app.HotelListingPage.ClickOnLogOffLink();
            Assert.IsTrue(_app.HomePage.IsVisible());
        }

        [TestMethod]
        public void IfHotelCountIsZeroThenShouldRedirectToErrorPage()
        {
            TestHelper.IndexPageInitialize();
            Thread.Sleep(1000);
            _app.HomePage.SearchByLocation("wing");
            Thread.Sleep(5000);
            Assert.IsTrue(_app.HotelListingPage.SearchByLocationWhenHotelDoesNotExistShouldRedirectToErrorPage(), "Error Page Not Displayed");
        }

        [TestMethod]
        public void TestForHotelCountAndVerifyingSameNoOfHotelsDisplayedOnPage()
        {
            Assert.IsTrue(_app.HotelListingPage.CheckForHotelCount(), "Hotel Count Not Matching");
        }

        [TestMethod]
        public void ClickOnHotelImageShouldOpenImageInPopUpWindow()
        {
            Thread.Sleep(2000);
            _app.HotelListingPage.ClickOnHotelImage();
            Assert.IsTrue(_app.HotelListingPage.IsImageDisplayedInPopUpWindow(), "Could Not Open Image Pop Up Window");
        }

        [TestMethod]
        public void ClickCloseButtonShouldClosePopUpWindow()
        {
            _app.HotelListingPage.ClickOnHotelImage();
            Assert.IsTrue(_app.HotelListingPage.IsImageDisplayedInPopUpWindow(), "Could Not Open Image Pop Up Window");
            _app.HotelListingPage.ClickOnPopUpWindowCloseButton();
        }

        [TestMethod]
        public void ClickOnHotelNameLinkShouldRedirectToHotelDetailsPage()
        {
            _app.HotelListingPage.ClickOnHotelNameLink();
            Thread.Sleep(500);
            Assert.IsTrue(_app.DetailsPage.IsVisible(), "Could Not Redirect To Hotel Details Page");
        }

        [TestMethod]
        public void ClickOnShowDetailsButtonShouldRedirectToHotelDetailsPage()
        {
            _app.HotelListingPage.ClickOnShowDetailsButton();
            Assert.IsTrue(_app.DetailsPage.IsVisible(), "Could Not Redirect to Hotel Details Page");
        }
    }
}