using System.ComponentModel.DataAnnotations;

namespace Seller.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}