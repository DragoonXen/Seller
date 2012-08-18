using System.ComponentModel.DataAnnotations;

namespace Seller.Models
{
    public class Producer
    {
        [Key]
        public int ProducerId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Site { get; set; }

        public string LogoUrl { get; set; }
    }
}