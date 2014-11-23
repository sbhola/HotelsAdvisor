﻿using System;
using System.Collections.Generic;
using System.Linq;
using Nest;
using System.Text.RegularExpressions;

namespace ElasticSearch
{
    public class ElasticSearch
    {
        private readonly ElasticClient _hotelsClient;
        public ElasticSearch()
        {
            var localhost = new Uri("http://lab22:9200");
            var elasticsetting = new ConnectionSettings(localhost, defaultIndex: "hotelsdb");
            _hotelsClient = new ElasticClient(elasticsetting);

        }
        public List<HotelElastic> FetchHotels(string term)
        {
            if (string.IsNullOrEmpty(term))
                throw new ArgumentNullException("Term is Null or Empty.Please try again.");

            var RgxUrl = new Regex("[^a-z0-9A-Z]");
            if (RgxUrl.IsMatch(term))
                throw new ArgumentException("Invalid characters set.Please try again.");



            //PREFIX QUERY
            //var prefixSearchResult = Elasticclient.Search<Destination>(s => s
            //    .Type("destination")
            //    .Query(p => p
            //        .Prefix(m => m
            //            .OnField(c => c.City)
            //            .Value(term))));

            //PREFIX FILTER QUERY
            //var heh = Elasticclient.Search<Destination>(s => s
            //    .Type("destination")
            //    .Query(p => p.Filtered(f => f.Query(q => q.Prefix(m => m
            //        .OnField(c => c.City)
            //        .Value(term))))));

            //PREFIX FILTER - MOST EFFICIENT
           var prefixSearchResult = _hotelsClient.Search<HotelElastic>(s => s
                .Type("elastichotel")
                .Filter(f => f
                    .Prefix(p => p.Name, term.ToLower())));

            var results = new List<HotelElastic>();

            foreach (var element in prefixSearchResult.Documents)
            {
                results.Add(element);
            }

            return results;
        }

        public List<Destination> FetchDestinations(string term)
        {
            if (string.IsNullOrEmpty(term))
                throw new ArgumentNullException("Term is Null or Empty.Please try again.");

            Regex RgxUrl = new Regex("[^a-z0-9A-Z]");
            if (RgxUrl.IsMatch(term))
                throw new ArgumentException("Invalid characters set.Please try again.");

            Uri localhost = new Uri("http://lab22:9200");
            var Elasticsetting = new ConnectionSettings(localhost, defaultIndex: "destinationsdb");
            var Elasticclient = new ElasticClient(Elasticsetting);


            //PREFIX QUERY
            //var prefixSearchResult = Elasticclient.Search<Destination>(s => s
            //    .Type("destination")
            //    .Query(p => p
            //        .Prefix(m => m
            //            .OnField(c => c.City)
            //            .Value(term))));

            //PREFIX FILTER QUERY
            //var heh = Elasticclient.Search<Destination>(s => s
            //    .Type("destination")
            //    .Query(p => p.Filtered(f => f.Query(q => q.Prefix(m => m
            //        .OnField(c => c.City)
            //        .Value(term))))));

            //PREFIX FILTER - MOST EFFICIENT
            var prefixSearchResult = Elasticclient.Search<Destination>(s => s
                .Type("destination")
                .Filter(f => f
                    .Prefix(p => p.City, term.ToLower())));

            List<Destination> results = new List<Destination>();

            foreach (var element in prefixSearchResult.Documents)
            {
                results.Add(element);
            }

            return results;
        }

        public List<string> FetchHotelIds(string city, string country)
        {
            if (string.IsNullOrEmpty(city) && string.IsNullOrEmpty(country))
            {
                throw new ArgumentException("City/Country name null or Empty.");
            }
            var searchResults = _hotelsClient.Search<HotelElastic>(s => s
                                            .Indices("hotelsdb")
                                            .Type("elastichotel")
                                            .Query(q => q.Match(m => m.OnField(f => f.City).Query(city))
                                              && q.Match(m => m.OnField(f => f.Country).Query(country))));

            var idList = searchResults.Documents.Select(doc => doc.Id).ToList();
            return idList;
        }
    }
}