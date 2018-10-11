using BoVoyage.BUSINESS.Services;
using BoVoyage.DAL.Data;
using BoVoyage.DAL.Entites;
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
            var destinationIndex = serviceDestination.GetAllDestinations();
            return View(destinationIndex);
        }

        // GET: BackOffice/Destinations/Details/5
        public ActionResult Details(int id)
        {
            var destinationDetails = serviceDestination.GetDestination(id);
            return View(destinationDetails);
        }

        // GET: BackOffice/Destinations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Destinations/Create
        [HttpPost]
        public ActionResult Create(DestinationViewModel destinationViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var destinationCreatePost = new Destination() {
                        Continent = destinationViewModel.Continent,
                        Country = destinationViewModel.Country,
                        Area = destinationViewModel.Area,
                        City = destinationViewModel.City,
                        Description = destinationViewModel.Description 
                        };
                    this.serviceDestination.AddDestination(destinationCreatePost);
                    return RedirectToAction("Index");

                }
                else
                    return View(destinationViewModel);
                // TODO: Add insert logic here

            }
            catch
            {
                return View();
            }
        }

        // GET: BackOffice/Destinations/Edit/5
        public ActionResult Edit(int id)
        {
            //var destinationEdit = serviceDestination.UpdateDestination(id);
            return View();
        }

        // POST: BackOffice/Destinations/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                //var destinationEditCollection = serviceDestination.UpdateDestination(id,collection);
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
