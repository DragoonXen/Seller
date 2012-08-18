using System.ComponentModel.DataAnnotations;

namespace Seller.Models
{
    public class Magazine
    {
        [Key]
        public int MagazineId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Site { get; set; }

        [MaxLength(50)]
        public string Adress { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public int Course { get; set; }
    }
}