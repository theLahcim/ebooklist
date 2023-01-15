using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ebooklist.Models
{
    public class BookViewModel
    {
        public string ISBN13 { get; set; }
        public string ISBN10 { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Authors { get; set; }
        public string Categories { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }
        public int Published_year { get; set; }
        public float Average_rating { get; set; }
        public int Num_pages { get; set; }
        public int Ratings_count { get; set; }
    }
}
