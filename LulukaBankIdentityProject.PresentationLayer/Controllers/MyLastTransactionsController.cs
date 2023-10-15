using LulukaBankIdentityProject.BusinessLayer.Abstract;
using LulukaBankIdentityProject.DataAccessLayer.Concrete;
using LulukaBankIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LulukaBankIdentityProject.PresentationLayer.Controllers
{
   public class MyLastTransactionsController : Controller
   {
      private readonly UserManager<AppUser> _userManager;
      private readonly ICustomerAccountTransactionService _customerAccountTransactionService;

      public MyLastTransactionsController(UserManager<AppUser> userManager, ICustomerAccountTransactionService customerAccountTransactionService)
      {
         _userManager = userManager;
         _customerAccountTransactionService = customerAccountTransactionService;
      }

      public async Task<IActionResult> Index()
      {
         var user = await _userManager.FindByNameAsync(User.Identity.Name);
         var context = new Context();
         int id = context.CustomerAccounts.Where(x => x.AppUserID == user.Id && x.CustomerAccountCurrency == "Euro").Select(y => y.CustomerAccountID).FirstOrDefault();
         var values = _customerAccountTransactionService.BMyLastTransaction(id);
         return View(values);
      }
   }
}
