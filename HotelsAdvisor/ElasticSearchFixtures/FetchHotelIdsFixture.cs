using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nest;

namespace ElasticSearchFixtures
{
    [TestClass]
    public class FetchHotelIdsFixture
    {        
        [TestMethod]
        public void TestForFetchingIdsFromElasticSearch()
        {
            var elasticObject = new ElasticSearch.ElasticSearch();
            const string city = "pune";
            const string country = "india";
            var idList = elasticObject.FetchHotelIds(city, country);

            Assert.AreEqual(0, idList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestForNullParameterShouldThrow()
        {
            var elasticObject = new ElasticSearch.ElasticSearch();
            const string city = null;
            const string country = null;
              var idList = elasticObject.FetchHotelIds(city, country);    
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestForEmptyParameterShouldThrow()
        {
            var elasticObject = new ElasticSearch.ElasticSearch();
            const string city = "";
            const string country = "";
            var idList = elasticObject.FetchHotelIds(city, country);
        }

    }
}
