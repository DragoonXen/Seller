using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

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

        [Required(ErrorMessage = "Logo required")]
        public string LogoPath { get; set; }

        public string FullLogoPath
        {
            get
            {
                return String.Format("{0}Content{1}Images{1}Producers{1}{2}", AppDomain.CurrentDomain.BaseDirectory,
                                     Path.DirectorySeparatorChar, LogoPath);
            }
        }
    }
}