using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ebooklist.Models
{
    public class BookViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public float Price { get; set; }
        public string Publisher { get; set; }
        public string Series { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public string Cover { get; set; }
        public string Shop_url { get; set; }
        public string Img_url { get; set; }
    }
}
