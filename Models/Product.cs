using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Seller.Models
{
    public class Product
    {
        public Product()
        {
            Images = new Collection<Image>();
        }

        [Key]
        public int ProductId { get; set; }

        [ScaffoldColumn(false)]
        public bool Approved { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        [Display(Name = "Producer")]
        public int ProducerId { get; set; }

        public Producer Producer { get; set; }

        [Required]
        [MaxLength(50)]
        [Display]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Image> Images { get; set; }

        [ScaffoldColumn(false)]
        public Guid CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public Guid EditedBy { get; set; }

        public ICollection<Offer> Offers { get; set; }
    }
}