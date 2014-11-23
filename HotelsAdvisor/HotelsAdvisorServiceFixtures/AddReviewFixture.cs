using System;
using System.ServiceModel;
using HotelsAdvisorServiceFixtures.HotelsAdvisorService.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelsAdvisorServiceFixtures
{
    [TestClass]
    public class AddReviewFixture
    {
        [TestMethod]
        public void TestForAddReviewWhenHotelIdIsNull()
        {
            using (var client = new HotelsAdvisorClient())
            {
                const string id = null;
                var review = new HotelsAdvisorService.Proxy.Review
                    {
                        Title = "Excellent Hotel",
                        Description =
                            "It was a very short stay at Hyatt during the month of August, only for 12 hours so I was not able to use entire hotel facilities (viz, restaurant, pool)My experience in Hyatt was awesome. Check-in took mere 5 min and a hotel staff accompanied us to our room. He was very friendly and helped us to get familiar with all the facilities provided.Room ambience was very soothing with all the required facilities available. There is no specific view from the room so looking outside from the room is of no use :). Room is bit small.Restaurant is good.Checkout was also very smooth, just handover the keys and walk out of the hotel.",
                        UserName = "Saifuddin Batliwala",
                        UtcTimeSubmitted = DateTime.UtcNow,
                        Rating = 4,
                        Value = 4,
                        Rooms = 5,
                        Cleanliness = 3,
                        Service = 2,
                        Location = 3,
                    };
                try
                {
                    client.AddReview(id, review);
                }
                catch (FaultException<CustomFaults> fault)
                {

                    Assert.AreEqual(101, fault.Detail.FaultCode);
                }
            }
        }


        [TestMethod]
        public void TestForAddReviewWhenReviewIsNull()
        {
            using (var client = new HotelsAdvisorClient())
            {
                const string id = "543f4be93c496418e82229b2";
                try
                {
                    client.AddReview(id, null);
                }
                catch (FaultException<CustomFaults> fault)
                {

                    Assert.AreEqual(101, fault.Detail.FaultCode);
                }
            }
        }


        [TestMethod]
        public void TestForAddReviewForAppropriateHotelIdAndReviewShouldRespondCorrect()
        {
            using (var client = new HotelsAdvisorClient())
            {
                const string id = "54449b653c496210940dad09";
                var review = new HotelsAdvisorService.Proxy.Review
                    {
                        Title = "Excellent Hotel",
                        Description =
                            "It was a very short stay at Hyatt during the month of August, only for 12 hours so I was not able to use entire hotel facilities (viz, restaurant, pool)My experience in Hyatt was awesome. Check-in took mere 5 min and a hotel staff accompanied us to our room. He was very friendly and helped us to get familiar with all the facilities provided.Room ambience was very soothing with all the required facilities available. There is no specific view from the room so looking outside from the room is of no use :). Room is bit small.Restaurant is good.Checkout was also very smooth, just handover the keys and walk out of the hotel.",
                        UserName = "Saifuddin Batliwala",
                        UtcTimeSubmitted = DateTime.UtcNow,
                        Rating = 4,
                        Value = 4,
                        Rooms = 5,
                        Cleanliness = 3,
                        Service = 2,
                        Location = 3,
                    };

                var addReviewResult = client.AddReview(id, review);
                Assert.AreEqual(true, addReviewResult);
            }
        }

        [TestMethod]
        public void TestForAddReviewForInappropriateHotelIdShouldThrow()
        {
            using (var client = new HotelsAdvisorClient())
            {
                const string id = "54449b653c496210940dad89";
                var review = new HotelsAdvisorService.Proxy.Review
                    {
                        Title = "Excellent Hotel",
                        Description =
                            "It was a very short stay at Hyatt during the month of August, only for 12 hours so I was not able to use entire hotel facilities (viz, restaurant, pool)My experience in Hyatt was awesome. Check-in took mere 5 min and a hotel staff accompanied us to our room. He was very friendly and helped us to get familiar with all the facilities provided.Room ambience was very soothing with all the required facilities available. There is no specific view from the room so looking outside from the room is of no use :). Room is bit small.Restaurant is good.Checkout was also very smooth, just handover the keys and walk out of the hotel.",
                        UserName = "Saifuddin Batliwala",
                        UtcTimeSubmitted = DateTime.UtcNow,
                        Rating = 4,
                        Value = 4,
                        Rooms = 5,
                        Cleanliness = 3,
                        Service = 2,
                        Location = 3,
                    };
                try
                {
                    client.AddReview(id, review);
                }
                catch (FaultException<CustomFaults> fault)
                {

                    Assert.AreEqual(104, fault.Detail.FaultCode);
                }
            }
        }
    }
}
