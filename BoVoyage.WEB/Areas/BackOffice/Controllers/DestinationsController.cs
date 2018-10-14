using BoVoyage.BUSINESS.Services;
using BoVoyage.DAL.Data;
using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Areas.BackOffice.Controllers.Base;
using BoVoyage.WEB.Filters;
using BoVoyage.WEB.Models;
using BoVoyage.WEB.Tools;
using System.Web.Mvc;

namespace BoVoyage.WEB.Areas.BackOffice.Controllers
{
	[Authentication]
	public class DestinationsController : BaseController
	{
		private readonly ServiceDestination serviceDestination;

		public DestinationsController()
		{
			this.serviceDestination = new ServiceDestination(new DbDataDestination());
		}

		// GET: BackOffice/Destinations
		public ActionResult Index()
		{
			var destinationIndex = serviceDestination.GetAllDestinationsWithTravelsIncluded();
			var destinationsViewModel = TransformModelDestination.DestinationToModelView(destinationIndex);

			return View(destinationsViewModel);
		}

		// GET: BackOffice/Destinations/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: BackOffice/Destinations/Create
		[HttpPost]
		public ActionResult Create([Bind(Exclude = "ID")] DestinationViewModel destinationViewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					Destination destination = TransformModelDestination.DestinationModelViewToModel(destinationViewModel);
					this.serviceDestination.AddDestination(destination);
					Display("La nouvelle destination à bien été enregistrée !");
					return RedirectToAction("Index");
				}
				else
				{
					return View(destinationViewModel);
				}
				// TODO: Add insert logic here
			}
			catch
			{
				Display("Erreur !", MessageType.ERROR);
				return View();
			}
		}

		// GET: BackOffice/Destinations/Edit/5
		public ActionResult Edit(int id)
		{
			Destination destination = this.serviceDestination.GetDestination(id);
			if (destination == null)
				return HttpNotFound();
			DestinationViewModel destinationViewModel = TransformModelDestination.DestinationToModelView(destination);

			return View(destinationViewModel);
		}

		// POST: BackOffice/Destinations/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, DestinationViewModel destinationViewModel)
		{
			try
			{
				if (destinationViewModel == null)
					return HttpNotFound();
				if (id != destinationViewModel.ID)
					return HttpNotFound();

				if (ModelState.IsValid)
				{
					Destination destination = TransformModelDestination.DestinationModelViewToModel(destinationViewModel);
					this.serviceDestination.UpdateDestination(destination);
					Display("La destination à bien été modifiée !");
					return RedirectToAction("Index");
				}
				else
				{
					return View(destinationViewModel);
				}
				// TODO: Add insert logic here
			}
			catch
			{
				Display("Erreur !", MessageType.ERROR);
				return View();
			}
		}

		// GET: BackOffice/Destinations/Delete/5
		public ActionResult Delete(int id)
		{
			Destination destination = this.serviceDestination.GetDestination(id);
			if (destination == null)
				return HttpNotFound();

			DestinationViewModel destinationViewModel = TransformModelDestination.DestinationToModelView(destination);

			return View(destinationViewModel);
		}

		// POST: BackOffice/Destinations/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, DestinationViewModel destinationViewModel)
		{
			try
			{
				if (destinationViewModel == null)
					return HttpNotFound();
				if (id != destinationViewModel.ID)
					return HttpNotFound();

				// TODO: Add delete logic here
				this.serviceDestination.DeleteDestination(id);
				Display("La destination à bien été supprimée !");
				return RedirectToAction("Index");
			}
			catch
			{
				Display("Erreur !", MessageType.ERROR);
				return View();
			}
		}
	}
}