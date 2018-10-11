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
			IEnumerable<InsuranceType> allAssuranceTypes = serviceInsuranceType.GetAllInsuranceTypesWithInsurancesIncluded();
			List<InsuranceTypeViewModel> allAssuranceTypesViewModel = TransformModelToModelView.InsuranceTypeToModelView(allAssuranceTypes);

			return View(allAssuranceTypesViewModel);
		}

		// GET: BackOffice/InsuranceTypes/Create
		public ActionResult Create()
		{
			InsuranceTypeViewModel insuranceTypeViewModel = new InsuranceTypeViewModel();
			return View(insuranceTypeViewModel);
		}

		// POST: BackOffice/InsuranceTypes/Create
		[HttpPost]
		public ActionResult Create([Bind(Exclude = "ID")] InsuranceTypeViewModel insuranceTypeViewModel)
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
				Display("Erreur !", MessageType.ERROR);
				return View();
			}
		}

		// GET: BackOffice/InsuranceTypes/Edit/5
		public ActionResult Edit(int id)
		{
			InsuranceType insuranceType = this.serviceInsuranceType.GetInsuranceType(id);
			if (insuranceType == null)
			{
				return HttpNotFound();
			}
			InsuranceTypeViewModel insuranceTypeViewModel = TransformModelToModelView.InsuranceTypeToModelView(insuranceType);
			return View(insuranceTypeViewModel);
		}

		// POST: BackOffice/InsuranceTypes/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, InsuranceTypeViewModel insuranceTypeViewModel)
		{
			try
			{
				if (insuranceTypeViewModel == null)
					return HttpNotFound();
				if (id != insuranceTypeViewModel.ID)
				{
					Display("Erreur !", MessageType.ERROR);
					return View();
				}

				InsuranceType insuranceType = TransformModelToModelView.InsuranceTypeModelViewToModel(insuranceTypeViewModel);
				this.serviceInsuranceType.UpdateInsuranceType(insuranceType);
				Display("Le type d'assurance a bien été modifié !");
				return RedirectToAction("Index");

				// TODO: Add update logic here
			}
			catch
			{
				Display("Erreur !", MessageType.ERROR);
				return View();
			}
		}

		// GET: BackOffice/InsuranceTypes/Delete/5
		public ActionResult Delete(int id)
		{
			InsuranceType insuranceType = this.serviceInsuranceType.GetInsuranceType(id);
			if (insuranceType == null)
			{
				return HttpNotFound();
			}

			InsuranceTypeViewModel insuranceTypeViewModel = TransformModelToModelView.InsuranceTypeToModelView(insuranceType);
			return View(insuranceTypeViewModel);
		}

		// POST: BackOffice/InsuranceTypes/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, InsuranceTypeViewModel insuranceTypeViewModel)
		{
			try
			{
				if (insuranceTypeViewModel == null)
					return HttpNotFound();
				if (id != insuranceTypeViewModel.ID)
				{
					Display("Erreur !", MessageType.ERROR);
					return View();
				}
				// TODO: Add delete logic here
				this.serviceInsuranceType.DeleteInsuranceType(id);
				Display("Le nouveau type d'assurance a bien été supprimé !");
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