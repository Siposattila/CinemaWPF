using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CinemaWPF.Models
{
    [Table("reserves")]
    public class Reserve : Entity
    {
        [MaxLength(100)]
        [MinLength(2)]
        [Required]
        public string Name { get; set; }

        [Range(0, 1)]
        public int Reserved { get; set; }
    }
}