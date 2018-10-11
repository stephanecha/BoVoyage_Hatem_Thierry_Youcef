using BoVoyage.BUSINESS.Services;
using BoVoyage.DAL.Data;
using BoVoyage.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyage.WEB.Areas.BackOffice.Controllers
{
    public class TravelsController : Controller
    {
        private readonly ServiceTravel serviceTravel;

        public TravelsController()
        {
            this.serviceTravel = new ServiceTravel(new DbDataTravel());
        }
        // GET: BackOffice/Travels
        public ActionResult Index()
        {
            var model = new TravelIndexSearchViewModel();
            return View(model);
        }

        // GET: BackOffice/Travels/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BackOffice/Travels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Travels/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BackOffice/Travels/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BackOffice/Travels/Edit/5
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

        // GET: BackOffice/Travels/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BackOffice/Travels/Delete/5
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
