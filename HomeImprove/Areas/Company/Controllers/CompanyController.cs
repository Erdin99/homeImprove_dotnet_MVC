using HomeImpr.DataAccess.Repository.IRepository;
using HomeImpr.Models;
using HomeImpr.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeImprove.Areas.Company.Controllers
{
	[Area("Company")]
	public class CompanyController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;

        public CompanyController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
			_unitOfWork = unitOfWork;
			_webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
		{
			string userName = User.Identity.GetUserName();
			List<Handyman> objHandymanCompanyList = _unitOfWork.Handyman.GetAllByUsername(u => u.CompanyEmail == userName, includeProperties: "Category").ToList();
			return View(objHandymanCompanyList);
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

				Handyman = new Handyman()
			};
			//create
			if (id == null || id == 0)
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
				if (file != null)
				{
					string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
					string handymanPath = Path.Combine(wwwRootPath, @"images\handyman");

					if (!string.IsNullOrEmpty(handymanVM.Handyman.ImageUrl))
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

				if (handymanVM.Handyman.Id == 0)
				{
					_unitOfWork.Handyman.Add(handymanVM.Handyman);
				}
				else
				{
					_unitOfWork.Handyman.Update(handymanVM.Handyman);
				}
				_unitOfWork.Save();
				TempData["success"] = "Handyman service is created successfully!";
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
		public IActionResult GetAllByUsername()
		{
			string userName = User.Identity.GetUserName();
			List<Handyman> objHandymanCompanyList = _unitOfWork.Handyman.GetAllByUsername(u => u.CompanyEmail == userName, includeProperties: "Category").ToList();
			return Json(new { data = objHandymanCompanyList });
		}

		[HttpDelete]
		public IActionResult Delete(int? id)
		{
			var handymanToBeDeleted = _unitOfWork.Handyman.Get(u => u.Id == id);
			if (handymanToBeDeleted == null)
			{
				return Json(new { success = false, message = "Error during deleting!" });
			}

			var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, handymanToBeDeleted.ImageUrl.TrimStart('\\'));

			if (System.IO.File.Exists(oldImagePath))
			{
				System.IO.File.Delete(oldImagePath);
			}

			_unitOfWork.Handyman.Remove(handymanToBeDeleted);
			_unitOfWork.Save();

			return Json(new { success = true, message = "Handyman service is deleted successfully!" });
		}

		#endregion
	}
}
