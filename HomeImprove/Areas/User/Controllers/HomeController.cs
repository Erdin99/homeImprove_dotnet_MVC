using HomeImpr.DataAccess.Repository.IRepository;
using HomeImpr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        public IActionResult Index()
        {
            IEnumerable<Handyman> handymanList = _unitOfWork.Handyman.GetAll(includeProperties:"Category");
            return View(handymanList);
        }

		public IActionResult Details(int id)
		{
			Handyman handyman = _unitOfWork.Handyman.Get(u=>u.Id==id, includeProperties: "Category");
			return View(handyman);
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