﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nest;
using System.Collections.Generic;
using ElasticSearch;

namespace ElasticSearchFixtures
{
    [TestClass]
    public class FetchDestinationFixture
    {
        [TestInitialize]
        public void Initialize()
        {
            Uri localhost = new Uri("http://lab22:9200");
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

        //[TestMethod]
        //public void TestSearchByPrefixQuery()
        //{
        //    Uri localhost = new Uri("http://localhost:9200");
        //    var Elasticsetting = new ConnectionSettings(localhost, defaultIndex: "hotels-app");
        //    var Elasticclient = new ElasticClient(Elasticsetting);

        //    var prefixSearchResult = Elasticclient.Search<Destination>(s => s
        //        .Type("destination")
        //        .Query(p => p
        //            .Prefix(m => m
        //                .OnField(c => c.State)
        //                .Value("maha"))));

        //    List<Destination> results = new List<Destination>();

        //    foreach (var element in prefixSearchResult.Documents)
        //    {
        //        results.Add(element);
        //    }
        //    Assert.AreNotEqual(0, prefixSearchResult.Total);
        //    Assert.IsTrue(prefixSearchResult.IsValid);

        //    foreach (var destination in results)
        //    {
        //        Assert.AreNotEqual("maharashtra", destination.State);
        //    }
        //}

        [TestMethod]
        public void TestShouldReturnListOfDestinationsForCorrectCompleteTerm()
        {
            string term = "Pune";
            var elasticSearchObj = new ElasticSearch.ElasticSearch();
            var resultSet = elasticSearchObj.FetchDestinations(term);

            Assert.AreEqual("MH", resultSet[0].State);
            Assert.AreEqual("IN", resultSet[0].Country);
        }

        [TestMethod]
        public void TestShouldReturnListOfDestinationsForCorrectOneLetterTerm()
        {
            string term = "PUNE";
            var elasticSearchObj = new ElasticSearch.ElasticSearch();
            var resultSet = elasticSearchObj.FetchDestinations(term);

            Assert.AreEqual("MH", resultSet[0].State);
            Assert.AreEqual("IN", resultSet[0].Country);
        }

        //[TestMethod]
        //public void TestShouldReturnListOfDestinationsForCorrectTwoLetterTerm()
        //{
        //    string term = "Lu";
        //    var elasticSearchObj = new ElasticSearch.ElasticSearch();
        //    var resultSet = elasticSearchObj.FetchDestinations(term);

        //    Assert.AreEqual("Uttar Pradesh", resultSet[0].State);
        //    Assert.AreEqual("India", resultSet[0].Country);
        //}

        [TestMethod]
        public void TestReturnEmptyListIfNoDestinationsFound()
        {
            string term = "yoyo";
            var elasticSearchObj = new ElasticSearch.ElasticSearch();
            var resultSet = elasticSearchObj.FetchDestinations(term);

            Assert.AreEqual(0,resultSet.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestThrowIfTermIsNull()
        {
            string term = null;
            var elasticSearchObj = new ElasticSearch.ElasticSearch();
            var resultSet = elasticSearchObj.FetchDestinations(term);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestThrowIfTermIsEmptyString()
        {
            string term = "";
            var elasticSearchObj = new ElasticSearch.ElasticSearch();
            var resultSet = elasticSearchObj.FetchDestinations(term);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThrowIfTermIsInvalidCharacter()
        {
            string term = "@#$%*";
            var elasticSearchObj = new ElasticSearch.ElasticSearch();
            var resultSet = elasticSearchObj.FetchDestinations(term);
        }

    }
}
