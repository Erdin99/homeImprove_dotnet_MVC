using HomeImpr.DataAccess.Data;
using HomeImpr.DataAccess.Repository.IRepository;
using HomeImpr.Models;
using HomeImpr.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeImprove.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HandymanController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HandymanController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Handyman> objHandymanList = _unitOfWork.Handyman.GetAll(includeProperties:"Category").ToList();
            return View(objHandymanList);
        }

        public IActionResult UpsertHandyman(int? id)
        {
            HandymanVM handymanVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                
                Handyman= new Handyman()
            }; 
            //create
            if(id == null || id == 0)
            {
				return View(handymanVM);
			}
            //update
            else
            {
                handymanVM.Handyman = _unitOfWork.Handyman.Get(u => u.Id == id);
                return View(handymanVM);
            }
        }

        [HttpPost]
        public IActionResult UpsertHandyman(HandymanVM handymanVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string handymanPath = Path.Combine(wwwRootPath, @"images\handyman");

                    if(!string.IsNullOrEmpty(handymanVM.Handyman.ImageUrl))
                    {
                        //delete the old image
                        var oldImagePath = Path.Combine(wwwRootPath, handymanVM.Handyman.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(handymanPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    handymanVM.Handyman.ImageUrl = @"\images\handyman\" + fileName;
                }

                if(handymanVM.Handyman.Id == 0)
                {
					_unitOfWork.Handyman.Add(handymanVM.Handyman);
				}
                else
                {
                    _unitOfWork.Handyman.Update(handymanVM.Handyman);
                }
                _unitOfWork.Save();
                TempData["success"] = "Usluga majstora je kreirana uspješno!";
                return RedirectToAction("Index");
            }
            else
            {
				handymanVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
				return View(handymanVM);
			}
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Handyman> objHandymanList = _unitOfWork.Handyman.GetAll(includeProperties: "Category").ToList();
			return Json(new { data = objHandymanList });
        }

        [HttpDelete]
		public IActionResult Delete(int? id)
		{
            var handymanToBeDeleted = _unitOfWork.Handyman.Get(u => u.Id == id);
            if(handymanToBeDeleted == null)
            {
                return Json(new { success = false, message = "Greška prilikom brisanja!" });
            }

			var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, handymanToBeDeleted.ImageUrl.TrimStart('\\'));

			if (System.IO.File.Exists(oldImagePath))
			{
				System.IO.File.Delete(oldImagePath);
			}

            _unitOfWork.Handyman.Remove(handymanToBeDeleted);
            _unitOfWork.Save();

			return Json(new { success = true, message = "Uspješno brisanje!" });
		}


		#endregion
	}
}
