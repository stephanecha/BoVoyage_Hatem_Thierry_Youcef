using BoVoyage.BUSINESS.Services;
using BoVoyage.DAL.Data;
using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Models;
using BoVoyage.WEB.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyage.WEB.Areas.BackOffice.Controllers
{
    public class InsuranceController : Controller
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

            var assurance = serviceInsurance.GetAllInsurancesWithTypesIncluded();
            var assuranceViewModel = TransformModelToModelView.InsuranceToModelView(assurance);

            return View(assuranceViewModel);
        }

        // GET: BackOffice/Insurance/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BackOffice/Insurance/Create
        public ActionResult Create()
        {
           
            SelectList InsuranceTypesValues = new SelectList(serviceInsuranceType.GetAllInsuranceTypes(), "ID", "Type");
            ViewBag.types = InsuranceTypesValues;
            
            return View();
        }

        // POST: BackOffice/Insurance/Create
        [HttpPost]
        public ActionResult Create(InsuranceViewModel insuranceViewModel, int typeID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var insurance = new Insurance() {
                        Price = insuranceViewModel.Price,
                        Description = insuranceViewModel.Description,
                        InsuranceTypeID = typeID
                    };
                    this.serviceInsurance.AddInsurance(insurance);
                    return RedirectToAction("Index");

                }
                else
                    return View(insuranceViewModel);
                // TODO: Add insert logic here

            }
            catch
            {
                return View();
            }
        }

        // GET: BackOffice/Insurance/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BackOffice/Insurance/Edit/5
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

        // GET: BackOffice/Insurance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BackOffice/Insurance/Delete/5
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
