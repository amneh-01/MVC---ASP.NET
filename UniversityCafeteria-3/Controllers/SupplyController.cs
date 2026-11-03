using Microsoft.AspNetCore.Mvc;

namespace UniversityCafeteria_3.Controllers
{
    public class SupplyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Products()
        {
            string Title = "Cafeteria Products";
            string ManagerName = "Ahmad Ali";
            int numProducts = 5;
            List<string> product = new List<string> { "Drinks", "Food", "Snacks", "Hot Drinks", "Cold Drinks" };
            ;
            ViewData["data"] = Title ;
            ViewData["data2"] = ManagerName;
            ViewData["data3"] = numProducts; 


            return View();
        }
        public IActionResult Suppliers()
        {
            return View();
        }
        public IActionResult CreateRequest()
        {
            return View();
        }
        public IActionResult SubmitRequest()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
