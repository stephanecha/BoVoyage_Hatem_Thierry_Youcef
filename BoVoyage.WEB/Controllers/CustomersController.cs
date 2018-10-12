﻿using BoVoyage.BUSINESS.Services;
using BoVoyage.COMMON.Extensions;
using BoVoyage.DAL.Data;
using BoVoyage.DAL.Entites;
using BoVoyage.WEB.Areas.BackOffice.Controllers.Base;
using BoVoyage.WEB.Filters;
using BoVoyage.WEB.Models;
using BoVoyage.WEB.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyage.WEB.Controllers
{
    public class CustomersController : BaseController
    {
        private readonly ServiceCustomer serviceCustomer;


        public CustomersController()
        {
            this.serviceCustomer = new ServiceCustomer(new DbDataAuthentification(), new DbDataCustomer());
        }
        // GET: Customers
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: Customers/Details/5
        [Authentication(Type = "CUSTOMER")]
        public ActionResult Details()
        {
            CustomerViewModel customerViewModel = (CustomerViewModel)Session["CUSTOMER"];
            return View(customerViewModel);
        }

        // GET: Customers/Create
        public ActionResult Subscribe()
        {

            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        
        public ActionResult Subscribe([Bind(Exclude = "ID, AuthentificationID")] CustomerViewModel customerViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    var customer = TransformModelCustomer.CustomerModelViewToModel(customerViewModel);
                    customer.Authentification.Password = customer.Authentification.Password.GenerateSHA512String();

                    this.serviceCustomer.AddCustomer(customer.Authentification, customer);

                    Display("L'enregistrement est un succès");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(customerViewModel);
                }
                // TODO: Add insert logic here
            }
            catch
            {
                Display("Erreur !", MessageType.ERROR);
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customers/Edit/5
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

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customers/Delete/5
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
