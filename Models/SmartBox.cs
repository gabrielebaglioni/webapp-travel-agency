using System;
using Microsoft.AspNetCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
//https://picsum.photos/200/200
namespace webapp_travel_agency.Models
{
    public class SmartBox
    {
       
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(75, ErrorMessage = "Il titolo non può essere oltre i 75 caratteri")]       
        public string? Title { get; set; }


        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(800, ErrorMessage = "La Dscrizione non può essere oltre i 800 caratteri")]
        [Column(TypeName = "text")]
        public string? Description { get; set; }


        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Url]
        public string? Image { get; set; }
        


        [Required(ErrorMessage = "Il Capo obbligatorio")]
        [Range(1, 30, ErrorMessage = "La Durata durta deve essere compresa tra 1 a 30 notti")]
        public int? DurataInNotti { get; set; }


        [Required(ErrorMessage = "Il prezzo e' obbligatorio")]
        [Range(1, 500, ErrorMessage = "Il prezzo della box deve essere incluso tra 1 e 500 euro")]

        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(75, ErrorMessage = "La città non può essere oltre i 75 caratteri")]
        public string? city { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(75, ErrorMessage = "Il paese non può essere oltre i 75 caratteri")]
        public string? Country { get; set; }

        public List<Message> Messages { get; set; }


        public SmartBox()
        {
        }
    }
}

