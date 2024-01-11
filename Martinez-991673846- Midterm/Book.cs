using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinez_991673846__Midterm
{
    class Book
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ISBN { get; set; }
        public double Price { get; set; }
        public Book(string title, string genre, int isbn, double price) 
        {
            this.Title = title;
            this.Genre = genre;
            this.ISBN  = isbn;
            this.Price = price;
        }
    }
}
