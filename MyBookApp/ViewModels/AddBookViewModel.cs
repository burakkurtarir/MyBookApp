using Microsoft.AspNetCore.Mvc.Rendering;
using MyBookApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookApp.ViewModels
{
    public class AddBookViewModel
    {
        public AddBookViewModel()
        {

        }
        public AddBookViewModel(List<BookCategory> bookCategories)
        {
            BookCategories = new List<SelectListItem>();
            foreach (var item in bookCategories)
            {
                BookCategories.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name});
            }
        }
        [Required]
        public string BookName { get; set; }

        [Required]
        public string BookImageUrl { get; set; }

        [Required]
        public string BookDescription { get; set; }

        [Required]
        public string BookAuthor { get; set; }

        [Required]
        public int BookStock { get; set; }

        [Required]
        public float BookPrice { get; set; }

        public int BookCategoryId { get; set; }

        public List<SelectListItem> BookCategories { get; set; }
    }
}
