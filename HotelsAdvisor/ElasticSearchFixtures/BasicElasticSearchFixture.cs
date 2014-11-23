using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Nest;

namespace ElasticSearchFixtures
{
    [TestClass]
    public class BasicElasticSearchFixture
    {
        [TestMethod]
        public void TestForCreatingElasticSearchIndex()
        {
            var node = new Uri("http://localhost:9200");

            var settings = new ConnectionSettings(
                node,
                defaultIndex: "hotel-advisor-new"
            );

            var client = new ElasticClient(settings);


            //          var destinationOne = new HotelsAdvisorServiceFixtures.Destination
            //              {
            //                  City = "pune",
            //                  Country = "India",
            //                  State = "Maharashtra",
            //                  Latitude = 18.520430300000000000,
            //                  Longitude = 73.856743699999920000
            //              };

            //          var destinationTwo = new HotelsAdvisorServiceFixtures.Destination
            //          {
            //              City = "surat",
            //              Country = "India",
            //              State = "Gujrat",
            //              Latitude = 18.520430300000000000,
            //              Longitude = 73.856743699999920000
            //          };

            //          var destinationThree = new HotelsAdvisorServiceFixtures.Destination
            //          {
            //              City = "baroda",
            //              Country = "India",
            //              State = "Gujrat",
            //              Latitude = 18.520430300000000000,
            //              Longitude = 73.856743699999920000
            //          };

            //          var destinationFour = new HotelsAdvisorServiceFixtures.Destination
            //          {
            //              City = "mumbai",
            //              Country = "India",
            //              State = "Maharashtra",
            //              Latitude = 18.520430300000000000,
            //              Longitude = 73.856743699999920000
            //          };

            //          var destinationFive = new HotelsAdvisorServiceFixtures.Destination
            //          {
            //              City = "nagpur",
            //              Country = "India",
            //              State = "Maharashtra",
            //              Latitude = 18.520430300000000000,
            //              Longitude = 73.856743699999920000
            //          };

            //          var destinationSix = new HotelsAdvisorServiceFixtures.Destination
            //          {
            //              City = "nashik",
            //              Country = "India",
            //              State = "Maharashtra",
            //              Latitude = 18.520430300000000000,
            //              Longitude = 73.856743699999920000
            //          };

            //          var destinationSeven = new HotelsAdvisorServiceFixtures.Destination
            //          {
            //              City = "solapur",
            //              Country = "India",
            //              State = "Maharashtra",
            //              Latitude = 18.520430300000000000,
            //              Longitude = 73.856743699999920000
            //          };


            //          client.Index(destinationOne, i => i
            //              .Index("hotel-advisor-new")
            //              .Type("destination")
            //              .Refresh()
            //              .Ttl("1m")
            //          );



            //          client.Index(destinationTwo, i => i
            //     .Index("hotel-advisor-new")
            //     .Type("destination")
            //     .Refresh()
            //     .Ttl("1m")
            //     );


            //          client.Index(destinationThree, i => i
            //.Index("hotel-advisor-new")
            //.Type("destination")
            //.Refresh()
            //.Ttl("1m")
            //);

            //          client.Index(destinationFour, i => i
            //.Index("hotel-advisor-new")
            //.Type("destination")
            //.Refresh()
            //.Ttl("1m")
            //);

            //          client.Index(destinationFive, i => i
            //.Index("hotel-advisor-new")
            //.Type("destination")
            //.Refresh()
            //.Ttl("1m")
            //);

            //          client.Index(destinationSix, i => i
            //.Index("hotel-advisor-new")
            //.Type("destination")
            //.Refresh()
            //.Ttl("1m")
            //);

            //          client.Index(destinationSeven, i => i
            //.Index("hotel-advisor-new")
            //.Type("destination")
            //.Refresh()
            //.Ttl("1m")
            //);

            var searchResults = client.Search<Destination>(s => s
       .Indices("hotel-advisor-new")
       );

            Assert.AreEqual(7, searchResults.Total);
        }

        [TestMethod]
        public void TestForDeleteIndex()
        {
            var node = new Uri("http://localhost:9200");

            var settings = new ConnectionSettings(
                node,
                defaultIndex: "hotel-advisor-new"
            );

            var client = new ElasticClient(settings);

            client.DeleteByQuery<Destination>(q => q
           .Type("destination")
           .Query(e => e.Match(m => m.OnField(d => d.City).Query("pune"))));

            client.DeleteByQuery<Destination>(q => q
            .Type("destination")
            .Query(e => e.Match(m => m.OnField(d => d.City).Query("surat"))));

            client.DeleteByQuery<Destination>(q => q
            .Type("destination")
            .Query(e => e.Match(m => m.OnField(d => d.City).Query("nashik"))));

            client.DeleteByQuery<Destination>(q => q
            .Type("destination")
            .Query(e => e.Match(m => m.OnField(d => d.City).Query("solapur"))));

            client.DeleteByQuery<Destination>(q => q
            .Type("destination")
            .Query(e => e.Match(m => m.OnField(d => d.City).Query("nagpur"))));

            client.Delete<Destination>("jjOMhhICRtyUq7V_MUCFtQ");

            client.Delete<Destination>("i3OWRDMFSQmxwSEVH3NhnA");
        }


        [TestMethod]
        public void TestForCreatingIndexForElasticHotelDataDirectlyFromMongo()
        {
            const string connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("new_hoteladvisor");
            var reviewCollection = database.GetCollection<HotelAdvisor.BLL.Model.Hotel>("hoteldetails");
            var hotels = reviewCollection.FindAll();
            var list = hotels.Select(hotel => hotel.ToBsonDocument()).Select(BsonSerializer.Deserialize<HotelAdvisor.BLL.Model.Hotel>).ToList();

            Assert.AreEqual(9, list.Count);

            var elasticList = list.Select(hotel => hotel.ToElasticContract()).ToList();

            Assert.AreEqual(9, elasticList.Count);


            var node = new Uri("http://localhost:9200");

            var settings = new ConnectionSettings(
                node,
                defaultIndex: "hotel-advisor-hoteldetails"
            );

            var elasticClient = new ElasticClient(settings);


            //foreach (var hotelElastic in elasticList)
            //{
            //    elasticClient.Index(hotelElastic, i => i
            //                 .Index("hotel-advisor-hoteldetails")
            //                 .Type("hotel")
            //                 .Refresh()
            //                 .Ttl("1m"));
            //}

            var searchResults = elasticClient.Search<HotelElastic>(s => s
                                             .Indices("hotel-advisor-hoteldetails")
                                             .Type("hotel"));

            Assert.AreEqual(9, searchResults.Total);
        }

        [TestMethod]
        public void TestForFetchingIdsFromElasticSearch()
        {
            var node = new Uri("http://localhost:9200");

            var settings = new ConnectionSettings(
                node,
                defaultIndex: "hotel-advisor-hoteldetails"
            );

            var elasticClient = new ElasticClient(settings);
            const string city = "pune";
            const string country = "india";
            var searchResults = elasticClient.Search<HotelElastic>(s => s
                                            .Indices("hotel-advisor-hoteldetails")
                                            .Type("hotel")
                                            .Query(q => q.MultiMatch(m => m.OnFields(f => f.City).Query(city)) && q.Match(m=>m.OnField(f=>f.Country).Query(country))))
                                           ;

            var idList = searchResults.Documents.Select(doc => doc.Id).ToList();
            
            Assert.AreEqual(9,idList.Count);
        }

    }

}
