using BoVoyage.BUSINESS.Services;
using BoVoyage.DAL.Data;
using BoVoyage.WEB.Models;
using System.Web.Mvc;

namespace BoVoyage.WEB.Controllers
{
	public class HomeController : Controller
	{
		private readonly ServiceTravel serviceTravel;

		public HomeController()
		{
			this.serviceTravel = new ServiceTravel(new DbDataTravel());
		}

		public ActionResult Index()
		{
			ViewData["Title"] = "Accueil";

			HomeIndexThreeSetsTravelsViewModel model = new HomeIndexThreeSetsTravelsViewModel()
			{
				LessExpensiveTravels = this.serviceTravel.GetLessExpensiveTravels(5),
				SoonDepartureTravels = this.serviceTravel.GetSoonDepartureTravels(5)
			};

			return View(model);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}