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

        [ForeignKey(nameof(Seat))]
        public int SeatId { get; set; }

        [NotMapped]
        public virtual Seat Seat { get; set; }
    }
}