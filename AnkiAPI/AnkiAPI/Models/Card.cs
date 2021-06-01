using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnkiAPI.Models
{
    public class Card
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Front { get; set; }
        [Required]
        public string Back { get; set; }

        public bool Favorite { get; set; } = false;

        public int DeskId { get; set; }
        public virtual Desk Desk { get; set; }
    }
}
