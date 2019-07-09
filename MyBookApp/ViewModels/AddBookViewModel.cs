using Microsoft.AspNetCore.Mvc.Rendering;
using MyBookApp.Models;
using System;
using System.Collections.Generic;
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
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public string BookAuthor { get; set; }
        public int BookCategoryId { get; set; }
        public List<SelectListItem> BookCategories { get; set; }
    }
}
