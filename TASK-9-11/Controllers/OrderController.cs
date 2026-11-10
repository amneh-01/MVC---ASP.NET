using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TASK_8_11.Data;
using TASK_8_11.Models;

namespace TASK_8_11.Controllers;

public class OrderController : Controller
{
    private readonly ApplicationDbContext _context;
    public OrderController(ApplicationDbContext context) => _context = context;
    public IActionResult Index() => View(_context.orders.Include(o => o.Employee).ToList());
    [HttpGet] public IActionResult Create() { LoadEmployees(); return View(); }
    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Create(Order order)
    {
        if (!ModelState.IsValid) { LoadEmployees(); return View(order); }
        _context.orders.Add(order); _context.SaveChanges(); return RedirectToAction(nameof(Index));
    }
    public IActionResult Details(int id) { var item = _context.orders.Include(o => o.Employee).FirstOrDefault(o => o.Id == id); return item == null ? NotFound() : View(item); }
    [HttpGet] public IActionResult Edit(int id) { var item = _context.orders.Find(id); if (item == null) return NotFound(); LoadEmployees(); return View(item); }
    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Order order)
    {
        if (id != order.Id) return NotFound();
        if (!ModelState.IsValid) { LoadEmployees(); return View(order); }
        _context.orders.Update(order); _context.SaveChanges(); return RedirectToAction(nameof(Index));
    }
    [HttpGet] public IActionResult Delete(int id) { var item = _context.orders.Include(o => o.Employee).FirstOrDefault(o => o.Id == id); return item == null ? NotFound() : View(item); }
    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var item = _context.orders.Find(id); if (item == null) return NotFound();
        _context.orders.Remove(item); _context.SaveChanges(); return RedirectToAction(nameof(Index));
    }
    private void LoadEmployees() => ViewBag.Employees = new SelectList(_context.employees, "Id", "FullName");
}
