using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnkiAPI.Models
{
    public class Desk
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
        public virtual User User { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
