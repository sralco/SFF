using System;
using System.ComponentModel.DataAnnotations;

namespace SFF.Core.Entities
{
    public class Review : BaseEntity
    {
        [Required]
        public int AssociationId { get; set; }
        [Required]
        public int MovieId { get; set; }
        public Association Association { get; set; }
        public Movie Movie { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be in range 1-5")]
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}