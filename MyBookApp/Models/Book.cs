using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookApp.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public float Price { get; set; }

        public int BookCategoryId { get; set; }

        [ForeignKey("BookCategoryId")]
        public BookCategory bookCategory { get; set; }

    }
}
