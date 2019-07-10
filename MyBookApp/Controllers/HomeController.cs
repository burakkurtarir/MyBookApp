using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
                    ImageUrl = viewModel.BookImageUrl,
                    Description = viewModel.BookDescription,
                    Author = viewModel.BookAuthor,
                    Stock = viewModel.BookStock,
                    BookCategoryId = viewModel.BookCategoryId
                };

                _context.Add(book);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> BuyBook(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var book = await _context.Books.Include(b => b.bookCategory).FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BuyBook(Book book)
        {
            if (book == null)
            {
                RedirectToAction("BuyBook");
            }
            var myBook = await _context.Books.FirstOrDefaultAsync(b => b.Id == book.Id);
            if (myBook == null)
            {
                RedirectToAction("BuyBook");
            }
            if (myBook.Stock >= 1)
            {
                //Kitap satın alındığı için stok 1 azaltıldı ve güncelleştirildi
                myBook.Stock -= 1;
                _context.Books.Update(myBook);
                await _context.SaveChangesAsync();

                //TempData["AlertCode"] = AlertCodes.Success;
                TempData["AlertTitle"] = "Başarılı";
                TempData["AlertMessage"] = "Kitap satın alındı";
                TempData["AlertType"] = "success";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["AlertTitle"] = "Hata";
                TempData["AlertMessage"] = "Kitap stokta yok";
                TempData["AlertType"] = "danger";

                return RedirectToAction("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
