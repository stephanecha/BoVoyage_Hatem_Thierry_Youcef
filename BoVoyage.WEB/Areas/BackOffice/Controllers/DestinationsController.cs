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
    public class DestinationsController : Controller
    {
        private readonly ServiceDestination serviceDestination;
        public DestinationsController()
        {
            this.serviceDestination = new ServiceDestination(new DbDataDestination());
        }
        // GET: BackOffice/Destinations
        public ActionResult Index()
        {
            var destination = serviceDestination.GetAllDestinations();
            return View(destination);
        }

        // GET: BackOffice/Destinations/Details/5
        public ActionResult Details(int id)
        {
            //int detail = serviceDestination.Ge
            return View();
        }

        // GET: BackOffice/Destinations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Destinations/Create
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

        // GET: BackOffice/Destinations/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BackOffice/Destinations/Edit/5
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

        // GET: BackOffice/Destinations/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BackOffice/Destinations/Delete/5
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
