using System;
using System.Collections.Generic;
using System.Linq;

namespace ElasticSearch
{
    public interface IElasticSearchProvider
    {
        List<Hotel> FetchHotels(string term);

        List<string> FetchHotelsInDestinations(string term);

        List<string> FetchHotelIds(string city, string state, string country);
    }
}
