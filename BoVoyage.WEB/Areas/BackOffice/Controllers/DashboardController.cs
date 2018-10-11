using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BoVoyage.BUSINESS.Services;
using BoVoyage.DAL.Data;
using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Areas.BackOffice.Models;
using BoVoyage.WEB.Models;


namespace BoVoyage.WEB.Areas.BackOffice.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ServiceTravel serviceTravel;
        public DashboardController()
        {
            this.serviceTravel = new ServiceTravel(new DbDataTravel());
        }
        // GET: BackOffice/Dashboard
        public ActionResult Index()
        {

            var model = new DashboardIndexViewModel();
            model.TravelsInLessthan15Days = serviceTravel.GetAllTravels().Where(x => x.DepartureDate < DateTime.Today.AddDays(15));
            //var travel = serviceTravel.GetAllTravels().Where(x => x.DepartureDate < (DateTime.Today.AddDays(15))).OrderBy(x => x.DepartureDate);
            var travel = serviceTravel.GetAllTravels(); //.Where(x => x.DepartureDate < (DateTime.Today.AddDays(15)));

            return View(model);
        }
    }
}