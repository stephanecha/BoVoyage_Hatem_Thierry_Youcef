using System;
using System.Web.Mvc;

namespace BoVoyage.WEB.Filters
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
	public class AuthenticationAttribute : ActionFilterAttribute
	{
		public string Type { get; set; } = "BO";

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (Type == "CUSTOMER")
			{
				if (filterContext.HttpContext.Session["CUSTOMER"] == null)
				{
					filterContext.Controller.TempData["REDIRECT"] = filterContext.HttpContext.Request.Url.AbsoluteUri;
					filterContext.Result = new RedirectResult(@"\home\index");
				}
			}
			if (Type == "BO")
			{
				if (filterContext.HttpContext.Session["SALESMANAGER"] == null)
				{
					filterContext.Result = new RedirectResult(@"\backoffice\authentication\login");
				}
			}
		}
	}
}