using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
using Nest;
using System.Collections.Generic;


namespace HotelsAdvisorServiceFixtures
{
    [TestClass]
    public class BuildMongoAndElasticDB
    {
        [TestMethod]
        public void CreateMongoDbAndElasticDb()
        {
            //MONGODB SETTINGS
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("hotels");
            var hotelCollection = database.GetCollection<Hotel>("hotel");
            var reviewCollection = database.GetCollection<Review>("review");

            //ELASTIC SETTINGS
            Uri localhost = new Uri("http://localhost:9200");
            var Elasticsetting = new ConnectionSettings(localhost, defaultIndex: "hotels-app");
            var Elasticclient = new ElasticClient(Elasticsetting);

            //clear mongodb
            hotelCollection.Drop();
            reviewCollection.Drop();

            //clear elasticsearch db
            Elasticclient.DeleteByQuery<Hotel>(q => q
              .Type("hotel")
              .Query(e => e.Match(m => m.OnField(d => d.Name).Query("Hyatt"))));

            Elasticclient.DeleteByQuery<Hotel>(q => q
               .Type("hotel")
               .Query(e => e.Match(m => m.OnField(d => d.Name).Query("Taj Trident"))));

            Elasticclient.DeleteByQuery<Hotel>(q => q
               .Type("hotel")
               .Query(e => e.Match(m => m.OnField(d => d.Name).Query("Lemon Tree"))));


            Elasticclient.DeleteByQuery<Hotel>(q => q
               .Type("hotel")
               .Query(e => e.Match(m => m.OnField(d => d.Name).Query("Oakwood Premier"))));

            Elasticclient.DeleteByQuery<Hotel>(q => q
               .Type("hotel")
               .Query(e => e.Match(m => m.OnField(d => d.Name).Query("Marriot"))));

            Elasticclient.DeleteByQuery<Hotel>(q => q
               .Type("hotel")
               .Query(e => e.Match(m => m.OnField(d => d.Name).Query("The Westin Pune Koregaon Park"))));
           

            //create data for mongodb 
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


            var mongoHotel1 = new HotelAdvisor.BLL.Model.Hotel
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

            var mongoHotel2 = new HotelAdvisor.BLL.Model.Hotel
            {
                Name = "Hyatt Regency",
                //Reviews = reviewListForHotel1,
                StateCode = "MH",
                City = "Pune",
                Country = "India",
                Address = "Kalyaninagar",
                Rating = 3,
                Latitude = 18.520430300000000000,
                Longitude = 73.856743699999920000,
                UtcTimeSubmitted = DateTime.UtcNow,
                ImageList = imageList
            };

            var mongoHotel3 = new HotelAdvisor.BLL.Model.Hotel
            {
                Name = "Taj Trident",
                //Reviews = reviewListForHotel1,
                StateCode = "MH",
                City = "Delhi",
                Country = "India",
                Address = "Kalyaninagar",
                Rating = 3,
                Latitude = 17.5204303002600000,
                Longitude = 93.856743699999920000,
                UtcTimeSubmitted = DateTime.UtcNow,
                ImageList = imageList
            };

            var mongoHotel4 = new HotelAdvisor.BLL.Model.Hotel
            {
                Name = "Oakwood Premier",
                //Reviews = reviewListForHotel1,
                StateCode = "MH",
                City = "Chandigarh",
                Country = "India",
                Address = "Kalyaninagar",
                Rating = 5,
                Latitude = 17.5204303002600000,
                Longitude = 93.856743699999920000,
                UtcTimeSubmitted = DateTime.UtcNow,
                ImageList = imageList
            };
            var mongoHotel5 = new HotelAdvisor.BLL.Model.Hotel
            {
                Name = "The Westin Pune Koregaon Park",
                //Reviews = reviewListForHotel1,
                StateCode = "MH",
                City = "Pune",
                Country = "India",
                Address = "Koregaon Park",
                Rating = 5,
                Latitude = 17.5204303002600000,
                Longitude = 93.856743699999920000,
                UtcTimeSubmitted = DateTime.UtcNow,
                ImageList = imageList
            };


            //insert into mongodb - hotel collection
            hotelCollection.Insert(mongoHotel1);
            hotelCollection.Insert(mongoHotel2);
            hotelCollection.Insert(mongoHotel3);
            hotelCollection.Insert(mongoHotel4);
            hotelCollection.Insert(mongoHotel5);

            var review1 = new HotelAdvisor.BLL.Model.Review
            {
                HotelId = mongoHotel1.Id.ToString(),
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
                HotelId = mongoHotel1.Id.ToString(),
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

            var review3 = new HotelAdvisor.BLL.Model.Review
            {
                HotelId = mongoHotel2.Id.ToString(),
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

            var review4 = new HotelAdvisor.BLL.Model.Review
            {
                HotelId = mongoHotel2.Id.ToString(),
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

            var review5 = new HotelAdvisor.BLL.Model.Review
            {
                HotelId = mongoHotel3.Id.ToString(),
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

            var review6 = new HotelAdvisor.BLL.Model.Review
            {
                HotelId = mongoHotel3.Id.ToString(),
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

            var review7 = new HotelAdvisor.BLL.Model.Review
            {
                HotelId = mongoHotel4.Id.ToString(),
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
            var review8 = new HotelAdvisor.BLL.Model.Review
            {
                HotelId = mongoHotel4.Id.ToString(),
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
            var review9 = new HotelAdvisor.BLL.Model.Review
            {
                HotelId = mongoHotel5.Id.ToString(),
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
            var review10 = new HotelAdvisor.BLL.Model.Review
            {
                HotelId = mongoHotel5.Id.ToString(),
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

            //insert into mongodb - review collection
            reviewCollection.Insert(review1);
            reviewCollection.Insert(review2);
            reviewCollection.Insert(review3);
            reviewCollection.Insert(review4);
            reviewCollection.Insert(review5);
            reviewCollection.Insert(review6);
            reviewCollection.Insert(review7);
            reviewCollection.Insert(review8);
            reviewCollection.Insert(review9);
            reviewCollection.Insert(review10);

            //create elasticsearch data objects
            var elasticHotel1 = new ElasticHotel
            {
                Name = "Marriot",
                City = "Pune",
                Country = "India",
                Id = mongoHotel1.Id.ToString(),
                Latitude = 18.98,
                Longitude = 17.11
            };

            var elasticHotel2 = new ElasticHotel
            {
                Name = "Hyatt",
                City = "Pune",
                Country = "India",
                Id = mongoHotel2.Id.ToString(),
                Latitude = 12.98,
                Longitude = 11.11
            };

            var elasticHotel3 = new ElasticHotel
            {
                Name = "Taj Trident",
                City = "Delhi",
                Country = "India",
                Id = mongoHotel3.Id.ToString(),
                Latitude = 12.98,
                Longitude = 11.11
            };

            var elasticHotel4 = new ElasticHotel
            {
                Name = "Oakwood Premier",
                City = "Chandigarh",
                Country = "India",
                Id = mongoHotel4.Id.ToString(),
                Latitude = 12.98,
                Longitude = 11.11
            };
            var elasticHotel5 = new ElasticHotel
            {
                Name = "The Westin Pune Koregaon Park",
                City = "Pune",
                Country = "India",
                Id = mongoHotel5.Id.ToString(),
                Latitude = 12.98,
                Longitude = 11.11
            };

            //insert into elastic db
            Elasticclient.Index(elasticHotel1);
            Elasticclient.Index(elasticHotel2);
            Elasticclient.Index(elasticHotel3);
            Elasticclient.Index(elasticHotel4);
            Elasticclient.Index(elasticHotel5);

        }

        [TestMethod]
        public void CreateDestinationsDbInElasticSearch()
        {
            Uri localhost = new Uri("http://localhost:9200");
            var Elasticsetting = new ConnectionSettings(localhost, defaultIndex: "destinations-app");
            var Elasticclient = new ElasticClient(Elasticsetting);


            Elasticclient.DeleteByQuery<Destination>(q => q
               .Type("destination")
               .Query(e => e.Match(m => m.OnField(d => d.City).Query("Pune"))));

            Elasticclient.DeleteByQuery<Destination>(q => q
              .Type("destination")
              .Query(e => e.Match(m => m.OnField(d => d.City).Query("Delhi"))));

            Elasticclient.DeleteByQuery<Destination>(q => q
              .Type("destination")
              .Query(e => e.Match(m => m.OnField(d => d.City).Query("Chandigarh"))));

            Elasticclient.DeleteByQuery<Destination>(q => q
              .Type("destination")
              .Query(e => e.Match(m => m.OnField(d => d.City).Query("Lucknow"))));

            Elasticclient.DeleteByQuery<Destination>(q => q
              .Type("destination")
              .Query(e => e.Match(m => m.OnField(d => d.City).Query("Mumbai"))));

            var destination1 = new Destination
            {
                City = "Pune",
                Country = "India",
                State = "Maharashtra",
                Latitude = 18.343,
                Longitude = 12.232
            };

            var destination2 = new Destination
            {
                City = "Mumbai",
                Country = "India",
                State = "Maharashtra",
                Latitude = 18.45,
                Longitude = 12.879
            };
            var destination3 = new Destination
            {
                City = "Delhi",
                Country = "India",
                State = "Delhi",
                Latitude = 14.343,
                Longitude = 16.232
            };
            var destination4 = new Destination
            {
                City = "Chandigarh",
                Country = "India",
                State = "Punjab",
                Latitude = 15.343,
                Longitude = 16.232
            };
            var destination5 = new Destination
            {
                City = "Lucknow",
                Country = "India",
                State = "Uttar Pradesh",
                Latitude = 22.343,
                Longitude = 23.232
            };

            Elasticclient.Index(destination1);
            Elasticclient.Index(destination2);
            Elasticclient.Index(destination3);
            Elasticclient.Index(destination4);
            Elasticclient.Index(destination5);
            System.Threading.Thread.Sleep(1000);
        }

    }
}
