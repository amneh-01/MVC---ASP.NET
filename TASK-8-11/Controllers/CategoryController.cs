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
            var category = _context.categories.ToList();
            return View(category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.categories.Add(category);//بروح ع التيبل تاعت الكتيجووري عشان يضيف بس ما بخزن الااضافه الا بعد ما اعمل save
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
