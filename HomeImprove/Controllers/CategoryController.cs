
using HomeImpr.DataAccess.Data;
using HomeImpr.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeImpr.Controllers
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
				TempData["success"] = "Kategorija je kreirana uspješno!";
				return RedirectToAction("Index");
			}
            return View();
        }

		public IActionResult EditCategory(int? id)
		{
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }

			return View(categoryFromDb);
		}

		[HttpPost]
		public IActionResult EditCategory(Category obj)
		{
			if (obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("name", "Ime kategorije ne može biti isti kao redoslijed kategorije.");
			}
			if (ModelState.IsValid)
			{
				_db.Categories.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "Kategorija je uređena uspješno!";
				return RedirectToAction("Index");
			}
			return View();
		}

		public IActionResult DeleteCategory(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category? categoryFromDb = _db.Categories.Find(id);
			if (categoryFromDb == null)
			{
				return NotFound();
			}

			return View(categoryFromDb);
		}

		[HttpPost, ActionName("DeleteCategory")]
		public IActionResult DeleteCategoryPOST(int? id)
		{
			Category? obj = _db.Categories.Find(id);
			if(obj == null)
			{
				return NotFound();
			}
			_db.Categories.Remove(obj);
			_db.SaveChanges();
			TempData["success"] = "Kategorija je izbrisana uspješno!";
			return RedirectToAction("Index");
		}
	}
}
