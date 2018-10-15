using BoVoyage.BUSINESS.Services;
using BoVoyage.DAL.Data;
using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Areas.BackOffice.Controllers.Base;
using BoVoyage.WEB.Filters;
using BoVoyage.WEB.Models;
using BoVoyage.WEB.Tools;
using System;
using System.Web.Mvc;

namespace BoVoyage.WEB.Areas.BackOffice.Controllers
{
	[Authentication]
	public class TravelsController : BaseController
	{
		private readonly ServiceTravel serviceTravel;
		private readonly ServiceTravelAgency serviceTravelAgency;
		private readonly ServiceDestination serviceDestination;

		public TravelsController()
		{
			this.serviceTravel = new ServiceTravel(new DbDataTravel());
			this.serviceTravelAgency = new ServiceTravelAgency(new DbDataTravelAgency());
			this.serviceDestination = new ServiceDestination(new DbDataDestination());
		}

		// GET: BackOffice/Travels
		public ActionResult Index()
		{
			var travels = serviceTravel.GetAllTravelsWithDestinationAndAgencyIncluded();

			TravelIndexSearchViewModel travelViewModel = new TravelIndexSearchViewModel()
			{
				TravelViewModel = TransformModelTravel.TravelToModelView(travels)
			};

			return View(travelViewModel);
		}

		// GET: BackOffice/Travels/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: BackOffice/Travels/Create
		public ActionResult Create()
		{
			SelectList agenciesValues = new SelectList(this.serviceTravelAgency.GetAllTravelAgencies(), "ID", "Name");
			ViewBag.AgenciesValues = agenciesValues;
			SelectList destinationsValues = new SelectList(this.serviceDestination.GetAllDestinations(), "ID", "FullName");
			ViewBag.DestinationsValues = destinationsValues;
			return View();
		}

		// POST: BackOffice/Travels/Create
		[HttpPost]
		public ActionResult Create([Bind(Exclude = "ID")] TravelViewModel travelViewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					Travel travel = TransformModelTravel.TravelViewToModel(travelViewModel);
					this.serviceTravel.AddTravel(travel);
					Display("Le nouveau voyage a bien été enregistré !");
					return RedirectToAction("Index");
				}
				else
				{
					SelectList agenciesValues = new SelectList(this.serviceTravelAgency.GetAllTravelAgencies(), "ID", "Name");
					ViewBag.AgenciesValues = agenciesValues;
					SelectList destinationsValues = new SelectList(this.serviceDestination.GetAllDestinations(), "ID", "FullName");
					ViewBag.DestinationsValues = destinationsValues;
					return View(travelViewModel);
				}
				// TODO: Add insert logic here
			}
            catch(Exception E)
            {
                Display(E.Message, MessageType.ERROR);
                SelectList agenciesValues = new SelectList(this.serviceTravelAgency.GetAllTravelAgencies(), "ID", "Name");
                ViewBag.AgenciesValues = agenciesValues;
                SelectList destinationsValues = new SelectList(this.serviceDestination.GetAllDestinations(), "ID", "FullName");
                ViewBag.DestinationsValues = destinationsValues;
                return View();
            }
			catch
			{
				Display("Erreur !", MessageType.ERROR);
				SelectList agenciesValues = new SelectList(this.serviceTravelAgency.GetAllTravelAgencies(), "ID", "Name");
				ViewBag.AgenciesValues = agenciesValues;
				SelectList destinationsValues = new SelectList(this.serviceDestination.GetAllDestinations(), "ID", "FullName");
				ViewBag.DestinationsValues = destinationsValues;
				return View();
			}
        }

		// GET: BackOffice/Travels/Edit/5
		public ActionResult Edit(int id)
		{
			Travel travel = this.serviceTravel.GetTravel(id);
			if (travel == null)
				return HttpNotFound();
			TravelViewModel travelViewModel = TransformModelTravel.TravelToModelView(travel);

			SelectList agenciesValues = new SelectList(this.serviceTravelAgency.GetAllTravelAgencies(), "ID", "Name",
				this.serviceTravelAgency.GetTravelAgency(travel.TravelAgencyID));
			ViewBag.AgenciesValues = agenciesValues;
			SelectList destinationsValues = new SelectList(this.serviceDestination.GetAllDestinations(), "ID", "FullName",
				this.serviceDestination.GetDestination(travel.DestinationID));
			ViewBag.DestinationsValues = destinationsValues;

			return View(travelViewModel);
		}

		// POST: BackOffice/Travels/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, TravelViewModel travelViewModel)
		{
			try
			{
				if (travelViewModel == null)
					return HttpNotFound();
				if (id != travelViewModel.ID)
					return HttpNotFound();

				if (ModelState.IsValid)
				{
					Travel travel = TransformModelTravel.TravelViewToModel(travelViewModel);
					this.serviceTravel.UpdateTravel(travel);
					Display("Le voyage a bien été modifié !");
					return RedirectToAction("Index");
				}
				else
				{
					SelectList agenciesValues = new SelectList(this.serviceTravelAgency.GetAllTravelAgencies(), "ID", "Name",
						this.serviceTravelAgency.GetTravelAgency(travelViewModel.TravelAgencyID));
					ViewBag.AgenciesValues = agenciesValues;
					SelectList destinationsValues = new SelectList(this.serviceDestination.GetAllDestinations(), "ID", "FullName",
						this.serviceDestination.GetDestination(travelViewModel.DestinationID));
					ViewBag.DestinationsValues = destinationsValues;
					return View(travelViewModel);
				}
				// TODO: Add update logic here
			}
			catch
			{
				Display("Erreur !", MessageType.ERROR);
				SelectList agenciesValues = new SelectList(this.serviceTravelAgency.GetAllTravelAgencies(), "ID", "Name",
						this.serviceTravelAgency.GetTravelAgency(travelViewModel.TravelAgencyID));
				ViewBag.AgenciesValues = agenciesValues;
				SelectList destinationsValues = new SelectList(this.serviceDestination.GetAllDestinations(), "ID", "FullName",
					this.serviceDestination.GetDestination(travelViewModel.DestinationID));
				ViewBag.DestinationsValues = destinationsValues;
				return View();
			}
		}

		// GET: BackOffice/Travels/Delete/5
		public ActionResult Delete(int id)
		{
			Travel travel = this.serviceTravel.GetTravelWithDestinationAndAgencyIncluded(id);
			if (travel == null)
				return HttpNotFound();
			TravelViewModel travelViewModel = TransformModelTravel.TravelToModelView(travel);

			return View(travelViewModel);
		}

		// POST: BackOffice/Travels/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, TravelViewModel travelViewModel)
		{
			try
			{
				if (travelViewModel == null)
					return HttpNotFound();
				if (id != travelViewModel.ID)
					return HttpNotFound();

				// TODO: Add delete logic here
				this.serviceTravel.DeleteTravel(id);
				Display("Le voyage a bien été supprimé !");
				return RedirectToAction("Index");
			}
			catch
			{
				Display("Erreur !", MessageType.ERROR);
				return RedirectToAction("Index");
			}
		}
	}
}