using HomeImprove.Data;
using HomeImprove.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeImprove.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Ime kategorije ne može biti isti kao redoslijed kategorije.");
            }
            if (ModelState.IsValid)
            {
				_db.Categories.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Index", "Category");
			}
            return View();
        }
    }
}
