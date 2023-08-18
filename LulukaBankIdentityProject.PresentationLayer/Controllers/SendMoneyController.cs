using LulukaBankIdentityProject.BusinessLayer.Abstract;
using LulukaBankIdentityProject.DataAccessLayer.Concrete;
using LulukaBankIdentityProject.DataTransferObjectLayer.DTOs.CustomerAccountTransactionDTOs;
using LulukaBankIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LulukaBankIdentityProject.PresentationLayer.Controllers
{
	public class SendMoneyController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly ICustomerAccountTransactionService _customerAccountTransactionService;


      public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountTransactionService customerAccountTransactionService)
      {
         _userManager = userManager;
         _customerAccountTransactionService = customerAccountTransactionService;
      }

		[HttpGet]
		public IActionResult Index(string mycurrency)
		{
			ViewBag.currency = mycurrency;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDTO sendMoneyForCustomerAccountProcessDTO) 
		{
			var context = new Context();

			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			var receiverAccountNumberID = context.CustomerAccounts
				.Where(x => x.CustomerAccountNumber == sendMoneyForCustomerAccountProcessDTO.ReceiverAccountNumber)
				.Select(y => y.CustomerAccountID)
				.FirstOrDefault();

			//sendMoneyForCustomerAccountProcessDTO.SenderID = user.Id;
			//sendMoneyForCustomerAccountProcessDTO.TransactionDate = DateTime.Now;
			////sendMoneyForCustomerAccountProcessDTO.TransactionDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			//sendMoneyForCustomerAccountProcessDTO.TransactionType = "Transfer";
			//sendMoneyForCustomerAccountProcessDTO.ReceiverID = receiverAccountNumberID;

			var senderAccountNumberID = context.CustomerAccounts
				.Where(x => x.AppUserID==user.Id)
				.Select(y => y.CustomerAccountID).FirstOrDefault();

			/*
			 If you want to send just from TL to TL accounts

			var senderAccountNumberID = context.CustomerAccounts
				.Where(x => x.AppUserID==user.Id)
				.Where(z => z.CustomerAccountCurrency == "TL" )
				.Select(y => y.CustomerAccountID).FirstOrDefault();
			 */

			var values = new CustomerAccountTransaction();
			values.TransactionDate = DateTime.Now;
			values.SenderID = senderAccountNumberID;
			values.TransactionType = "Transfer";
			values.ReceiverID = receiverAccountNumberID;
			values.TransactionAmount = sendMoneyForCustomerAccountProcessDTO.TransactionAmount;
			values.Description = sendMoneyForCustomerAccountProcessDTO.Description;


			_customerAccountTransactionService.BInsert(values); 

			return RedirectToAction("Index", "Deneme");
		}

		
	}
}
