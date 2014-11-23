using System.Collections.Generic;

namespace HotelsAdvisor.Models
{
    public class HomePageModel
    {
        public AutocompleteSearchObject SearchResult { get; set; }
        public List<Hotel> TopHotels { get; set; }

        public void Load()
        {

            SearchResult = new AutocompleteSearchObject();

            TopHotels = new List<Hotel>();
            TopHotels.Add(new Hotel());
            TopHotels.Add(new Hotel());
            TopHotels.Add(new Hotel());
            TopHotels.Add(new Hotel());
        }
    }
}