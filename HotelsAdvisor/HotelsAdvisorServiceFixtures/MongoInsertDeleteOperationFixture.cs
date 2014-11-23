//using System;
//using System.Collections.Generic;
//using HotelsAdvisorServiceFixtures.HotelsAdvisorService.Proxy;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using MongoDB.Driver;

//namespace HotelsAdvisorServiceFixtures
//{
//    [TestClass]
//    public class MongoInsertDeleteOperationFixture
//    {
////        //[TestInitialize]
////        //public void DropDocument()
////        //{
////        //    const string connectionString = "mongodb://localhost";
////        //    var client = new MongoClient(connectionString);
////        //    var server = client.GetServer();
////        //    var database = server.GetDatabase("HotelsAdvisor");
////        //    var collection = database.GetCollection<Hotel>("hotelsDetail");

////        //    collection.Drop();
////        //}


//        //[TestMethod]
//        //public void TestForInsertDocumentInMongo()
//        //{
//        //    const string connectionString = "mongodb://localhost";
//        //    var client = new MongoClient(connectionString);
//        //    var server = client.GetServer();
//        //    var database = server.GetDatabase("new_hoteladvisor");
//        //    var collection = database.GetCollection<Hotel>("hoteldetails");

//        //    var imageList = new List<string>
//        //    {
//        //        "http://cache.graphicslib.viator.com/graphicslib/media/68/saint-peters-basilica-photo_7287656-770tall.jpg",
//        //        "http://cache.graphicslib.viator.com/graphicslib/media/3c/vatican-photo_1578556-770tall.jpg",
//        //        "http://cache.graphicslib.viator.com/graphicslib/media/d1/skip-the-line-vatican-museums-walking-tour-including-photo_1344721-770tall.jpg"
//        //    };
//        //    var hotel = new HotelsAdvisorServiceFixtures.Hotel
//        //    {
//        //        Name = "Courtyard Marriot by JW",
//        //        StateCode = "MH",
//        //        City = "Pune",
//        //        Country = "India",
//        //        Address = "Kalyaninagar",
//        //        Rating = 4,
//        //        Latitude = 18.520430300000000000,
//        //        Longitude = 73.856743699999920000,
//        //        UtcTimeSubmitted = DateTime.UtcNow,
//        //        ImageList = imageList
//        //    };


//        //    collection.Insert(hotel);
//        //    var reviewOne = new Review
//        //    {
//        //        HotelId = hotel.Id.ToString(),
//        //        Title = "Excellent Hotel",
//        //        Description = "It was a very short stay at Hyatt during the month of August, only for 12 hours so I was not able to use entire hotel facilities (viz, restaurant, pool)My experience in Hyatt was awesome. Check-in took mere 5 min and a hotel staff accompanied us to our room. He was very friendly and helped us to get familiar with all the facilities provided.Room ambience was very soothing with all the required facilities available. There is no specific view from the room so looking outside from the room is of no use :). Room is bit small.Restaurant is good.Checkout was also very smooth, just handover the keys and walk out of the hotel.",
//        //        UserName = "Siddharth Bhola",
//        //        UtcTimeSubmitted = DateTime.UtcNow,
//        //        Rating = 4,
//        //        Value = 4,
//        //        Rooms = 5,
//        //        Cleanliness = 3,
//        //        Service = 2,
//        //        Location = 3
//        //    };

//        //    var reviewTwo = new Review
//        //    {
//        //        HotelId = hotel.Id.ToString(),
//        //        Title = "OK OK  Hotel",
//        //        Description = "Best staff ever! I've traveled a lot and this is my favorite hotel in the world. The staff is unbeatable, all are personable and most speak excellent English. The outdoor pool is large and beautiful good for \"real\" swimmers as well as those who just want to hang out. The gym is not huge and doesn't have tons of machines but the ones they have are very good. Location could be more central but since this hotel is a real oasis, I feel the trips in and out of Pune to the Camp area and elsewhere are justified.",
//        //        UserName = "yoyo honey singh",
//        //        UtcTimeSubmitted = DateTime.UtcNow,
//        //        Rating = 3,
//        //        Value = 3,
//        //        Rooms = 4,
//        //        Cleanliness = 5,
//        //        Service = 4,
//        //        Location = 2
//        //    };

//        //    var collectionReview = database.GetCollection<Review>("reviews");
//        //    collectionReview.Insert(reviewOne);
//        //    collectionReview.Insert(reviewTwo);
//        //    // var id = hotel.Id;
//        //    // Assert.AreEqual(2, collection.Count());
//        //}

////        [TestMethod]
////        public void TestForDeleteDocumentInMongo()
////        {
////            throw new NotImplementedException();
////        }

//    }
//}
