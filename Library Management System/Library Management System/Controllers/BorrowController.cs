using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Management_System.Database;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Controllers
{
    public class BorrowController : Controller
    {
        protected readonly LMSContext _dbcontext;

        public BorrowController(LMSContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {

            var borrow = _dbcontext.Borrow.Include(x=>x.student).Include(x=>x.book);
            return View(borrow);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Borrow borrow)
        {
            _dbcontext.Borrow.Add(borrow);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var borrow = _dbcontext.Borrow.Include(x => x.student).Include(x=>x.book);
                return View(borrow);
            }
        }
        [HttpPost]
        public IActionResult Edit(Borrow borrow)
        {
            _dbcontext.Borrow.Update(borrow);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}