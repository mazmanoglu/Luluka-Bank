using LulukaBankIdentityProject.DataTransferObjectLayer.DTOs.AppUserDTOs;
using LulukaBankIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LulukaBankIdentityProject.PresentationLayer.Controllers
{
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Index()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(AppUserRegisterDTO appUserRegisterDTO)
		{
			if (ModelState.IsValid)
			{
				AppUser appUser = new AppUser()
				{
					UserName = appUserRegisterDTO.Username,
					FirstName = appUserRegisterDTO.FirstName,
					LastName = appUserRegisterDTO.LastName,
					Email = appUserRegisterDTO.Email,
					City = "Leuven",
					District = "Oost Brabant",
					ImageUrl = "Pic"
				};
				var result = await _userManager.CreateAsync(appUser, appUserRegisterDTO.Password);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "ConfirmMail");
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View();
		}
	}
}

// password must have at least 6 characters
// password must have at least 1 lowercase
// password must have at least 1 uppercase
// password must have at least 1 symbol
// password must have at least 1 number
