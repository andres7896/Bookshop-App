using BookStoreApp.Entities;
using BookStoreApp.Interfaces;
using BookStoreApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreApp.Controllers
{
    public class AuthorController : Controller
    {

        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: Author
        public ActionResult Index()
        {
            var authors = _authorService.GetAll();
            return View(authors);
        }

        // GET: Author
        public ActionResult Form(Authors author)
        {
            if (ModelState.IsValid)
            {
                _authorService.AddAuthor(author);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Result"] = "Lo sentimos, pero debe llenar los campos para continuar";
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var deleted = _authorService.DeleteAuthor(id);
            if (!deleted)
                TempData["Result"] = "Lo sentimos, se generor un error al eliminar el autor.";
            return RedirectToAction("Index");
        }

    }
}