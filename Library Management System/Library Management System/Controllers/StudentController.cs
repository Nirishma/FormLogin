using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Management_System.Database;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Library_Management_System.Controllers
{
    public class StudentController : Controller
    {
        protected readonly LMSContext _dbcontext;

        public StudentController(LMSContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var students = from s in _dbcontext.Student
                               select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
                {
                    case "name_desc":
                        students = students.OrderByDescending(s => s.FirstName);
                        break;
                    
                    case "Batch":
                    students = students.OrderByDescending(s => s.Batch);
                    break;
                    default:
                        students = students.OrderBy(s => s.FirstName);
                        break;
                }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
            
            //return View(students.ToList());
        }
        /*
        var students = _dbcontext.Student;
        return View(students);
        */
    

        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _dbcontext.Student.Add(student);
            _dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var student = _dbcontext.Student.FirstOrDefault(x => x.StudentId == Id);
                return View(student);
            }

        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _dbcontext.Student.Update(student);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
              
        }
        [HttpGet]
        public IActionResult Details( int Id)
        {
            var student = _dbcontext.Student.FirstOrDefault(x => x.StudentId == Id);

            return View(student);

        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var student = _dbcontext.Student.FirstOrDefault(x => x.StudentId == Id);
                return View(student);
            }

        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var student = _dbcontext.Student.FirstOrDefault(x => x.StudentId == Id);
            _dbcontext.Student.Remove(student);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
    }
