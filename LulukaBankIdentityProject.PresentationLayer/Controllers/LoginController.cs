using LulukaBankIdentityProject.EntityLayer.Concrete;
using LulukaBankIdentityProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LulukaBankIdentityProject.PresentationLayer.Controllers
{
   public class LoginController : Controller
   {
      private readonly SignInManager<AppUser> _signInManager;
      private readonly UserManager<AppUser> _userManager;

      public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
      {
         _signInManager = signInManager;
         _userManager = userManager;
      }

      [HttpGet]
      public IActionResult Index()
      {
         return View();
      }

      [HttpPost]
      public async Task<IActionResult> Index(LoginViewModel loginViewModel)
      {
         var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, false, true);
         // ispersisten --> false / no need to remember the passwords
         // lockoutonfailure --> lock the account if sign in fails
         if (result.Succeeded)
         {
            var user = await _userManager.FindByNameAsync(loginViewModel.Username);
            if (user.EmailConfirmed == true)
            {
               return RedirectToAction("Index", "MyAccounts");
            }
            // we will write otherwise situations later like --> else = please confirm your email
         }
         // username or password is incorrect
         // write always both, because if you say spesifically what incorrect is, it makes your code weak.
         return View();
      }
   }
}
