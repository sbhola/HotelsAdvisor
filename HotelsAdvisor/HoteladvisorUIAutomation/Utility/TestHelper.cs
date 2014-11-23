using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HoteladvisorUIAutomation.Application;
using HoteladvisorUIAutomation.Configuration;

namespace HoteladvisorUIAutomation.Utility
{
    [TestClass]
    public class TestHelper
    {
        public static HotelsAdvisorApp HotelsApp { get; set; }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            //App = new RoviaApp();
            //App.Launch(ApplicationSettings.Url);
            HotelsApp = new HotelsAdvisorApp();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
           // App.Dispose();
            HotelsApp.Dispose();
        }

        public static void HomePageInitialize()
        {
            HotelsApp.Launch(ApplicationSettings.HomePageUrl);
            Assert.IsTrue(HotelsApp.HomePage.IsVisible(), "could not load home page");
        }
        /// <summary>
        /// Initialize/Load the Login page
        /// </summary>
        public static void LoginPageInitialize()
        {
            HotelsApp.Launch(ApplicationSettings.LoginUrl);
            Assert.IsTrue(HotelsApp.LoginPage.IsVisible(),"could not load login page");
        }

        /// <summary>
        /// Initialize/Load the Details page
        /// </summary>
        public static void DetailsPageInitialize()
        {
            HotelsApp.Launch(ApplicationSettings.DetailsUrl);
            Assert.IsTrue(HotelsApp.DetailsPage.IsVisible(),"could not load details page");
        }

        public static void IndexPageInitialize()
        {
            HotelsApp.Launch(ApplicationSettings.Url);
            Thread.Sleep(500);
            Assert.IsTrue(HotelsApp.HomePage.IsVisible());
        }


    }

}

