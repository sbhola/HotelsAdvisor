﻿using HoteladvisorUIAutomation.Application;
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
    public class RegisterPageTests
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
            Assert.IsTrue(_app.HomePage.IsVisible(), "Could not Load Home Page!");
            _app.HomePage.ClickRegisterButton();
            Assert.IsTrue(_app.RegisterPage.IsVisible(), "could not load Register page!");
            Thread.Sleep(500);
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void ShouldNotAcceptInvaliEmailId()
        {
            _app.HomePage.ClickRegisterButton();
            _app.RegisterPage.EnterEmailId("@gmail.com");
            _app.RegisterPage.EnterDisplayName("Clarifi");
            _app.RegisterPage.EnterPassword("qwert12345");
            _app.RegisterPage.EnterConfirmPassword("qwert12345");
            _app.RegisterPage.ClickRegister();
            Thread.Sleep(1000);
            //Get error message displayed and check for login error
            Assert.IsTrue(_app.RegisterPage.IsValidationMessageDisplayedForInvalidEmailId(), "Incorrect validation for EmailId");
        }
        [TestMethod]
        public void ConfirmPasswordDifferent()
        {

            _app.RegisterPage.EnterEmailId(Guid.NewGuid().ToString() + "@gmail.com");
            _app.RegisterPage.EnterDisplayName("Clarifi");
            _app.RegisterPage.EnterPassword("qwert12345");
            _app.RegisterPage.EnterConfirmPassword("qwert1234");
            _app.RegisterPage.ClickRegister();
            Assert.IsTrue(_app.RegisterPage.
                IsValidationMessageDisplayedForDifferentConfirmPassword(),
                "No check for password and confirm password to be same");
        }
        [TestMethod]
        public void ShouldNotAcceptInvalidPassword()
        {
            _app.RegisterPage.EnterEmailId(Guid.NewGuid().ToString() + "@gmail.com");
            _app.RegisterPage.EnterDisplayName("Clarifi");
            _app.RegisterPage.EnterPassword("qwert");
            _app.RegisterPage.EnterConfirmPassword("qwert");
            _app.RegisterPage.ClickRegister();
            Thread.Sleep(1000);
            Assert.IsTrue(_app.RegisterPage.IsValidationMessageDisplayedForInvalidPassword(),
                "No Check for invalid password");
        }
        [TestMethod]
        public void ShouldAcceptValidCredentials()
        {
            _app.RegisterPage.EnterEmailId(Guid.NewGuid().ToString() + "@gmail.com");
            _app.RegisterPage.EnterDisplayName("Clarifi");
            _app.RegisterPage.EnterPassword("qwert12345");
            _app.RegisterPage.EnterConfirmPassword("qwert12345");
            _app.RegisterPage.ClickRegister();
            Thread.Sleep(1000);
            Assert.IsTrue(_app.HomePage.IsVisible(), "incorrect redirection of page on successful registration");
            _app.HomePage.ClickLogOff();
        }
        [TestMethod]
        public void shouldNotAcceptEmptyDisplayName()
        {
            _app.RegisterPage.EnterEmailId(Guid.NewGuid().ToString() + "@gmail.com");
            _app.RegisterPage.EnterPassword("qwert12345");
            _app.RegisterPage.EnterConfirmPassword("qwert12345");
            _app.RegisterPage.ClickRegister();
            Thread.Sleep(1000);
            Assert.IsTrue(_app.RegisterPage.IsValidationMessageDisplayedForEmptyDisplayName(), "no check for empty display name");
        }
        [TestMethod]
        public void ShouldNotAccceptEmptyEmailId()
        {
            _app.RegisterPage.EnterDisplayName("Clarifi");
            _app.RegisterPage.EnterPassword("qwert12345");
            _app.RegisterPage.EnterConfirmPassword("qwert12345");
            _app.RegisterPage.ClickRegister();
            Assert.IsTrue(_app.RegisterPage.IsValidationMessageDisplayedForEmptyEmaiId(), "no check for empty email id");
        }
        [TestMethod]
        public void ShouldNotAcceptEmptyPassword()
        {
            _app.RegisterPage.EnterEmailId(Guid.NewGuid().ToString() + "@gmail.com");
            _app.RegisterPage.EnterDisplayName("Clarifi");
            _app.RegisterPage.ClickRegister();
            Thread.Sleep(1000);
            Assert.IsTrue(_app.RegisterPage.IsValidationMessageDisplayedForEmptyPassword(), "no check for empty password");
        }
        [TestMethod]
        public void ShouldRedirectToHomePageWhenClickedOnHeader()
        {
            _app.RegisterPage.ClickHeaderOfRegisterPage();
            Thread.Sleep(1000);
            Assert.IsTrue(_app.HomePage.IsVisible(), "no redirection given to the homepage on click of header");
        }
    }
}