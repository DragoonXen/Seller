using System.ComponentModel.DataAnnotations;

namespace Seller.Models
{
    public class Producer
    {
        [Key]
        public int ProducerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Site { get; set; }

        [Required]
        public string LogoPath { get; set; }
    }
}