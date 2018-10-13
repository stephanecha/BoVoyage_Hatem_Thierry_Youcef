using BoVoyage.WEB.Tools;
using System.Web.Mvc;

namespace BoVoyage.WEB.Controllers.Base
{
	public abstract class BaseController : Controller
	{
		protected void Display(string text, MessageType messageType = MessageType.SUCCESS)
		{
			Message m = new Message(text, messageType);
			TempData["MESSAGE"] = m;
		}
	}
}