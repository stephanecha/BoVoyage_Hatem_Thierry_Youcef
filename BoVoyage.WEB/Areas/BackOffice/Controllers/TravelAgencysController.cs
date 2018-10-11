using BoVoyage.BUSINESS.Services;
using BoVoyage.DAL.Data;
using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models;
using BoVoyage.WEB.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyage.WEB.Areas.BackOffice.Controllers
{
    public class TravelAgencysController : Controller
    {

        private readonly ServiceTravelAgency serviceTravelAgency;

        public TravelAgencysController()
        {
            this.serviceTravelAgency = new ServiceTravelAgency(new DbDataTravelAgency());
        }

        // GET: BackOffice/TravelAgencys
        public ActionResult Index()
        {
            var travelAgencyIndex = serviceTravelAgency.GetAllTravelAgencies();
            var travelAgencyViewModel = TransformModelToModelView.TravelAgencyToModelView(travelAgencyIndex);
            return View(travelAgencyViewModel);
        }

        // GET: BackOffice/TravelAgencys/Details/5
        public ActionResult Details(int id)
        {
            var travelAgencyDetails = serviceTravelAgency.GetTravelAgency(id);
            return View();
        }

        // GET: BackOffice/TravelAgencys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/TravelAgencys/Create
        [HttpPost]
        public ActionResult Create(TravelAgencyViewModel travelAgencyViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var travelAgency = new TravelAgency()
                    {//TODO a reprendre
                        Name = travelAgencyViewModel.Name
                        
                    };

                    this.serviceTravelAgency.AddTravelAgency(travelAgency);
                    return RedirectToAction("Index");
                }
                else
                    return View();
                // TODO: Add insert logic here

            }
            catch

            {
                return View();
            }
        }

        // GET: BackOffice/TravelAgencys/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BackOffice/TravelAgencys/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BackOffice/TravelAgencys/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BackOffice/TravelAgencys/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
