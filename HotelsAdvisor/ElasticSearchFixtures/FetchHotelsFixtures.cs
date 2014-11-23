using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nest;
using System.Collections.Generic;

namespace ElasticSearchFixtures
{
    [TestClass]
    public class FetchHotelsFixtures
    {
        [TestInitialize]
        public void Initialize()
        {
            Uri localhost = new Uri("http://lab22:9200");
            var Elasticsetting = new ConnectionSettings(localhost, defaultIndex: "hotels-app");
            var Elasticclient = new ElasticClient(Elasticsetting);


            Elasticclient.DeleteByQuery<ElasticHotel>(q => q
               .Type("hotel")
               .Query(e => e.Match(m => m.OnField(d => d.Name).Query("Hyatt"))));

            Elasticclient.DeleteByQuery<ElasticHotel>(q => q
               .Type("hotel")
               .Query(e => e.Match(m => m.OnField(d => d.Name).Query("Taj Trident"))));

            Elasticclient.DeleteByQuery<ElasticHotel>(q => q
               .Type("hotel")
               .Query(e => e.Match(m => m.OnField(d => d.Name).Query("Lemon Tree"))));


            Elasticclient.DeleteByQuery<ElasticHotel>(q => q
               .Type("hotel")
               .Query(e => e.Match(m => m.OnField(d => d.Name).Query("Oakwood Premier"))));

            Elasticclient.DeleteByQuery<ElasticHotel>(q => q
               .Type("hotel")
               .Query(e => e.Match(m => m.OnField(d => d.Name).Query("Marriot"))));

            var hotel1 = new ElasticHotel
            {
                Name = "Hyatt",
                City = "Pune",
                Country = "India",
                Id = "544f6337d7e32110c4377fb3",
                Latitude = 18.98,
                Longitude = 17.11
            };


            var hotel2 = new ElasticHotel
            {
                Name = "Marriot",
                City = "Pune",
                Country = "India",
                Id = "544f6337d7e32110c4377fb6",
                Latitude = 12.98,
                Longitude = 11.11
            };


            var hotel3 = new ElasticHotel
            {
                Name = "Taj Trident",
                City = "Delhi",
                Country = "India",
                Id = "544f6337d7e32110c4377fb7",
                Latitude = 12.98,
                Longitude = 11.11
            };

            var hotel4 = new ElasticHotel
            {
                Name = "Lemon Tree",
                City = "Hyderabad",
                Country = "India",
                Id = "544f6337d7e32110c4377fb1",
                Latitude = 18.98,
                Longitude = 13.110
            };

            var hotel5 = new ElasticHotel
            {
                Name = "Oakwood Premier",
                City = "Pune",
                Country = "India",
                Id = "544f4154d7e327176c06845f",
                Latitude = 12.98,
                Longitude = 11.11
            };

            Elasticclient.Index(hotel1);
            Elasticclient.Index(hotel2);
            Elasticclient.Index(hotel3);
            Elasticclient.Index(hotel4);
            Elasticclient.Index(hotel5);
            System.Threading.Thread.Sleep(1000);

        }

        //[TestMethod]
        //public void TestSearchHotelsByPrefixQuery()
        //{
        //    Uri localhost = new Uri("http://localhost:9200");
        //    var Elasticsetting = new ConnectionSettings(localhost, defaultIndex: "hotels-app");
        //    var Elasticclient = new ElasticClient(Elasticsetting);            

        //    var prefixSearchResult = Elasticclient.Search<Hotel>(s => s
        //       .Type("hotel")
        //       .Filter(f => f
        //           .Prefix(p => p.Name, "marr")));

        //    List<Hotel> results = new List<Hotel>();

        //    foreach (var element in prefixSearchResult.Documents)
        //    {
        //        results.Add(element);
        //    }
        //    Assert.AreNotEqual(0, prefixSearchResult.Total);
        //    Assert.IsTrue(prefixSearchResult.IsValid);

        //    foreach (var hotel in results)
        //    {
        //        Assert.AreEqual("Marriot",hotel.Name);
        //    }
        //}

        //[TestMethod]
        //public void TestShouldReturnListOfHotelsForCorrectCompleteTerm()
        //{
        //    string term = "Mar";
        //    var elasticSearchObj = new ElasticSearch.ElasticSearch();
        //    var resultSet = elasticSearchObj.FetchHotels(term);

        //    Assert.AreEqual("Marriot", resultSet[0].Name);
        //    Assert.AreEqual("India", resultSet[0].Country);
        //}

        //[TestMethod]
        //public void TestShouldReturnListOfHotelsForCorrectOneLetterTerm()
        //{
        //    string term = "M";
        //    var elasticSearchObj = new ElasticSearch.ElasticSearch();
        //    var resultSet = elasticSearchObj.FetchHotels(term);

        //    Assert.AreEqual("Marriot", resultSet[0].Name);
        //    Assert.AreEqual("India", resultSet[0].Country);
        //}

        //[TestMethod]
        //public void TestShouldReturnListOfHotelsForCorrectTwoLetterTerm()
        //{
        //    string term = "Le";
        //    var elasticSearchObj = new ElasticSearch.ElasticSearch();
        //    var resultSet = elasticSearchObj.FetchHotels(term);

        //    Assert.AreEqual("Lemon Tree", resultSet[0].Name);
        //    Assert.AreEqual("India", resultSet[0].Country);
        //}

        [TestMethod]
        public void TestReturnEmptyListOfHotelsIfNoDestinationsFound()
        {
            string term = "yoyo";
            var elasticSearchObj = new ElasticSearch.ElasticSearch();
            var resultSet = elasticSearchObj.FetchHotels(term);

            Assert.AreEqual(0, resultSet.Count);
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
