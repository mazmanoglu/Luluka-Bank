using LulukaBankIdentityProject.DataTransferObjectLayer.DTOs.AppUserDTOs;
using LulukaBankIdentityProject.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

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
				Random random = new Random();
				int confirmCode = random.Next(100000, 1000000);
				AppUser appUser = new AppUser()
				{
					UserName = appUserRegisterDTO.Username,
					FirstName = appUserRegisterDTO.FirstName,
					LastName = appUserRegisterDTO.LastName,
					Email = appUserRegisterDTO.Email,
					City = "Leuven",
					District = "Oost Brabant",
					ImageUrl = "Pic",
					ConfirmCode = confirmCode
				};
				var result = await _userManager.CreateAsync(appUser, appUserRegisterDTO.Password);
				if (result.Succeeded)
				{
					MimeMessage mimeMessage = new MimeMessage();
					MailboxAddress mailboxAddressFrom = new MailboxAddress("Luluka Bank Admin","oyuncuhesabi8888@gmail.com");
					MailboxAddress mailboxAddressTo = new MailboxAddress("User",appUser.Email);
					mimeMessage.From.Add(mailboxAddressFrom);
					mimeMessage.To.Add(mailboxAddressTo);

					var bodyBuilder = new BodyBuilder();
					bodyBuilder.TextBody = "Your confirmation code to complete the registration process: "+confirmCode;
					mimeMessage.Body = bodyBuilder.ToMessageBody();
					mimeMessage.Subject = "Luluka Bank Confirmation Code";

					SmtpClient client = new SmtpClient();
					client.Connect("smtp.gmail.com",587,false);
					client.Authenticate("oyuncuhesabi8888@gmail.com", "yrmjncvvtxujtsbj"); //google account - application passwords
					client.Send(mimeMessage);
					client.Disconnect(true);


					TempData["Mail"] = appUserRegisterDTO.Email;

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

// added mailkit nuget package to send confirm code as mail
