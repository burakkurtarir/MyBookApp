﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBookApp.Models;
using MyBookApp.ViewModels;

namespace MyBookApp.Controllers
{
    ///[Authorize]
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

        //[Authorize(Roles = "Admin")]
        //GET: Home/CreateBookCategory
        public IActionResult CreateBookCategory()
        {
            return View();
        }

        //POST: Home/CreateBookCategory
        [HttpPost]
        //[Authorize(Roles = "Admin")]
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

        //[Authorize(Roles = "Admin")]
        //GET: Home/CreateBook
        public async Task<IActionResult> CreateBook()
        {
            AddBookViewModel viewModel = new AddBookViewModel(await _context.BookCategories.ToListAsync());
            return View(viewModel);
        }

        //POST: Home/CreateBook
        [HttpPost]
        //[Authorize(Roles = "Admin")]
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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult RegisterOrSignIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(BookUser bookUser)
        {
            ClaimsIdentity identity = null;
            bool isAuthenticated = false;

            BookUser databaseUser = await _context.BookUsers.Where(u => u.Username.Contains(bookUser.Username, StringComparison.Ordinal) &&
                                                                        u.Password.Contains(bookUser.Password, StringComparison.Ordinal))
                                                                       .SingleOrDefaultAsync();
            //Eğer böyle bir kullanıcı var giriş yap
            if (databaseUser != null)
            {
                identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, databaseUser.Username),
                        new Claim(ClaimTypes.Role, databaseUser.Role),
                        new Claim("UserId", databaseUser.Id.ToString()) //Custom claim that i created
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                isAuthenticated = true;
            }
            if (isAuthenticated)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index");
            }
            TempData["SignInMessage"] = "Username or/and password wrong";
            return RedirectToAction("RegisterOrSignIn");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(BookUser bookUser)
        {
            if (ModelState.IsValid)
            {
                ClaimsIdentity identity = null;
                bool isAuthenticated = false;

                BookUser databaseUser = await _context.BookUsers.Where(u => u.Username.Contains(bookUser.Username, StringComparison.Ordinal))
                                                                      .SingleOrDefaultAsync();

                //Eğer daha önceden aynı kullanıcı adıyla kayıt olmuş bir kullanıcı yoksa 
                if (databaseUser == null)
                {
                    bookUser.Role = "User";
                    _context.Add(bookUser);
                    await _context.SaveChangesAsync();

                    identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, bookUser.Username),
                        new Claim(ClaimTypes.Role, bookUser.Role),
                        new Claim("UserId", bookUser.Id.ToString()) //Custom claim that i created
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                    isAuthenticated = true;
                }
                if (isAuthenticated)
                {
                    var principal = new ClaimsPrincipal(identity);
                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("Index");
                }
            }
            TempData["RegisterMessage"] = "You can't register with the same username";
            return RedirectToAction("RegisterOrSignIn");
        }

        public IActionResult LogOut()
        {
            var logout = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("RegisterOrSignIn");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
