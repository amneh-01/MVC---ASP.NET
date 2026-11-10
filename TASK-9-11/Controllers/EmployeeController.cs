using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TASK_8_11.Data;
using TASK_8_11.Models;

namespace TASK_8_11.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            var employees = _context.employees.Include(c => c.Orders).ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _context.employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {

            var employee = _context.employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            var employee = _context.products.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }



        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            _context.Update(employee);
            _context.SaveChanges();
            return RedirectToAction("index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _context.employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("index");
        }



    }
}