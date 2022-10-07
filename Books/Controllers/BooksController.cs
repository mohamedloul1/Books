using Books.Models;
using Books.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Books.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Books
          public ActionResult Index()
        {
            var books = _context.Books.Include(m => m.Category).ToList();
            return View(books);
        }

        public ActionResult Create()
        {
           var viewModel = new BookFormViewModel()
            {
                Categories = _context.Categories.Where(m => m.IsActive).ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _context.Categories.Where(m => m.IsActive).ToList();
                return View("Create", model);
            }

            var book = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                CategoryId = model.CategoryId,
                Description = model.Description
            };
            _context.Books.Add(book);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}