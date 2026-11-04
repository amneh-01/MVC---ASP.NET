using Microsoft.AspNetCore.Mvc;

namespace UniversityCafeteria_3.Controllers
{
    public class SupplyController : Controller
    {
        public IActionResult Index()
        {
            List<string> product = new List<string> {"Drinks", "Food", "Snacks", "Hot Drinks", "Cold Drinks" };
            ViewBag.Categories = product;
            return View();
        }
        public IActionResult Products()
        {
            string Title = "Cafeteria Products";
            string ManagerName = "Ahmad Ali";
            int numProducts = 5;
            string[] products = { "Water", "Orange Juice", "Coffee", "Sandwich", "Chocolate" };

            ViewData["data"] = Title ;
            ViewData["data2"] = ManagerName;
            ViewData["data3"] = numProducts;
            ViewData["ProductList"] = products;

            return View();
        }
        public IActionResult Suppliers()
        {
            string Title = "Our Suppliers";
            int numSuppliers = 3;
            string[] company = { "Fresh Food Company", "Happy Drinks Company" ,"Daily Supplies Company" };


            ViewBag.data1 = Title;
            ViewBag.data2 = numSuppliers;
            ViewBag.data3 = company;
            return View();
        }

        [HttpGet]
        public IActionResult CreateRequest()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SubmitRequest()
        {
            string employeeName = Request.Form["EmployeeName"];
            string productName = Request.Form["ProductName"];
            string quantity = Request.Form["Quantity"];
            string requiredDate = Request.Form["RequiredDate"];

            if (string.IsNullOrWhiteSpace(employeeName))
            {
                ViewBag.Error = "Employee name is required ";
                return View();
            }

            TempData["Message"] = $"Request by {employeeName} was submitted ";
            return RedirectToAction("About");
        
              
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
