using BookStoreApp.Entities;
using BookStoreApp.Exceptions;
using BookStoreApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreApp.Controllers
{
    public class BookController : Controller
    {

        private readonly IBookService _bookService;
        private readonly BookException _bookException;

        public BookController(
            IBookService bookService, 
            BookException bookException)
        {
            _bookService = bookService;
            _bookException = bookException;
        }

        // GET: Books
        public ActionResult Index()
        {
            var books = _bookService.GetAll();
            return View(books);
        }
        
        public ActionResult Form(Books book)
        {
            if (ModelState.IsValid)
            {
                var guardado = _bookService.AddBook(book);

                if (guardado == 200)
                    return RedirectToAction("Index");

                TempData["Result"] = guardado == 404 ?
                    "El autor no ésta registrado" : guardado == 409 ?
                    "No es posible registrar el libro, se alcanzó el máximo permitido." :
                    "Lo sentimos, se ha generado un erorr al agregar el libro";
            } else
            {
                TempData["Result"] = "Lo sentimos, pero debe llenar los campos para continuar";
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var deleted = _bookService.DeleteBook(id);
            if (!deleted)
                TempData["Result"] = "Lo sentimos, se generor un error al eliminar el libro.";
            return RedirectToAction("Index");
        }

    }
}