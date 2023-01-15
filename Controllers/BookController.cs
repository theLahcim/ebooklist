using ebooklist.Data;
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
        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            List<BookViewModel> bookList = new List<BookViewModel>();

            if (books != null)
            {
                foreach(var book in books)
                {
                    var BookViewModel = new BookViewModel()
                    {
                        ISBN13 = book.ISBN13,
                        ISBN10 = book.ISBN10,
                        Title = book.Title,
                        Author = book.Author,
                        Subtitle = book.Subtitle,
                        Categories = book.Categories,
                        Tumbnail = book.Tumbnail,
                        Description = book.Description,
                        Published_year = book.Published_year,
                        Average_rating = book.Average_rating,
                        Num_pages = book.Num_pages,
                        Ratings_count = book.Ratings_count
                    };
                    bookList.Add(BookViewModel);
                }
            }
            return View(bookList);
        }
    }
}
