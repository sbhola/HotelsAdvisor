using HoteladvisorUIAutomation.Application;
using HoteladvisorUIAutomation.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HoteladvisorUIAutomation.Tests
{
    [TestClass]
    public class HomePageTests
    {
        private static HotelsAdvisorApp _app;
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _app = TestHelper.HotelsApp;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            TestHelper.HomePageInitialize();
            Thread.Sleep(3000);
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void SelectFirstItemFromAutoComplete()
        {
            _app.HomePage.EnterTextInAutoCompleteSearchBox("a ");
            Thread.Sleep(500);
            _app.HomePage.SelectOptionInDropDownMenu(0);
            _app.HomePage.ClickSearchButton();
            Assert.IsTrue(_app.DetailsPage.IsVisible(), "not able to select items from drop down list");
        }

        [TestMethod]
        public void ShowShowmessageOnEnterOfWhiteSpaces()
        {
            _app.HomePage.EnterTextInAutoCompleteSearchBox("  ");
            Assert.IsTrue(_app.HomePage.IsValidationMessageDisplayed());
        }

        [TestMethod]
        public void ShouldShowMessageIfNoDataExistsForStringEnteredInAutocompeleteSerachBox()
        {
            _app.HomePage.EnterTextInAutoCompleteSearchBox("bashdfbnalsmdlaskdfnjan");
            Assert.IsTrue(_app.HomePage.IsValidationMessageDisplayed());
        }

        [TestMethod]
        public void PressingEnterOrSearchButtonAfterSelectingTheDropDownItemShouldRedirectToDetailsPage()
        {
            _app.HomePage.EnterTextInAutoCompleteSearchBox("a ");
            _app.HomePage.SelectOptionInDropDownMenu(0);
            _app.HomePage.EnterTextInAutoCompleteSearchBox("\n");
            Thread.Sleep(1000);
            Assert.IsTrue(_app.DetailsPage.IsVisible(), "");
        }

        [TestMethod]
        public void PressingEnterOrSearchButtonWithoutSelectionOfDropDownItemShouldRemainOnHomePage()
        {
            _app.HomePage.EnterTextInAutoCompleteSearchBox("a ");
            _app.HomePage.EnterTextInAutoCompleteSearchBox("\n");
            //_app.HomePage.ClickSearchButton();
            _app.HomePage.IsSearchButtonEnabled();
            Assert.IsTrue(_app.HomePage.IsVisible(), "");
        }

        [TestMethod]
        public void PressingEnterOrSearchButtonAfterEnteringWhiteSpacesShouldRemainOnHomePage()
        {
            _app.HomePage.EnterTextInAutoCompleteSearchBox("  ");
            _app.HomePage.EnterTextInAutoCompleteSearchBox("\n");
            //_app.HomePage.ClickSearchButton();
            _app.HomePage.IsSearchButtonEnabled();
            Assert.IsTrue(_app.HomePage.IsVisible(), "");
        }

        [TestMethod]
        public void PressingEnterOrSearchButtonAfterEnteringInvalidSearchStringShouldRemainOnHomePage()
        {
            _app.HomePage.EnterTextInAutoCompleteSearchBox("bashdfbnalsmdlaskdfnjan");
            _app.HomePage.EnterTextInAutoCompleteSearchBox("\n");
            //_app.HomePage.ClickSearchButton();
            _app.HomePage.IsSearchButtonEnabled();
            Assert.IsTrue(_app.HomePage.IsVisible(), "");
        }

        [TestMethod]
        public void PressingEnterOrSearchButtonWithoutEnteringAnythingShouldRemainOnSamePage()
        {
            _app.HomePage.EnterTextInAutoCompleteSearchBox("\n");
            //_app.HomePage.ClickSearchButton();
            _app.HomePage.IsSearchButtonEnabled();
            Assert.IsTrue(_app.HomePage.IsVisible(), "");
        }
        [TestMethod]
        public void ClickingOnThumbnailShouldRedirectToDisplayPage()
        {
            _app.HomePage.ClickThumbnail(0);
            Assert.IsTrue(_app.DetailsPage.IsVisible(), "");
        }
        [TestMethod]
        public void OnClickOnRegisterButtonShouldRedirectToRegisterpage()
        {
            _app.HomePage.ClickRegisterButton();
            Thread.Sleep(1000);
            Assert.IsTrue(_app.RegisterPage.IsVisible(), "could not load Register page!");
        }
        [TestMethod]
        public void OnClickOfLoginButtonShouldRedirectToLoginPage()
        {
            _app.HomePage.ClickLoginButton();
            Thread.Sleep(1000);
            Assert.IsTrue(_app.LoginPage.IsVisible(), "");
        }
        [TestMethod]
        public void IfUserIsLoggedInThenLogoffButtonAndUserNameShouldBeShown()
        {
            _app.HomePage.ClickRegisterButton();
            _app.RegisterPage.EnterEmailId(Guid.NewGuid().ToString() + "@gmail.com");
            _app.RegisterPage.EnterDisplayName("Clarifi");
            _app.RegisterPage.EnterPassword("qwert12345");
            _app.RegisterPage.EnterConfirmPassword("qwert12345");
            _app.RegisterPage.ClickRegister();
            Assert.IsTrue(_app.HomePage.IsLogOffButtonVisible(), "");
            Assert.IsTrue(_app.HomePage.IsUserNameVisibleAfterLoggedIn(), "");
            _app.HomePage.ClickLogOff();
        }
        [TestMethod]
        public void OnClickOfLogOffButtonShouldRemainToHomePage()
        {
            _app.HomePage.ClickRegisterButton();
            _app.RegisterPage.EnterEmailId(Guid.NewGuid().ToString() + "@gmail.com");
            _app.RegisterPage.EnterDisplayName("Clarifi");
            _app.RegisterPage.EnterPassword("qwert12345");
            _app.RegisterPage.EnterConfirmPassword("qwert12345");
            _app.RegisterPage.ClickRegister();
            _app.HomePage.ClickLogOff();
            Assert.IsTrue(_app.HomePage.IsVisible(), "");
        }
        [TestMethod]
        public void OncClickOfLogOffButtonShouldShowRegisterAndLoginButtonAgain()
        {
            _app.HomePage.ClickRegisterButton();
            _app.RegisterPage.EnterEmailId(Guid.NewGuid().ToString() + "@gmail.com");
            _app.RegisterPage.EnterDisplayName("Clarifi");
            _app.RegisterPage.EnterPassword("qwert12345");
            _app.RegisterPage.EnterConfirmPassword("qwert12345");
            _app.RegisterPage.ClickRegister();
            Thread.Sleep(1000);
            _app.HomePage.ClickLogOff();
        }
    }
}