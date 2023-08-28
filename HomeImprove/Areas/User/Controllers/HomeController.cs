using HomeImpr.DataAccess.Repository.IRepository;
using HomeImpr.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using cloudscribe.Pagination.Models;
using HomeImpr.Models.ViewModels;
using System.Linq;

namespace HomeImprove.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
 
        public IActionResult Index(int pageNumber=1, int pageSize=3)
        {
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;
            IEnumerable<Handyman> handymanList = _unitOfWork.Handyman.GetAll(includeProperties: "Category").Skip(ExcludeRecords).Take(pageSize);

            int count = _unitOfWork.Handyman.GetNumberOfList();

			var result = new PagedResult<Handyman>
            {
                Data = handymanList.ToList(),
                TotalItems = count,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

			return View(result);
        }

        public IActionResult Details(int id)
		{
			Handyman handyman = _unitOfWork.Handyman.Get(u=>u.Id==id, includeProperties: "Category");
			return View(handyman);
		}

        public IActionResult Comments()
        {
            return View();
        }

		public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Contact()
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