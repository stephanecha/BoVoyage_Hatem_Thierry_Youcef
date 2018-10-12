using System.Web.Mvc;

namespace BoVoyage.WEB.Controllers
{
	public class ReservationsController : Controller
	{
		// GET: Reservations/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Reservations/Create/6/8
		public ActionResult Create(int idCustomer, int idTravel)
		{
			return View();
		}

		// POST: Reservations/Create
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

		// GET: Reservations/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Reservations/Edit/5
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

		// GET: Reservations/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Reservations/Delete/5
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