using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelsAdvisor.Models
{
    public class Hotel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        public string StateCode { get; set; }

        [Required]
        public string Country { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Rating { get; set; }

        public List<String> ImageList { get; set; }

        public DateTime UtcTimeSubmitted { get; set; }

        public List<Review> Reviews { get; set; }

        public string Description { get; set; }
    }
}