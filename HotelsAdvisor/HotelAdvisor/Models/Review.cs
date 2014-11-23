using System;
using System.ComponentModel.DataAnnotations;


namespace HotelsAdvisor.Models
{
    public class Review
    {
        [Required]
        public string Id { get; set; }
       
        [Required]
        public string HotelId { get; set;}
       
        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "* A valid Title is required.")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "* A valid Description is required.")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "* A Valid Rating is required")]
        [Display(Name = "Rating")]
        public int Rating { get; set; }

        [Required]
        public string UserName { get; set;}

        public DateTime UtcTimeSubmitted { get; set; }

       
        public int Value { get; set; }
        
       
        public int Rooms { get; set; }

        
        public int Cleanliness { get; set; }

        
        public int Location { get; set; }

        public int Service { get; set; }
    }
}
