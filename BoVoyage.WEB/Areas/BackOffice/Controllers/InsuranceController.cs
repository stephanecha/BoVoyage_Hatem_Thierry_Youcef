using BoVoyage.BUSINESS.Services;
using BoVoyage.DAL.Data;
using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Areas.BackOffice.Controllers.Base;
using BoVoyage.WEB.Models;
using BoVoyage.WEB.Tools;
using System.Web.Mvc;

namespace BoVoyage.WEB.Areas.BackOffice.Controllers
{
	public class InsuranceController : BaseController
	{
		private readonly ServiceInsurance serviceInsurance;
		private readonly ServiceInsuranceType serviceInsuranceType;

		public InsuranceController()
		{
			this.serviceInsurance = new ServiceInsurance(new DbDataInsurance());
			this.serviceInsuranceType = new ServiceInsuranceType(new DbDataInsuranceType());
		}

		// GET: BackOffice/Insurance
		public ActionResult Index()
		{
			var assurance = serviceInsurance.GetAllInsurancesWithTypesAndBookingFilesIncluded();
			var assuranceViewModel = TransformModelInsurance.InsuranceToModelView(assurance);

			return View(assuranceViewModel);
		}

		// GET: BackOffice/Insurance/Create
		public ActionResult Create()
		{
			SelectList insuranceTypesValues = new SelectList(serviceInsuranceType.GetAllInsuranceTypes(), "ID", "Type");
			ViewBag.Types = insuranceTypesValues;

			return View();
		}

		// POST: BackOffice/Insurance/Create
		[HttpPost]
		public ActionResult Create([Bind(Exclude = "ID")] InsuranceViewModel insuranceViewModel, int InsuranceTypeID)
		{
			try
			{
				if (ModelState.IsValid)
				{
					Insurance insurance = TransformModelInsurance.InsuranceModelViewToModel(insuranceViewModel);
					this.serviceInsurance.AddInsurance(insurance);
					Display("Le nouveau type d'assurance a bien été enregistré !");
					return RedirectToAction("Index");
				}
				else
				{
					SelectList insuranceTypesValues = new SelectList(this.serviceInsuranceType.GetAllInsuranceTypes(), "ID", "Type",
						insuranceViewModel.InsuranceType);
					ViewBag.Types = insuranceTypesValues;
					return View(insuranceViewModel);
				}
				// TODO: Add insert logic here
			}
			catch
			{
				Display("Erreur !", MessageType.ERROR);
				SelectList insuranceTypesValues = new SelectList(this.serviceInsuranceType.GetAllInsuranceTypes(), "ID", "Type");
				ViewBag.Types = insuranceTypesValues;
				return View();
			}
		}

		// GET: BackOffice/Insurance/Edit/5
		public ActionResult Edit(int id)
		{
			Insurance insurance = this.serviceInsurance.GetInsurance(id);
			if (insurance == null)
				return HttpNotFound();
			InsuranceViewModel insuranceViewModel = TransformModelInsurance.InsuranceToModelView(insurance);

			SelectList insuranceTypesValues = new SelectList(this.serviceInsuranceType.GetAllInsuranceTypes(), "ID", "Type",
				this.serviceInsuranceType.GetInsuranceType(insurance.InsuranceTypeID));
			ViewBag.Types = insuranceTypesValues;

			return View(insuranceViewModel);
		}

		// POST: BackOffice/Insurance/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, InsuranceViewModel insuranceViewModel, int InsuranceTypeID)
		{
			try
			{
				if (insuranceViewModel == null)
					return HttpNotFound();
				if (id != insuranceViewModel.ID)
					return HttpNotFound();

				if (ModelState.IsValid)
				{
					Insurance insurance = TransformModelInsurance.InsuranceModelViewToModel(insuranceViewModel);
					this.serviceInsurance.UpdateInsurance(insurance);
					Display("Le type d'assurance a bien été modifié !");
					return RedirectToAction("Index");
				}
				else
				{
					SelectList insuranceTypesValues = new SelectList(this.serviceInsuranceType.GetAllInsuranceTypes(), "ID", "Type",
						insuranceViewModel.InsuranceTypeID);
					ViewBag.Types = insuranceTypesValues;
					return View(insuranceViewModel);
				}
				// TODO: Add update logic here
			}
			catch
			{
				Display("Erreur !", MessageType.ERROR);
				SelectList insuranceTypesValues = new SelectList(this.serviceInsuranceType.GetAllInsuranceTypes(), "ID", "Type",
					insuranceViewModel.InsuranceTypeID);
				ViewBag.Types = insuranceTypesValues;
				return View();
			}
		}

		// GET: BackOffice/Insurance/Delete/5
		public ActionResult Delete(int id)
		{
			Insurance insurance = this.serviceInsurance.GetInsuranceWithTypesIncluded(id);
			if (insurance == null)
				return HttpNotFound();

			InsuranceViewModel insuranceViewModel = TransformModelInsurance.InsuranceToModelView(insurance);
			return View(insuranceViewModel);
		}

		// POST: BackOffice/Insurance/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, InsuranceViewModel insuranceViewModel)
		{
			try
			{
				if (insuranceViewModel == null)
					return HttpNotFound();
				if (id != insuranceViewModel.ID)
					return HttpNotFound();

				// TODO: Add delete logic here
				this.serviceInsurance.DeleteInsurance(id);
				Display("L'assurance a bien été supprimé !");
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