using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBookApp.Models;
using MyBookApp.ViewModels;

namespace MyBookApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.Include(b => b.bookCategory).ToListAsync();
            return View(books);
        }

        //GET: Home/CreateBookCategory
        public IActionResult CreateBookCategory()
        {
            return View();
        }

        //POST: Home/CreateBookCategory
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBookCategory(BookCategory bookCategory)
        {
            if (ModelState.IsValid)
            {
                _context.BookCategories.Add(bookCategory);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        //GET: Home/CreateBook
        public async Task<IActionResult> CreateBook()
        {
            AddBookViewModel viewModel = new AddBookViewModel(await _context.BookCategories.ToListAsync());
            return View(viewModel);
        }

        //POST: Home/CreateBook
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBook(AddBookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var book = new Book {
                    Name = viewModel.BookName,
                    Description = viewModel.BookDescription,
                    Author = viewModel.BookAuthor,
                    BookCategoryId = viewModel.BookCategoryId
                };

                _context.Add(book);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
