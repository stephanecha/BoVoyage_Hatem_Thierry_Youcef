using BoVoyage.BUSINESS.Services;
using BoVoyage.DAL.Data;
using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Areas.BackOffice.Controllers.Base;
using BoVoyage.WEB.Models;
using BoVoyage.WEB.Tools;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BoVoyage.WEB.Areas.BackOffice.Controllers
{
	public class InsuranceTypesController : BaseController
	{
		private readonly ServiceInsuranceType serviceInsuranceType;

		public InsuranceTypesController()
		{
			this.serviceInsuranceType = new ServiceInsuranceType(new DbDataInsuranceType());
		}

		// GET: BackOffice/InsuranceTypes
		public ActionResult Index()
		{
			IEnumerable<InsuranceType> allAssuranceTypes = serviceInsuranceType.GetAllInsuranceTypes();
			List<InsuranceTypeViewModel> allAssuranceTypesViewModel = TransformModelToModelView.InsuranceTypeToModelView(allAssuranceTypes);

			return View(allAssuranceTypesViewModel);
		}

		// GET: BackOffice/InsuranceTypes/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: BackOffice/InsuranceTypes/Create
		[HttpPost]
		public ActionResult Create(InsuranceTypeViewModel insuranceTypeViewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					InsuranceType insurancetype = TransformModelToModelView.InsuranceTypeModelViewToModel(insuranceTypeViewModel);
					this.serviceInsuranceType.AddInsuranceType(insurancetype);
					Display("Le nouveau type d'assurance a bien été enregistré !");
					return RedirectToAction("Index");
				}
				else
				{
					return View(insuranceTypeViewModel);
				}
				// TODO: Add insert logic here
			}
			catch
			{
				return View();
			}
		}

		// GET: BackOffice/InsuranceTypes/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: BackOffice/InsuranceTypes/Edit/5
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

		// GET: BackOffice/InsuranceTypes/Delete/5
		public ActionResult Delete(int id)
		{
			return View(this.serviceInsuranceType.GetInsuranceType(id));
		}

		// POST: BackOffice/InsuranceTypes/Delete/5
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