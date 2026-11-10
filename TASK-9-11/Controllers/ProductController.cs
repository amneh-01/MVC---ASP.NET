using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TASK_8_11.Data;
using TASK_8_11.Models;

namespace TASK_8_11.Controllers
{
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;

        }
       
        public IActionResult Index()
        {  
            
            var products=_context.products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.categories.ToList(), "Id", "Name");
            ViewBag.Suppliers = new SelectList(_context.supply.ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {

            var product = _context.products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            var product = _context.products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }



        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
            return RedirectToAction("index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _context.products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("index");
        }



    }
}