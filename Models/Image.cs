using System;
using System.ComponentModel.DataAnnotations;

namespace Seller.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        public string Path { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }

        public string FullPath
        {
            get
            {
                return String.Format("{0}Content{1}Images{1}Products{1}{2}", AppDomain.CurrentDomain.BaseDirectory,
                                     System.IO.Path.DirectorySeparatorChar, Path);
            }
        }

    }
}