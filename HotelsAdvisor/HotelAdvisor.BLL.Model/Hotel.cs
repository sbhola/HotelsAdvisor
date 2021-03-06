﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace HotelAdvisor.BLL.Model
{
    public class Hotel
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string StateCode { get; set; }

        public string Country { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Rating { get; set; }

        public List<String> ImageList { get; set; }

        public DateTime UtcTimeSubmitted { get; set; }

        public string Description { get; set; }

    }
}
