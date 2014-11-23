//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Nest;
//using System.Collections.Generic;

//namespace ElasticSearchFixtures
//{
//    [TestClass]
//    public class BasicElasticSearchOperations
//    {
//        [TestMethod]
//        public void TestCreateElasticSearchIndexes()
//        {
//            Uri localhost = new Uri("http://localhost:9200");
//            var Elasticsetting = new ConnectionSettings(localhost, defaultIndex: "hotels-app");
//            var Elasticclient = new ElasticClient(Elasticsetting);

//            var destination1 = new Destination
//            {
//                City = "Pune",
//                Country = "India",
//                State = "Maharashtra",
//                Latitude = 18.343,
//                Longitude = 12.232
//            };

//            var destination2 = new Destination
//            {
//                City = "Mumbai",
//                Country = "India",
//                State = "Maharashtra",
//                Latitude = 18.45,
//                Longitude = 12.879
//            };
//            var destination3 = new Destination
//            {
//                City = "Delhi",
//                Country = "India",
//                State = "Delhi",
//                Latitude = 14.343,
//                Longitude = 16.232
//            };
//            var destination4 = new Destination
//            {
//                City = "Chandigarh",
//                Country = "India",
//                State = "Punjab",
//                Latitude = 15.343,
//                Longitude = 16.232
//            };
//            var destination5 = new Destination
//            {
//                City = "Lucknow",
//                Country = "India",
//                State = "Uttar Pradesh",
//                Latitude = 22.343,
//                Longitude = 23.232
//            };

//            //Elasticclient.Index(destination1);
//            //Elasticclient.Index(destination2);
//            //Elasticclient.Index(destination3);
//            //Elasticclient.Index(destination4);
//            //Elasticclient.Index(destination5);

//            var count = Elasticclient.Count().Count;
//            Assert.AreEqual(5, count);


//            //var searchResult1 = Elasticclient.Search<Hotel>(s => s.From(0).
//            //   Size(1).Query(q => q.Match(m => m.OnField(h => h.Name).Query("Hyatt"))));
//        }

//        [TestMethod]
//        public void TestDeleteAllElasticSearchIndexes()
//        {
//            Uri localhost = new Uri("http://localhost:9200");
//            var Elasticsetting = new ConnectionSettings(localhost, defaultIndex: "hotels-app");
//            var Elasticclient = new ElasticClient(Elasticsetting);            


//            Elasticclient.DeleteByQuery<Destination>(q => q
//               .Type("destination")
//               .Query(e => e.Match(m => m.OnField(d => d.City).Query("Pune"))));

//            Elasticclient.DeleteByQuery<Destination>(q => q
//              .Type("destination")
//              .Query(e => e.Match(m => m.OnField(d => d.City).Query("Delhi"))));

//            Elasticclient.DeleteByQuery<Destination>(q => q
//              .Type("destination")
//              .Query(e => e.Match(m => m.OnField(d => d.City).Query("Chandigarh"))));

//            Elasticclient.DeleteByQuery<Destination>(q => q
//              .Type("destination")
//              .Query(e => e.Match(m => m.OnField(d => d.City).Query("Lucknow"))));

//            Elasticclient.DeleteByQuery<Destination>(q => q
//              .Type("destination")
//              .Query(e => e.Match(m => m.OnField(d => d.City).Query("Mumbai"))));


//            var count = Elasticclient.Count().Count;
//            Assert.AreEqual(0, count);

//        }

//        [TestMethod]
//        public void TestSearchQueryShouldReturnMatchDocument()
//        {
//            Uri localhost = new Uri("http://localhost:9200");
//            var Elasticsetting = new ConnectionSettings(localhost, defaultIndex: "hotels-app");
//            var Elasticclient = new ElasticClient(Elasticsetting);

//            var searchResult1 = Elasticclient.Search<Destination>(s => s
//                .From(0)
//                .Size(1)
//                .Type("destination")
//                .Query(q => q
//                    .Match(m => m.OnField(h => h.City)
//                        .Query("Pune"))));

//            Assert.AreEqual(1, searchResult1.Total);
//        }

//        [TestMethod]
//        public void TestSearchByPrefixQuery()
//        {
//            Uri localhost = new Uri("http://localhost:9200");
//            var Elasticsetting = new ConnectionSettings(localhost, defaultIndex: "hotels-app");
//            var Elasticclient = new ElasticClient(Elasticsetting);

//            var prefixSearchResult = Elasticclient.Search<Destination>(s => s
//                .Type("destination")
//                .Query(p => p
//                    .Prefix(m => m
//                        .OnField(c => c.State)
//                        .Value("maha"))));

//            List<Destination> results = new List<Destination>();

//            foreach (var element in prefixSearchResult.Documents)
//            {
//                results.Add(element);
//            }
//            Assert.AreNotEqual(0, prefixSearchResult.Total);
//            Assert.IsTrue(prefixSearchResult.IsValid);

//            foreach (var destination in results)
//            {
//                Assert.AreNotEqual("maharashtra", destination.State);
//            }

//        }
//    }
//}
