﻿using Microsoft.AspNetCore.Mvc;

namespace LulukaBankIdentityProject.PresentationLayer.ViewComponents.Customer
{
   public class _CustomerLayoutScriptPartial:ViewComponent
   {
      public IViewComponentResult Invoke()
      {
         return View();
      }
   }
}
