using BoVoyage.BUSINESS.Services;
using BoVoyage.DAL.Data;
using BoVoyage.WEB.Filters;
using System.Web.Mvc;

namespace BoVoyage.WEB.Areas.BackOffice.Controllers
{
	[Authentication]
	public class DashboardController : Controller
	{
		private readonly ServiceTravel serviceTravel;

		public DashboardController()
		{
			this.serviceTravel = new ServiceTravel(new DbDataTravel());
		}

		// GET: BackOffice/Dashboard
		public ActionResult Index()
		{// TODO a reecrire
			//var model = new DashboardIndexViewModel();
			//model.TravelsInLessthan15Days = serviceTravel.GetAllTravels().Where(x => x.DepartureDate < DateTime.Today.AddDays(15));
			////var travel = serviceTravel.GetAllTravels().Where(x => x.DepartureDate < (DateTime.Today.AddDays(15))).OrderBy(x => x.DepartureDate);
			//var travel = serviceTravel.GetAllTravels(); //.Where(x => x.DepartureDate < (DateTime.Today.AddDays(15)));

			var voyages = serviceTravel.GetTravelsInLessThan15Days();

			return View(voyages);
		}
	}
}