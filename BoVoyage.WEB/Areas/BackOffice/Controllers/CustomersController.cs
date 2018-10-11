using BoVoyage.BUSINESS.Services;
using BoVoyage.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyage.WEB.Areas.BackOffice.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ServiceCustomer serviceCustomer;

        public CustomersController()
        {
            this.serviceCustomer = new ServiceCustomer(new DbDataAuthentification(), new DbDataCustomer());
        }

        // GET: BackOffice/Customers
        public ActionResult Index()
        {
            var customerIndex = serviceCustomer.GetAllCustomers();
            return View(customerIndex);
        }

        // GET: BackOffice/Customers/Details/5
        public ActionResult Details(int id)
        {
            var customerDetails = serviceCustomer.GetCustomer(id);
            return View(customerDetails);
        }

        // GET: BackOffice/Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Customers/Create
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
                return View(collection);
            }
        }

        // GET: BackOffice/Customers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BackOffice/Customers/Edit/5
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

        // GET: BackOffice/Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BackOffice/Customers/Delete/5
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
