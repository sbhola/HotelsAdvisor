using System;
using MongoDB.Bson;

namespace HotelAdvisor.BLL.Model
{
    public class Review
    {
        public ObjectId Id { get; set; }

        public string HotelId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public string UserName { get; set; }

        public DateTime UtcTimeSubmitted { get; set; }

        public int Value { get; set; }

        public int Rooms { get; set; }

        public int Cleanliness { get; set; }

        public int Location { get; set; }

        public int Service { get; set; }
    }
}
