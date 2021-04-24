using System;
using System.ComponentModel.DataAnnotations;
using SFF.Core.Constants;

namespace SFF.Core.Entities
{
    public class Movie : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Range(1900, 2050, ErrorMessage = "Not a valid year")]
        public int ReleaseYear { get; set; }
        public Country Country { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Number of licenses is not in range >0")]
        public int NbrOfLicenses { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Number of copies is not in range >0")]
        public int NbrOfPhysicalCopies { get; set; }
        public bool IsDigital { get; set; }
        public bool IsPhysical { get; set; }
    }
}