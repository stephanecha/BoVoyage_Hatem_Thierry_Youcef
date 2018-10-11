using BoVoyage.BUSINESS.Services;
using BoVoyage.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyage.WEB.Models
{
    public class TravelsController : Controller
    {
        private readonly ServiceTravel serviceTravel;

        public TravelsController()
        {
            this.serviceTravel = new ServiceTravel(new DbDataTravel());
        }

        // GET: Travels
        public ActionResult Index()
        {
            var travels = serviceTravel.GetAllTravels();
            return View(travels);
        }

        // GET: Travels/Details/5
        public ActionResult Details(int id)
        {
            int travelsDetails = serviceTravel.GetTravel();
            return View(travelsDetails);
        }

        // GET: Travels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Travels/Create
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

        // GET: Travels/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Travels/Edit/5
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

        // GET: Travels/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Travels/Delete/5
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
