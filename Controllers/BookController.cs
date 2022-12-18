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
                        Author = book.Author,
                        Title = book.Title,
                        Cover = book.Cover,
                        Pages = book.Pages,
                        Price = book.Price,
                        Series = book.Series,
                        Publisher = book.Publisher,
                        Year = book.Year,
                        Shop_url = book.Shop_url,
                        Img_url = book.Img_url
                    };
                    bookList.Add(BookViewModel);
                }
            }
            return View(bookList);
        }
    }
}
