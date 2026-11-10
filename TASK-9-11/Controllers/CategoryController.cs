using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TASK_8_11.Data;
using TASK_8_11.Models;

namespace TASK_8_11.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _context; 

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            var categories = _context.categories.Include(c => c.Products).ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {

            var categories = _context.categories.Find(id);

            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            var category = _context.categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }



        [HttpPost]
        public IActionResult Edit(Employee category)
        {
            _context.Update(category);
            _context.SaveChanges();
            return RedirectToAction("index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _context.categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("index");
        }



    }
}
