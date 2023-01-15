using ebooklist.Data;
using ebooklist.Entieties;
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
            this._context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var books = from b in _context.Books
                        select b;
            // var books = _context.Books.ToList();
            // List<BookViewModel> bookList = new List<BookViewModel>();
            /*
            if (books != null)
            {
                foreach(var book in books)
                {
                    var BookViewModel = new BookViewModel()
                    {
                        ISBN13 = book.ISBN13,
                        ISBN10 = book.ISBN10,
                        Title = book.Title,
                        Authors = book.Authors,
                        Subtitle = book.Subtitle,
                        Categories = book.Categories,
                        Thumbnail = book.Thumbnail,
                        Description = book.Description,
                        Published_year = book.Published_year,
                        Average_rating = book.Average_rating,
                        Num_pages = book.Num_pages,
                        Ratings_count = book.Ratings_count
                    };
                    bookList.Add(BookViewModel);
                }
            }*/

            ViewBag.Data = books.ToList().Take(10);
            int pageSize = 50;
            return View(await PaginatedList<Book>.CreateAsync(books, pageNumber ?? 1, pageSize));
//  return View(bookList);
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
