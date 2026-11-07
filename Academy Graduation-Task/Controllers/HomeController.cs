using Academy_Graduation_Task.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace Academy_Graduation_Task.Controllers
{
    public class HomeController : Controller
    {
        private List<Offers> allOffers = new List<Offers>
        {
                // Category 1: Graduation Certificates (تم إضافة Id لكل عرض)
                new Offers { Id = 1, CategoryName = "Graduation Certificates", SupplierName = "Supplier A", OfferName = "Premium Certificate Package", Quantity = 35, UnitPrice = 2 },
                new Offers { Id = 2, CategoryName = "Graduation Certificates", SupplierName = "Supplier B", OfferName = "Standard Certificate Package", Quantity = 35, UnitPrice = 1.5m },
                new Offers { Id = 3, CategoryName = "Graduation Certificates", SupplierName = "Supplier C", OfferName = "Luxury Certificate Package", Quantity = 35, UnitPrice = 2.5m },

                // Category 2: Hospitality
                new Offers { Id = 4, CategoryName = "Hospitality", SupplierName = "Supplier D", OfferName = "Coffee & Drinks Package", Quantity = 100, UnitPrice = 2 },
                new Offers { Id = 5, CategoryName = "Hospitality", SupplierName = "Supplier E", OfferName = "Sandwiches & Snacks Package", Quantity = 100, UnitPrice = 3 },
                new Offers { Id = 6, CategoryName = "Hospitality", SupplierName = "Supplier F", OfferName = "Full Hospitality Package", Quantity = 100, UnitPrice = 4 },

                // Category 3: Graduation Gifts
                new Offers { Id = 7, CategoryName = "Graduation Gifts", SupplierName = "Supplier G", OfferName = "Customized Mugs Package", Quantity = 35, UnitPrice = 2 },
                new Offers { Id = 8, CategoryName = "Graduation Gifts", SupplierName = "Supplier H", OfferName = "Graduation Bags Package", Quantity = 35, UnitPrice = 3 },
                new Offers { Id = 9, CategoryName = "Graduation Gifts", SupplierName = "Supplier I", OfferName = "Premium Gift Boxes Package", Quantity = 35, UnitPrice = 4 }
        };

        [HttpGet]
        public IActionResult Index()
        {
            return View(allOffers);
        }

        [HttpPost]
        public IActionResult SaveSelections(int certOfferId, int hospitalityOfferId, int giftOfferId)
        {
            var cert = allOffers.FirstOrDefault(o => o.Id == certOfferId);
            var hospitality = allOffers.FirstOrDefault(o => o.Id == hospitalityOfferId);
            var gift = allOffers.FirstOrDefault(o => o.Id == giftOfferId);

            if (cert == null || hospitality == null || gift == null)
            {
                TempData["Error"] = "Please select valid offers!";
                return RedirectToAction("Index");
            }

            var selectedList = new List<Offers> { cert, hospitality, gift };

            string jsonOffers = JsonSerializer.Serialize(selectedList);
            HttpContext.Session.SetString("SelectedOffers", jsonOffers);

            return RedirectToAction("Review");
        }

        [HttpGet]
        public IActionResult Review()
        {
            string sessionData = HttpContext.Session.GetString("SelectedOffers");

            if (string.IsNullOrEmpty(sessionData))
            {
                TempData["Error"] = "Please select your offers first!";
                return RedirectToAction("Index");
            }

            var selectedOffers = JsonSerializer.Deserialize<List<Offers>>(sessionData);

            // الحسابات والخصومات الصحيحة 100%
            decimal subTotal = selectedOffers.Sum(o => o.TotalPrice);
            decimal discountPercentage = 0;

            if (subTotal > 500)
            {
                discountPercentage = 0.15m; // 15%
            }
            else if (subTotal > 300)
            {
                discountPercentage = 0.10m; // 10%
            }
            else
            {
                discountPercentage = 0;
            }

            decimal discountAmount = subTotal * discountPercentage;
            decimal finalTotal = subTotal - discountAmount;

            ViewBag.SubTotal = subTotal;
            ViewBag.DiscountPercentage = discountPercentage * 100;
            ViewBag.DiscountAmount = discountAmount;
            ViewBag.FinalTotal = finalTotal;

            return View(selectedOffers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}