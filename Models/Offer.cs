using System;
using System.ComponentModel.DataAnnotations;

namespace Seller.Models
{
    public class Offer
    {
        [Key]
        [Column(Order = 1)]
        public int ProductId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int MagazineId { get; set; }

        [Required]
        public Product Product { get; set; }

        [Required]
        public Magazine Magazine { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public DateTime LastUpdate { get; set; }
    }
}