using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P50_4_22.Models;
using System.Diagnostics;

namespace P50_4_22.Controllers
{
    public class HomeController : Controller
    {
        public PetStoreRpmContext db;

        public HomeController(PetStoreRpmContext context)
        {
            db = context;
        }
       
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Catalog()
        {
            return View(await db.CatalogProducts.ToListAsync());

        }
        public IActionResult Bucket()
        {
            return View();
        }
        public IActionResult Map()
        {
            return View();
        }
        public IActionResult Profile()
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
