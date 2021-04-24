using System.ComponentModel.DataAnnotations;

namespace SFF.Core.Entities
{
    public class Association : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Range(10000, 99999)]
        public int ZipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}