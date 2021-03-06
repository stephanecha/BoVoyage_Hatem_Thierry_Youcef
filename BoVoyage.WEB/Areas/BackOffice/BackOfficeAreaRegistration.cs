﻿using System.Web.Mvc;

namespace BoVoyage.WEB.Areas.BackOffice
{
	public class BackOfficeAreaRegistration : AreaRegistration
	{
		public override string AreaName
		{
			get
			{
				return "BackOffice";
			}
		}

		public override void RegisterArea(AreaRegistrationContext context)
		{
			context.MapRoute(
				"BackOffice_default",
				"BackOffice/{controller}/{action}/{id}",
				new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "BoVoyage.WEB.Areas.BackOffice.Controllers" }
            );
		}
	}
}