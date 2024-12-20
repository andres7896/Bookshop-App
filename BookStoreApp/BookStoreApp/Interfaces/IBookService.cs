using BookStoreApp.DTOs;
using BookStoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Interfaces
{
    public interface IBookService
    {
        List<BooksDto> GetAll();
        int AddBook(Books book);
        bool DeleteBook(int id);
    }
}
