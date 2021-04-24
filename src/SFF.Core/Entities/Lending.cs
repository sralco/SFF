using System;
using System.ComponentModel.DataAnnotations;
using SFF.Core.Constants;

namespace SFF.Core.Entities
{
    public class Lending : BaseEntity
    {
        [Required]
        public int AssociationId { get; set; }
        [Required]
        public int MovieId { get; set; }
        public Association Association { get; set; }
        public Movie Movie { get; set; }
        [Required]
        public MovieFormat MovieFormat { get; set; }
        [Required]
        public DateTime LendingDate { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
        public bool Returned { get; set; }

    }
}