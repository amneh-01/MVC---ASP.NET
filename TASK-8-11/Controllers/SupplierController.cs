using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TASK_8_11.Data;
using TASK_8_11.Models;

namespace TASK_8_11.Controllers
{
    
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SupplierController(ApplicationDbContext context)
        {
            _context= context ;

        }

        public IActionResult Index()
        {
            var supply = _context.supply.ToList();
            return View(supply);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Supplier supply)
        {
            _context.supply.Add(supply);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
