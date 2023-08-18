using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulukaBankIdentityProject.DataTransferObjectLayer.DTOs.CustomerAccountTransactionDTOs
{
	public class SendMoneyForCustomerAccountProcessDTO
	{
		public string TransactionType { get; set; }
		public decimal TransactionAmount { get; set; }
		public DateTime TransactionDate { get; set; }
		public int SenderID { get; set; }
		public string ReceiverAccountNumber { get; set; }
		public int ReceiverID { get; set; }

		public string Description { get; set; }
	}
}
