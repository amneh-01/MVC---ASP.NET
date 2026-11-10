using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TASK_8_11.Data;
using TASK_8_11.Models;

namespace TASK_8_11.Controllers;

public class SupplierController : Controller
{
    private readonly ApplicationDbContext _context;
    public SupplierController(ApplicationDbContext context) => _context = context;

    public IActionResult Index() => View(_context.supply.Include(s => s.Products).ToList());
    [HttpGet] public IActionResult Create() => View();
    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Create(Supplier supplier)
    {
        if (!ModelState.IsValid) return View(supplier);
        _context.supply.Add(supplier); _context.SaveChanges(); return RedirectToAction(nameof(Index));
    }
    public IActionResult Details(int id) { var item = _context.supply.Include(s => s.Products).FirstOrDefault(s => s.Id == id); return item == null ? NotFound() : View(item); }
    [HttpGet] public IActionResult Edit(int id) { var item = _context.supply.Find(id); return item == null ? NotFound() : View(item); }
    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Supplier supplier)
    {
        if (id != supplier.Id) return NotFound();
        if (!ModelState.IsValid) return View(supplier);
        _context.supply.Update(supplier); _context.SaveChanges(); return RedirectToAction(nameof(Index));
    }
    [HttpGet] public IActionResult Delete(int id) { var item = _context.supply.Find(id); return item == null ? NotFound() : View(item); }
    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var item = _context.supply.Find(id); if (item == null) return NotFound();
        _context.supply.Remove(item); _context.SaveChanges(); return RedirectToAction(nameof(Index));
    }
}
