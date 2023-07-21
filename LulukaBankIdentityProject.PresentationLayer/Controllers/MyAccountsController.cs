using Microsoft.AspNetCore.Mvc;

namespace LulukaBankIdentityProject.PresentationLayer.Controllers
{
	public class MyAccountsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
