
﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using HotelsAdvisorServiceFixtures.HotelsAdvisorService.Proxy;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Collections.Generic;

namespace HotelsAdvisorServiceFixtures
{
    [TestClass]
    public class DeleteReviewFixture
    {
        private string _hotelId;
        private string _reviewId;

        [TestInitialize]
        public void Initialize()
        {
            var connectionString = "mongodb://lab22";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("hotels");
            var hotelCollection = database.GetCollection<Hotel>("hotel");
            var reviewCollection = database.GetCollection<Review>("review");

            hotelCollection.Drop();
            reviewCollection.Drop();


            //var reviewListForHotel1 = new List<Review>();
            //reviewListForHotel1.Add(review1);
            //reviewListForHotel1.Add(review2);

            var imageList = new List<string>();
            imageList.Add("http://cache.graphicslib.viator.com/graphicslib/media/68/saint-peters-basilica-photo_7287656-770tall.jpg");
            imageList.Add("http://cache.graphicslib.viator.com/graphicslib/media/3c/vatican-photo_1578556-770tall.jpg");
            imageList.Add("http://cache.graphicslib.viator.com/graphicslib/media/d1/skip-the-line-vatican-museums-walking-tour-including-photo_1344721-770tall.jpg");
            imageList.Add("http://media.expedia.com/hotels/5000000/4930000/4921200/4921155/4921155_25_y.jpg");
            imageList.Add("http://media.expedia.com/hotels/5000000/4910000/4905100/4905068/4905068_38_y.jpg");
            imageList.Add("http://media.expedia.com/hotels/5000000/4910000/4905100/4905068/4905068_42_y.jpg");
            imageList.Add("http://media.expedia.com/hotels/5000000/4910000/4905100/4905068/4905068_33_y.jpg");
            imageList.Add("http://media.expedia.com/hotels/5000000/4910000/4905100/4905068/4905068_28_y.jpg");
            imageList.Add("http://media.expedia.com/hotels/5000000/4910000/4905100/4905068/4905068_12_y.jpg");
            imageList.Add("http://media.expedia.com/hotels/5000000/4930000/4921200/4921122/4921122_96_y.jpg");
            imageList.Add("http://media.expedia.com/hotels/5000000/4930000/4921200/4921122/4921122_96_y.jpg");
            imageList.Add("http://media.expedia.com/hotels/5000000/4910000/4905100/4905068/4905068_49_y.jpg");
            imageList.Add("http://media.expedia.com/hotels/5000000/4930000/4921200/4921122/4921122_81_y.jpg");
            imageList.Add("http://media.expedia.com/hotels/5000000/4930000/4921200/4921122/4921122_79_y.jpg");
            imageList.Add("http://media.expedia.com/hotels/5000000/4930000/4921200/4921122/4921122_88_y.jpg");
            imageList.Add("http://media.expedia.com/hotels/5000000/4930000/4921200/4921122/4921122_92_y.jpg");
            imageList.Add("http://media.expedia.com/hotels/5000000/4930000/4921200/4921122/4921122_4_y.jpg");
            imageList.Add("http://media.expedia.com/hotels/5000000/4930000/4921200/4921122/4921122_28_y.jpg");

            var hotel1 = new HotelAdvisor.BLL.Model.Hotel
            {
                Name = "Courtyard Marriot by JW",
                //Reviews = reviewListForHotel1,
                StateCode = "MH",
                City = "Pune",
                Country = "India",
                Address = "Kalyaninagar",
                Rating = 4,
                Latitude = 18.520430300000000000,
                Longitude = 73.856743699999920000,
                UtcTimeSubmitted = DateTime.UtcNow,
                ImageList = imageList
            };

            hotelCollection.Insert(hotel1);
            _hotelId = hotel1.Id.ToString();

            var review1 = new HotelAdvisor.BLL.Model.Review
            {
                HotelId = _hotelId,
                //ReviewId = 1,
                Title = "Excellent Hotel",
                Description = "It was a very short stay at Hyatt during the month of August, only for 12 hours so I was not able to use entire hotel facilities (viz, restaurant, pool)My experience in Hyatt was awesome. Check-in took mere 5 min and a hotel staff accompanied us to our room. He was very friendly and helped us to get familiar with all the facilities provided.Room ambience was very soothing with all the required facilities available. There is no specific view from the room so looking outside from the room is of no use :). Room is bit small.Restaurant is good.Checkout was also very smooth, just handover the keys and walk out of the hotel.",
                UserName = "Siddharth Bhola",
                UtcTimeSubmitted = DateTime.UtcNow,
                Rating = 4,
                Value = 4,
                Rooms = 5,
                Cleanliness = 3,
                Service = 2,
                Location = 3
            };

            var review2 = new HotelAdvisor.BLL.Model.Review
            {
                HotelId = _hotelId,
                // ReviewId = 2,
                Title = "OK OK  Hotel",
                Description = "Best staff ever! I've traveled a lot and this is my favorite hotel in the world. The staff is unbeatable, all are personable and most speak excellent English. The outdoor pool is large and beautiful good for \"real\" swimmers as well as those who just want to hang out. The gym is not huge and doesn't have tons of machines but the ones they have are very good. Location could be more central but since this hotel is a real oasis, I feel the trips in and out of Pune to the Camp area and elsewhere are justified.",
                UserName = "yoyo honey singh",
                UtcTimeSubmitted = DateTime.UtcNow,
                Rating = 3,
                Value = 3,
                Rooms = 4,
                Cleanliness = 5,
                Service = 4,
                Location = 2
            };

            reviewCollection.Insert(review1);
            _reviewId = review1.Id.ToString();

            reviewCollection.Insert(review2);
        }

        [TestMethod]
        public void TestDeleteShouldReturnTrueForGivenValidHotelIdAndReviewId()
        {
            using (var client = new HotelsAdvisorClient())
            {
                //var hotelId = "543e131ed7e31a090098d6c8";
                //var reviewId = "1";

                var result = client.DeleteReview(_reviewId);

                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void TestThrowForNullReviewId()
        {
            using (var client = new HotelsAdvisorClient())
            {
                const string reviewId = "";
                try
                {
                    var result = client.DeleteReview(reviewId);
                }
                catch (FaultException<ParameterNullException> ex)
                {
                    Assert.AreEqual(202, ex.Detail.FaultId);
                }
            }
        }
    }
}
