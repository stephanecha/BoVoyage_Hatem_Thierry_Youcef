using BoVoyage.BUSINESS.Services;
using BoVoyage.COMMON.Extensions;
using BoVoyage.DAL.Data;
using BoVoyage.WEB.Controllers.Base;
using BoVoyage.WEB.Filters;
using BoVoyage.WEB.Models;
using BoVoyage.WEB.Tools;
using System.Web.Mvc;

namespace BoVoyage.WEB.Controllers
{
	public class CustomersController : BaseController
	{
		private readonly ServiceCustomer serviceCustomer;
		private readonly ServiceBookingFile serviceBookingFile;

		public CustomersController()
		{
			this.serviceCustomer = new ServiceCustomer(new DbDataAuthentification(), new DbDataCustomer());
			this.serviceBookingFile = new ServiceBookingFile(new DbDataBookingFile());
		}

		// GET: Customers/Create
		public ActionResult Subscribe()
		{
			return View();
		}

		// POST: Customers/Create
		[HttpPost]
		public ActionResult Subscribe([Bind(Exclude = "ID, AuthentificationID")] CustomerViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var customer = TransformModelCustomer.CustomerModelViewToModel(model);
					customer.Authentification.Password = customer.Authentification.Password.GenerateSHA512String();

					this.serviceCustomer.AddCustomer(customer.Authentification, customer);

					Display("L'enregistrement est un succès");
					return RedirectToAction("Index", "Home");
				}
				else
				{
					return View(model);
				}
				// TODO: Add insert logic here
			}
			catch
			{
				Display("Erreur !", MessageType.ERROR);
				return View();
			}
		}

		// GET: Customers/Details/5
		[Authentication(Type = "CUSTOMER")]
		public ActionResult Details()
		{
			CustomerViewModel customerViewModel = (CustomerViewModel)Session["CUSTOMER"];
			return View(customerViewModel);
		}

		// GET: Customers/Edit/5
		[Authentication(Type = "CUSTOMER")]
		public ActionResult Edit(int id)
		{
			var customer = (CustomerViewModel)Session["CUSTOMER"];
			if (customer.ID != id)
				return HttpNotFound();
			CustomerViewModel customerViewModel = customer;
			return View(customerViewModel);
		}

		// POST: Customers/Edit/5
		[HttpPost]
		[Authentication(Type = "CUSTOMER")]
		public ActionResult Edit(int id, CustomerViewModel model)
		{
			try
			{
				if (model == null || id != model.ID)
					return HttpNotFound();
				// TODO: Add update logic here

				if (ModelState.IsValid)
				{
					var customer = this.serviceCustomer.GetCustomerWithAuthentificationInclude(id);
					customer.Civility = model.Civility;
					customer.FirstName = model.FirstName;
					customer.LastName = model.LastName;
					customer.BirthDate = model.BirthDate;
					customer.Address = model.Address;
					customer.PhoneNumber = model.PhoneNumber;
					customer.Authentification.Password = model.Password;
					customer.Authentification.Password = model.Email;

					this.serviceCustomer.UpdateCustomer(customer);

					CustomerViewModel customerViewModel = TransformModelCustomer.CustomerToModelView(customer);
					Session["CUSTOMER"] = customerViewModel;
					Display("Les changements sont bien enregistrés");
					return RedirectToAction("details");
				}
				else
				{
					return View(model);
				}
			}
			catch
			{
				Display("Erreur !", MessageType.ERROR);
				return View();
			}
		}

		// GET: Customers/Create
		[Authentication(Type = "CUSTOMER")]
		public ActionResult Reservation()
		{
			CustomerViewModel customerViewModel = (CustomerViewModel)Session["CUSTOMER"];
			ViewBag.List = this.serviceBookingFile.GetAllBookingFilesWithTravelsAndDestinationsIncluded(customerViewModel.ID);
			return View();
		}
	}
}