using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Management_System.Database;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    public class BookController : Controller
    {
        protected readonly LMSContext _dbContext;

        public int Id { get; private set; }

        public BookController(LMSContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public IActionResult Index()
        {
            var book = _dbContext.Book;
            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            _dbContext.Book.Add(book);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int?Id)
        {
            if(Id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var book = _dbContext.Book.FirstOrDefault(x => x.BookId == Id);
                return View(book);
            }
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            _dbContext.Book.Update(book);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Details(int Id)
        {
            var book = _dbContext.Book.FirstOrDefault(x => x.BookId == Id);
            return View(book);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id==null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var book = _dbContext.Book.FirstOrDefault(x => x.BookId == Id);
                return View(book);
            }
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var book = _dbContext.Book.FirstOrDefault(x => x.BookId == Id);
            _dbContext.Book.Remove(book);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
        
    }
}