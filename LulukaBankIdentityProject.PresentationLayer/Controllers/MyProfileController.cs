using Microsoft.AspNetCore.Mvc;

namespace LulukaBankIdentityProject.PresentationLayer.Controllers
{
   public class MyProfileController : Controller
   {
      public IActionResult Index()
      {
         return View();
      }
   }
}
