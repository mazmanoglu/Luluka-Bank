using Microsoft.AspNetCore.Mvc;

namespace LulukaBankIdentityProject.PresentationLayer.Controllers
{
   public class MyLastTransactionsController : Controller
   {
      public IActionResult Index()
      {
         return View();
      }
   }
}
