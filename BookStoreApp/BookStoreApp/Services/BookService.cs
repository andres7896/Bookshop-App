using BookStoreApp.Context;
using BookStoreApp.DTOs;
using BookStoreApp.Entities;
using BookStoreApp.Exceptions;
using BookStoreApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreApp.Services
{
    public class BookService: IBookService
    {

        private readonly DbConnection ctx;
        private readonly int LimitAdditions = 5;

        public BookService(DbConnection context)
        {
            ctx = context;
        }

        public List<BooksDto> GetAll()
        {
            try
            {
                var query = "SELECT * FROM VIEWBOOK";
                return ctx.Database.SqlQuery<BooksDto>(query).ToList();
            }
            catch
            {
                return null;
            }
        }

        public int AddBook(Books book)
        {
            try
            {
                var authorFound = ctx.Authors.FirstOrDefault(a => a.FullName.ToLower() == book.AuthorQuery.ToLower());
                if (authorFound == null)
                {
                    return 404;
                    throw new BookException("El autor no ésta registrado");
                }

                book.Id_author = authorFound.Id_author;

                var count = GetAll().Count();
                if  (count == LimitAdditions)
                {
                    return 409;
                    throw new BookException("No es posible registrar el libro, se alcanzó el máximo permitido.");
                }

                var query = $"EXEC Proc_AddBook '{book.Title}', {book.Year}, '{book.Gender}', {book.PagesNumber}, {book.Id_author}";
                ctx.Database.ExecuteSqlCommand(query);
                return 200;
            }
            catch
            {
                return 500;
            }
        }
        
        public bool DeleteBook(int id)
        {
            try
            {
                var book = ctx.Books.FirstOrDefault(b => b.Id_book == id);
                if (book == null)
                    return false;
                ctx.Books.Remove(book);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        

    }
}