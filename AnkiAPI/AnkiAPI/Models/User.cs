using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnkiAPI.Models
{
    public class User
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int TgId { get; set; }
        public string Lang { get; set; } = "ru";

        public virtual ICollection<Desk> Desk { get; set; }
    }
}
