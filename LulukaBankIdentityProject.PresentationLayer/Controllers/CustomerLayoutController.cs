using Microsoft.AspNetCore.Mvc;

namespace LulukaBankIdentityProject.PresentationLayer.Controllers
{
   public class CustomerLayoutController : Controller
   {
      public IActionResult Index()
      {
         return View();
      }
   }
}
