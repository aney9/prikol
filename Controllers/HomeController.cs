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

        public async Task<IActionResult> AddProduct()
        {
            return View(await db.CatalogProducts.ToListAsync());
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

        //создание из лекции
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CatalogProduct cp)
        {
            db.CatalogProducts.Add(cp);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                CatalogProduct cp = await db.CatalogProducts.FirstOrDefaultAsync(p => p.IdCatalogproducts == id);
                if (cp != null)
                {
                    return View(cp);
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                CatalogProduct cp = await db.CatalogProducts.FirstOrDefaultAsync(p => p.IdCatalogproducts == id);
                if  (cp != null )
                {
                    return View(cp);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CatalogProduct cp)
        {
            db.CatalogProducts.Update(cp);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
			if (id != null)
			{
				CatalogProduct cp = await db.CatalogProducts.FirstOrDefaultAsync(p => p.IdCatalogproducts == id);
				if (cp != null)
				{
					return View(cp);
				}
			}
			return NotFound();
		}
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
			if (id != null)
			{
				CatalogProduct cp = await db.CatalogProducts.FirstOrDefaultAsync(p => p.IdCatalogproducts == id);
				if (cp != null)
				{
					db.CatalogProducts.Remove(cp);
					await db.SaveChangesAsync();
					return RedirectToAction("Index");
				}
			}
			return NotFound();
		}

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
