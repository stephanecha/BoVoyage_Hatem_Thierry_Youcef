﻿using BoVoyage.BUSINESS.Services;
using BoVoyage.DAL.Data;
using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Areas.BackOffice.Controllers.Base;
using BoVoyage.WEB.Models;
using BoVoyage.WEB.Tools;
using System.Web.Mvc;

namespace BoVoyage.WEB.Areas.BackOffice.Controllers
{
	public class TravelAgencysController : BaseController
	{
		private readonly ServiceTravelAgency serviceTravelAgency;

		public TravelAgencysController()
		{
			this.serviceTravelAgency = new ServiceTravelAgency(new DbDataTravelAgency());
		}

		// GET: BackOffice/TravelAgencys
		public ActionResult Index()
		{
			var travelAgencyIndex = serviceTravelAgency.GetAllTravelAgenciesIncludeTravels();
			var travelAgencyViewModel = TransformModelToModelView.TravelAgencyToModelView(travelAgencyIndex);
			return View(travelAgencyViewModel);
		}

		// GET: BackOffice/TravelAgencys/Create
		public ActionResult Create()
		{
			TravelAgencyViewModel travelAgencyViewModel = new TravelAgencyViewModel();
			return View(travelAgencyViewModel);
		}

		// POST: BackOffice/TravelAgencys/Create
		[HttpPost]
		public ActionResult Create([Bind(Exclude = "ID")] TravelAgencyViewModel travelAgencyViewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					TravelAgency travelAgency = TransformModelToModelView.TravelAgencyModelViewToModel(travelAgencyViewModel);
					this.serviceTravelAgency.AddTravelAgency(travelAgency);
					Display("Le nouveau type d'assurance a bien été enregistré !");
					return RedirectToAction("Index");
				}
				else
				{
					return View(travelAgencyViewModel);
				}
				// TODO: Add insert logic here
			}
			catch
			{
				Display("Erreur !", MessageType.ERROR);
				return View();
			}
		}

		// GET: BackOffice/TravelAgencys/Edit/5
		public ActionResult Edit(int id)
		{
			TravelAgency travelAgency = this.serviceTravelAgency.GetTravelAgency(id);
			if (travelAgency == null)
				return HttpNotFound();

			TravelAgencyViewModel travelAgencyViewModel = TransformModelToModelView.TravelAgencyToModelView(travelAgency);
			return View(travelAgencyViewModel);
		}

		// POST: BackOffice/TravelAgencys/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, TravelAgencyViewModel travelAgencyViewModel)
		{
			try
			{
				if (travelAgencyViewModel == null)
					return HttpNotFound();
				if (id != travelAgencyViewModel.ID)
				{
					Display("Erreur !", MessageType.ERROR);
					return View();
				}

				TravelAgency travelAgency = TransformModelToModelView.TravelAgencyModelViewToModel(travelAgencyViewModel);
				this.serviceTravelAgency.UpdateTravelAgency(travelAgency);
				Display("L'agence de voyage a bien été modifié !");
				return RedirectToAction("Index");

				// TODO: Add update logic here
			}
			catch
			{
				Display("Erreur !", MessageType.ERROR);
				return View();
			}
		}

		// GET: BackOffice/TravelAgencys/Delete/5
		public ActionResult Delete(int id)
		{
			TravelAgency travelAgency = this.serviceTravelAgency.GetTravelAgency(id);
			if (travelAgency == null)
				return HttpNotFound();

			TravelAgencyViewModel travelAgencyViewModel = TransformModelToModelView.TravelAgencyToModelView(travelAgency);
			return View(travelAgencyViewModel);
		}

		// POST: BackOffice/TravelAgencys/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, TravelAgencyViewModel travelAgencyViewModel)
		{
			try
			{
				if (travelAgencyViewModel == null)
					return HttpNotFound();
				if (id != travelAgencyViewModel.ID)
				{
					Display("Erreur !", MessageType.ERROR);
					return View();
				}

				this.serviceTravelAgency.DeleteTravelAgency(id);
				Display("L'agence de voyage a bien été supprimé !");
				return RedirectToAction("Index");

				// TODO: Add update logic here
			}
			catch
			{
				Display("Erreur !", MessageType.ERROR);
				return RedirectToAction("Index");
			}
		}
	}
}