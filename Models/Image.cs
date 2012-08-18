using System.ComponentModel.DataAnnotations;

namespace Seller.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        public string Path { get; set; }

        public virtual Product Product { get; set; }
    }
}