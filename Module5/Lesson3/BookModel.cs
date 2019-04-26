using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson3
{
    public class BookModel
    {
        public int ID { get; set; }
        public string BookNum { get; set; }
        public string BookName { get; set; }
        public string BookConcern { get; set; }
        public string BookAuthor { get; set; }
        public int BookCount { get; set; }
        public decimal BookPrice { get; set; }
    }
}
