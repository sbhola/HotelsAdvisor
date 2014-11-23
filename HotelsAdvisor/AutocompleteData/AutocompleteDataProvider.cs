namespace AutocompleteData
{
    public class AutocompleteDataProvider : IAutocompleteDataProvider
    {
        public AutocompleteSearchObject[] getMatchingData(string input)
        {
            var elasticObj = new ElasticSearch.ElasticSearch();
            var hotelsList = elasticObj.FetchHotels(input);
            var destinationsList = elasticObj.FetchDestinations(input);
            int index = 0;
            AutocompleteSearchObject[] objects = new AutocompleteSearchObject[hotelsList.Count + destinationsList.Count];



            foreach (var destination in destinationsList)
            {
                objects[index] = new AutocompleteSearchObject();
                objects[index].Load(index.ToString(), destination.City, destination.State, destination.Country, "Location");
                index++;
            }

            foreach (var hotel in hotelsList)
            {
                objects[index] = new AutocompleteSearchObject();
                objects[index].Load(hotel.Id, hotel.Name, hotel.City, hotel.Country, "Hotel");
                index++;
            }

            //objects[0] = new AutocompleteSearchObject();
            //objects[0].Load("1", "Pune", "Maharashtra", "India", "Location");
            //objects[1] = new AutocompleteSearchObject();
            //objects[1].Load("2", "Kalyan", "Maharashtra", "India", "Location");
            //objects[2] = new AutocompleteSearchObject();
            //objects[2].Load("3", "Marriot", "Pune", "Maharashtra", "Hotel");
            //objects[3] = new AutocompleteSearchObject();
            //objects[3].Load("4", "Goa", "India", "Asia", "Location");
            //objects[4] = new AutocompleteSearchObject();
            //objects[4].Load("5", "Hyatt", "Pune", "Maharashtra", "Location");

            return (objects);
        }
    }
}