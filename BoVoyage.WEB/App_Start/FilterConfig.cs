using System.Web;
using System.Web.Mvc;

namespace BoVoyage.WEB
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
