using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulukaBankIdentityProject.EntityLayer.Concrete
{
	public class CustomerAccountTransaction
	{
		public int CustomerAccountTransactionID { get; set; }
		public string TransactionType { get; set; }
		public decimal TransactionAmount { get; set; }
		public DateTime TransactionDate { get; set; }
	}
}
