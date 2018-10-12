using BoVoyage.BUSINESS.Services;
using BoVoyage.DAL.Data;
using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models;
using BoVoyage.WEB.Tools;
using System.Web.Mvc;

namespace BoVoyage.WEB.Controllers
{
	public class DestinationsController : Controller
	{
		private readonly ServiceDestination serviceDestination;

		public DestinationsController()
		{
			this.serviceDestination = new ServiceDestination(new DbDataDestination());
		}

		// GET: Destinations

		public ActionResult Index()
		{
			var destination = serviceDestination.GetAllDestinationsWithTravelsNotNull();

			var destinationViewModel = TransformModelDestination.DestinationToModelView(destination);

			return View(destinationViewModel);
		}

		// GET: Destinations/Details/5
		public ActionResult Details(int id)
		{
			Destination destination = this.serviceDestination.GetDestinationWithTravelsIncluded(id);
			if (destination == null)
				return HttpNotFound();

			DestinationViewModel destinationViewModel = TransformModelDestination.DestinationToModelView(destination);

			return View(destinationViewModel);
		}

		// GET: Destinations/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Destinations/Create
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

		// GET: Destinations/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Destinations/Edit/5
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

		// GET: Destinations/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Destinations/Delete/5
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