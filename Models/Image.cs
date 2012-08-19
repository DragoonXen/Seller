using System.ComponentModel.DataAnnotations;

namespace Seller.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        public string Path { get; set; }
        
        [Required]
        public Product Product { get; set; }
    }
}