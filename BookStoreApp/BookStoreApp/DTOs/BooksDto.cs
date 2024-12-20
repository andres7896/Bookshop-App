using BookStoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreApp.DTOs
{
    public class BooksDto
    {
        public int Id_book { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
    }
}