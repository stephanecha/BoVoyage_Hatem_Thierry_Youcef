using BoVoyage.BUSINESS.Services;
using BoVoyage.COMMON.Extensions;
using BoVoyage.DAL.Data;
using BoVoyage.WEB.Controllers.Base;
using BoVoyage.WEB.Models;
using BoVoyage.WEB.Tools;
using System.Web.Mvc;

namespace BoVoyage.WEB.Controllers
{
	public class AuthentificationController : BaseController
	{
		private readonly ServiceCustomer serviceCustomer;

		public AuthentificationController()
		{
			this.serviceCustomer = new ServiceCustomer(new DbDataAuthentification(), new DbDataCustomer());
		}

		// GET: Authentification
		public ActionResult Index()
		{
			return View();
		}

		// GET: Authentification/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// POST: Authentification/Create
		[HttpPost]
		// [ValidateAntiForgeryToken]
		public ActionResult Login(AuthenticationLoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var hash = model.Password.GenerateSHA512String();

				var customer = this.serviceCustomer.GetCustomersWithAuthentificationInclude(model.Mail, hash);

				if (customer == null)
				{
					Display("Login / mot de passe invalide", MessageType.ERROR);
					return RedirectToAction("index", "home");
				}
				else
				{
					CustomerViewModel customerViewModel = TransformModelCustomer.CustomerToModelView(customer);
					Session["CUSTOMER"] = customerViewModel;

					if (TempData["REDIRECT"] != null)
						return Redirect(TempData["REDIRECT"].ToString());
					else
						return RedirectToAction("index", "home");
				}
			}
			return View();
		}

		// GET: Authentification/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Authentification/Edit/5
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

		// GET: Authentification/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Authentification/Delete/5
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