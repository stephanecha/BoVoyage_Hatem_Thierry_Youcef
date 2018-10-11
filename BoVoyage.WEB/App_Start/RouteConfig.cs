using System.Web.Mvc;
using System.Web.Routing;

namespace BoVoyage.WEB
{
	public static class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute( //récriture d'url en mapping (tjrslaisser l'url par defaut a la fin)
                name: "AboutRoute",
                url: "liste-destination",
                defaults: new { controller = "Destinations", action = "Index" }
                );

            routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}