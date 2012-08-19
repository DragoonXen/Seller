using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Seller.Models
{
    public class Shop
    {
        [Key]
        public int ShopId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Site { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [MaxLength(100)]
        public string Adress { get; set; }

        [MaxLength(2048)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public int Course { get; set; }

        public string Image { get; set; }

        public ICollection<Offer> Offers { get; set; }

        [Required]
        public Guid AccountGuid { get; set; }
    }
}