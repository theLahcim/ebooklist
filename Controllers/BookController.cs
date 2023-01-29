using ebooklist.Data;
using ebooklist.Entities;
using ebooklist.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ebooklist.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            this._context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int? pageNumber, string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var books = from b in _context.Books
                        select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(b => b.Title.Contains(searchString)
                                       || b.Authors.Contains(searchString));
            }

            ViewBag.Data = books.ToList().Take(10);
            int pageSize = 50;
            return View(await PaginatedList<Book>.CreateAsync(books, pageNumber ?? 1, pageSize));
        }

        [HttpGet]
        public IActionResult Details(string id = null)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _context.Books
                .FirstOrDefault(m => m.ISBN13 == id);

            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
    }
}
