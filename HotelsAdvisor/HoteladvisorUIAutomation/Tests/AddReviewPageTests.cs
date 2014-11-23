using System.Threading;
using HoteladvisorUIAutomation.Application;
using HoteladvisorUIAutomation.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HoteladvisorUIAutomation.Tests
{
    [TestClass]
    public class AddReviewPageTests
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
            Thread.Sleep(500);
            _app.HomePage.SearchByHotelName("Courtyard");
            Thread.Sleep(500);
            Assert.IsTrue(_app.DetailsPage.IsVisible(), "Details Page Not Displayed");
            _app.DetailsPage.ClickOnAddReviewButton();
            if (!_app.LoginPage.IsSuccessfullyLoggedIn())
            {
                _app.LoginPage.EnterUserName("saif@gmail.com");
                _app.LoginPage.EnterPassword("saif2752");
                _app.LoginPage.ClickSubmitButton();
            }

            Assert.IsTrue(_app.AddReviewPage.IsVisible(), "Add Review Page Not Visible");
            Thread.Sleep(500);
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        /// <summary>
        /// Redirect to Index/Home Page,When Logo Image is Click
        /// </summary>
        [TestMethod]
        public void ClickOnDiscountHotelLogoImageShouldRedirectToIndexPage()
        {
            _app.AddReviewPage.ClickDiscountHotelLogoImage();
            var result = _app.HomePage.IsVisible();
            Thread.Sleep(500);
            Assert.IsTrue(result, "Could Not Redirect To Index/Home Page");
        }

        /// <summary>
        /// Redirect to Index/Home Page,When LogOff link is click
        /// </summary>
        [TestMethod]
        public void ClickOnLogOffLinkShouldRedirectToIndexPage()
        {
            _app.AddReviewPage.ClickLogOffLink();
            Assert.IsTrue(_app.HomePage.IsVisible(), "Could Not Redirect To Index/Home Page");

            //_app.HomePage.ClickOnLoginButton();
            //Assert.IsTrue(_app.LoginPage.IsVisible());
            //_app.LoginPage.EnterUserName("saif@gmail.com");
            //_app.LoginPage.EnterPassword("saif2752");
            //_app.LoginPage.ClickSubmitButton();
            //_app.HomePage.Login("saif@gmail.com", "saif2752");
        }

        /// <summary>
        /// Redirect to Details Page,When Hotel details link is click
        /// </summary>
        [TestMethod]
        public void ClickOnHotelDetailsLinkShouldRedirectToHotelDetailsPage()
        {
            _app.AddReviewPage.ClickHotelDetailsLink();
            Thread.Sleep(1000);
            Assert.IsTrue(_app.DetailsPage.IsVisible(), "Could Not Redirect To Hotel Details Page");
        }

        /// <summary>
        /// This Test Case Should Show Validation Message for All Required Fields
        /// </summary>
        [TestMethod]
        public void ClickOnAddReviewButtonWhenAllFeildsAreNullOrEmpty()
        {
            _app.AddReviewPage.ClickAddReviewButton();
            Assert.IsTrue(_app.AddReviewPage.IsTitleValidationDisplayed(), "Title Field Not Validated");
            Assert.IsTrue(_app.AddReviewPage.IsDescriptionValidationDisplayed(), "Description Field Not Validated");
            Assert.IsTrue(_app.AddReviewPage.IsOverallRatingValidationDisplayed(), "Overall Rating Field Not Validated");
        }

        /// <summary>
        /// Entering Less Than 4 Characters for Description Field,Should Show Validation Message
        /// </summary>
        [TestMethod]
        public void TestForEnteringLessThanFourCharactersForTitleFieldShouldShowAppropriateValidationMessage()
        {
            Thread.Sleep(500);
            _app.AddReviewPage.EnterTextInTitleField("aa");
            _app.AddReviewPage.ClickAddReviewButton();
            Assert.IsTrue(_app.AddReviewPage.IsTitleValidationDisplayed(), "Title Field Not Validated");
        }

        /// <summary>
        /// Entering More Than 50 characters for Title Field,Should Show Validation Message 
        /// </summary>
        [TestMethod]
        public void TestForEnteringMoreThanFiftyCharactersForTitleFieldShouldShowAppropriateValidationMessage()
        {
            _app.AddReviewPage.EnterTextInTitleField("abababababadasdasdasdasdasdsadsadsadsfasgfredsafd12");
            _app.AddReviewPage.ClickAddReviewButton();
            Assert.IsTrue(_app.AddReviewPage.IsTitleValidationDisplayed(), "Title Field Not Validated");
        }

        /// <summary>
        /// Entering More Than 4 characters & less Than 50 Characters for Title Field
        /// </summary>
        [TestMethod]
        public void TestForEnteringTitleFieldShouldNotShowErrorMessage()
        {
            _app.AddReviewPage.EnterTextInTitleField("Excellent Hotel!!");
            _app.AddReviewPage.ClickAddReviewButton();
            Assert.IsFalse(_app.AddReviewPage.IsTitleValidationDisplayed(), "Validation Message Displayed for Valid Title");
        }

        /// <summary>
        /// Entering Less Than 4 Characters for Description Field,Should Show Validation Message 
        /// </summary>
        [TestMethod]
        public void TestForEnteringLessThanFourCharactersForDescriptionFieldShouldShowAppropriateValidationMessage()
        {
            _app.AddReviewPage.EnterTextInDescriptionField("aa");
            _app.AddReviewPage.ClickAddReviewButton();
            Assert.IsTrue(_app.AddReviewPage.IsDescriptionValidationDisplayed(), "Description Field Not Validated");
        }

        /// <summary>
        /// Entering More Than 100 characters for Description Field,Should Show Validation Message 
        /// </summary>
        [TestMethod]
        public void TestForEnteringMoreThanHundredCharactersForDescriptionFieldShouldShowAppropriateValidationMessage()
        {
            _app.AddReviewPage.EnterTextInDescriptionField("abababababadasdasdasdasdasdsadsadsadsfasgfredsafd12abababababadasdasdasdasdasdsadsadsadsfasgfredsafd12asdas");
            _app.AddReviewPage.ClickAddReviewButton();
            Assert.IsTrue(_app.AddReviewPage.IsDescriptionValidationDisplayed(), "Description Field Not Validated");
        }

        /// <summary>
        /// Entering More Than 4 characters & less Than 100 Characters for Description Field
        /// </summary>
        [TestMethod]
        public void TestForEnteringValidDescriptionFieldShouldNotShowErrorMessage()
        {
            _app.AddReviewPage.EnterTextInDescriptionField("Hotel Service is Awesome !!");
            _app.AddReviewPage.ClickAddReviewButton();
            Assert.IsFalse(_app.AddReviewPage.IsDescriptionValidationDisplayed(), "Validation Message Shown For Valid Description");
        }

        /// <summary>
        /// This Test Case Should Show Respective Validation Message
        /// </summary>
        [TestMethod]
        public void TestForOverallRatingValidation()
        {
            _app.AddReviewPage.ClickAddReviewButton();
            Assert.IsTrue(_app.AddReviewPage.IsOverallRatingValidationDisplayed(), "Overall Rating is Not Validated");
        }

        /// <summary>
        /// This test case Should Change Color of OverAllRating Star & Not show Validation Message
        /// </summary>
        [TestMethod]
        public void ClickOnOverallRatingStarShouldChangeColorOfStar()
        {
            _app.AddReviewPage.ClickOverallRatingStar();
            Assert.IsFalse(_app.AddReviewPage.IsOverallRatingValidationDisplayed(), "Validation Message Displayed For Valid Input");
            Assert.IsTrue(_app.AddReviewPage.IsColorChangeOfOverallRatingStar(), "Color Of Star Not Changed");
        }

        /// <summary>
        /// This Test Case Should Change color of respective star clicked
        /// </summary>
        [TestMethod]
        public void ClickOnServiceLocationRoomsCleanlinessValueOverallRatingStar()
        {
            _app.AddReviewPage.ClickServiceStar();
            Assert.IsTrue(_app.AddReviewPage.IsColorChangeOfServiceRatingStar(), "Color Not Changed For Service Rating Star");

            _app.AddReviewPage.ClickLocationStar();
            Assert.IsTrue(_app.AddReviewPage.IsColorChangeOfLocationRatingStar(), "Color Not Changed For Location Rating Star");

            _app.AddReviewPage.ClickRoomsStar();
            Assert.IsTrue(_app.AddReviewPage.IsColorChangeOfRoomsRatingStar(), "Color Not Changed For Rooms Rating Star");

            _app.AddReviewPage.ClickCleanlinessStar();
            Assert.IsTrue(_app.AddReviewPage.IsColorChangeOfCleanlinessRatingStar(), "Color Not Changed For Cleanliness Rating Star");

            _app.AddReviewPage.ClickValueStar();
            Assert.IsTrue(_app.AddReviewPage.IsColorChangeOfValueRatingStar(), "Color Not Changed For Value Rating Star");

            _app.AddReviewPage.ClickOverallRatingStar();
            Assert.IsTrue(_app.AddReviewPage.IsColorChangeOfOverallRatingStar(), "Color Of Star Not Changed");
        }

        /// <summary>
        /// This Test Case Should Add Review in Database & Redirect to Hotel Details Page
        /// </summary>
        [TestMethod]
        public void AddReviewWhenAllRequiredFieldsAreFilledValid()
        {
            _app.AddReviewPage.EnterTextInTitleField("Excellent Hotel !!");
            Assert.IsFalse(_app.AddReviewPage.IsTitleValidationDisplayed());
            _app.AddReviewPage.EnterTextInDescriptionField("Hotel Service is Awesome !!");
            Assert.IsFalse(_app.AddReviewPage.IsDescriptionValidationDisplayed());
            _app.AddReviewPage.ClickOverallRatingStar();
            Assert.IsTrue(_app.AddReviewPage.IsColorChangeOfOverallRatingStar());
            Assert.IsFalse(_app.AddReviewPage.IsOverallRatingValidationDisplayed());
            _app.AddReviewPage.ClickAddReviewButton();
            Thread.Sleep(1000);
            Assert.IsTrue(_app.DetailsPage.IsVisible(), "Could Not Redirect To Hotel Details Page");
        }

        /// <summary>
        /// This Test Case Should Add Review in Database & Redirect to Hotel Details Page
        /// </summary>
        [TestMethod]
        public void AddReviewWhenAllFeildsAreFilledValid()
        {
            _app.AddReviewPage.EnterTextInTitleField("Excellent Hotel !!");
            Assert.IsFalse(_app.AddReviewPage.IsTitleValidationDisplayed());
            _app.AddReviewPage.EnterTextInDescriptionField("Hotel Service is Awesome !!");
            Assert.IsFalse(_app.AddReviewPage.IsDescriptionValidationDisplayed());

            _app.AddReviewPage.ClickServiceStar();
            Assert.IsTrue(_app.AddReviewPage.IsColorChangeOfServiceRatingStar(), "Color Not Changed For Service Rating Star");

            _app.AddReviewPage.ClickLocationStar();
            Assert.IsTrue(_app.AddReviewPage.IsColorChangeOfLocationRatingStar(), "Color Not Changed For Location Rating Star");

            _app.AddReviewPage.ClickRoomsStar();
            Assert.IsTrue(_app.AddReviewPage.IsColorChangeOfRoomsRatingStar(), "Color Not Changed For Rooms Rating Star");

            _app.AddReviewPage.ClickCleanlinessStar();
            Assert.IsTrue(_app.AddReviewPage.IsColorChangeOfCleanlinessRatingStar(), "Color Not Changed For Cleanliness Rating Star");

            _app.AddReviewPage.ClickValueStar();
            Assert.IsTrue(_app.AddReviewPage.IsColorChangeOfValueRatingStar(), "Color Not Changed For Value Rating Star");

            _app.AddReviewPage.ClickOverallRatingStar();
            Assert.IsTrue(_app.AddReviewPage.IsColorChangeOfOverallRatingStar());
            Assert.IsFalse(_app.AddReviewPage.IsOverallRatingValidationDisplayed());
            _app.AddReviewPage.ClickAddReviewButton();
            Thread.Sleep(1000);
            Assert.IsTrue(_app.DetailsPage.IsVisible(), "Could Not Redirect To Hotel Details Page");
        }

        /// <summary>
        /// This Test Case Should Show Validation Message for other required field(Description,Overall Rating)
        /// </summary>
        [TestMethod]
        public void TestWhenOnlyTitleFieldIsFilledValid()
        {
            _app.AddReviewPage.EnterTextInTitleField("Excellent Hotel !!");
            Assert.IsFalse(_app.AddReviewPage.IsTitleValidationDisplayed());
            _app.AddReviewPage.ClickAddReviewButton();

            Assert.IsTrue(_app.AddReviewPage.IsDescriptionValidationDisplayed());
            Assert.IsTrue(_app.AddReviewPage.IsOverallRatingValidationDisplayed());
        }

        /// <summary>
        /// This Test Case Should Show Validation Message for other required field(Title,Overall Rating)
        /// </summary>
        [TestMethod]
        public void TestWhenOnlyDescriptionFieldIsFilledValid()
        {
            _app.AddReviewPage.EnterTextInDescriptionField("Hotel Service is Awesome !!");
            Assert.IsFalse(_app.AddReviewPage.IsDescriptionValidationDisplayed());
            _app.AddReviewPage.ClickAddReviewButton();

            Assert.IsTrue(_app.AddReviewPage.IsTitleValidationDisplayed());
            Assert.IsTrue(_app.AddReviewPage.IsOverallRatingValidationDisplayed());
        }

        /// <summary>
        /// This Test Case Should Show Validation Message for other required field(Title,Description)
        /// </summary>
        [TestMethod]
        public void TestWhenOnlyOverallRatingFieldIsFilledValid()
        {
            _app.AddReviewPage.ClickOverallRatingStar();
            Assert.IsTrue(_app.AddReviewPage.IsColorChangeOfOverallRatingStar());
            _app.AddReviewPage.ClickAddReviewButton();
            Assert.IsTrue(_app.AddReviewPage.IsTitleValidationDisplayed());
            Assert.IsTrue(_app.AddReviewPage.IsDescriptionValidationDisplayed());
        }
    }
}