using LulukaBankIdentityProject.DataTransferObjectLayer.DTOs.AppUserDTOs;
using LulukaBankIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LulukaBankIdentityProject.PresentationLayer.Controllers
{
   [Authorize] // make Login must
   public class MyAccountsController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

      public MyAccountsController(UserManager<AppUser> userManager)
      {
         _userManager = userManager;
      }

      [HttpGet]
      public async Task<IActionResult> Index()
		{
         var values = await _userManager.FindByNameAsync(User.Identity.Name);
         AppUserEditDTO appUserEditDTO = new AppUserEditDTO();
         appUserEditDTO.FirstName = values.FirstName;
         appUserEditDTO.LastName = values.LastName;
         appUserEditDTO.PhoneNumber = values.PhoneNumber;
         appUserEditDTO.Email = values.Email;
         appUserEditDTO.City = values.City;
         appUserEditDTO.District = values.District;
         appUserEditDTO.ImageURL = values.ImageUrl;
         
			return View(appUserEditDTO);
		}

      [HttpPost]
      public async Task<IActionResult> Index(AppUserEditDTO appUserEditDTO)
      {
         if (appUserEditDTO.Password == appUserEditDTO.ConfirmPassword)
         {
				var user = await _userManager.FindByNameAsync(User.Identity.Name);

				user.PhoneNumber = appUserEditDTO.PhoneNumber;
				user.LastName = appUserEditDTO.LastName;
				user.FirstName = appUserEditDTO.FirstName;
				user.City = appUserEditDTO.City;
				user.District = appUserEditDTO.District;
				user.Email = appUserEditDTO.Email;
				user.ImageUrl = "test";
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDTO.Password);

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
               return RedirectToAction("Index", "Login");
            }
			}
         return View();
      }

	}
}
