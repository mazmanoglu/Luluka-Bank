using Microsoft.AspNetCore.Mvc;

namespace LulukaBankIdentityProject.PresentationLayer.Controllers
{
	public class ElectricBillController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
