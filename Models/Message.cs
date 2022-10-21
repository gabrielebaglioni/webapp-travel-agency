using System;
using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public int SmartBoxId { get; set; }
        public SmartBox? SmartBox { get; set; }

       
    }
}

