namespace HotelsAdvisor.Models
{
    public class AutocompleteSearchObject
    {
        public string Id { get; set; }
        public string SearchResultLine1 { get; set; }
        public string SearchResultLine2 { get; set; }
        public string SearchResultLine3 { get; set; }
        public string Category { get; set; }

        public void Load(string id, string searchResult1, string searchResult2, string searchResult3, string category)
        {
            Id = id;
            SearchResultLine1 = searchResult1;
            SearchResultLine2 = searchResult2;
            SearchResultLine3 = searchResult3;
            Category = category;
        }
    }
}