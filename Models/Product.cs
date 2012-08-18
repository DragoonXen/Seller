using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Seller.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public Category Category { get; set; }

        public Producer Producer { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Image> Images { get; set; }

        public Guid CreatedBy { get; set; }
    }
}