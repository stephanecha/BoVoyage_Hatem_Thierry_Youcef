using BoVoyage.BUSINESS.Services;
using BoVoyage.COMMON.Extensions;
using BoVoyage.DAL.Data;
using BoVoyage.WEB.Areas.BackOffice.Controllers.Base;
using BoVoyage.WEB.Filters;
using BoVoyage.WEB.Models;
using BoVoyage.WEB.Tools;
using System.Web.Mvc;

namespace BoVoyage.WEB.Areas.BackOffice.Controllers
{
	public class AuthenticationController : BaseController
	{
		private readonly ServiceSalesManager serviceSalesManager;

		public AuthenticationController()
		{
			this.serviceSalesManager = new ServiceSalesManager(new DbDataAuthentification(), new DbDataSalesManager());
		}

		// GET: BackOffice/Authentication
		public ActionResult Login()
		{
			return View();
		}

		// POST: BackOffice/Authentication
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(AuthenticationLoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var hash = model.Password.GenerateSHA512String();
				var salesManager = this.serviceSalesManager.GetSalesManagerWithAuthentificationInclude(model.Mail, hash);

				if (salesManager == null)
				{
					Display("Login / mot de passe invalide", MessageType.ERROR);
					return View();
				}
				else
				{
					SalesManagerViewModel salesManagerViewModel = TransformModelSalesManager.SalesManagerToModelView(salesManager);
					Session["SALESMANAGER"] = salesManagerViewModel;
					return RedirectToAction("Index", "Dashboard", new { area = "backoffice" });
				}
			}
			return View();
		}

		[Authentication]
		public ActionResult Logout()
		{
			Session.Remove("SALESMANAGER");
			return RedirectToAction("index", "home", new { area = "" });
		}
	}
}