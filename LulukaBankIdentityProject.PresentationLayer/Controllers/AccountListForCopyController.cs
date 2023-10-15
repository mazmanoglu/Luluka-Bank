﻿using LulukaBankIdentityProject.BusinessLayer.Abstract;
using LulukaBankIdentityProject.DataAccessLayer.Concrete;
using LulukaBankIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LulukaBankIdentityProject.PresentationLayer.Controllers
{
   public class AccountListForCopyController : Controller
   {
      private readonly UserManager<AppUser> _userManager;
      private readonly ICustomerAccountService _customerAccountService;

		public AccountListForCopyController(UserManager<AppUser> userManager, ICustomerAccountService customerAccountService)
		{
			_userManager = userManager;
			_customerAccountService = customerAccountService;
		}

		public async Task<IActionResult> Index()
      {
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			var context = new Context();

			var values = _customerAccountService.BGetCustomerAccountsList(user.Id);
			return View(values);
		}
   }
}
