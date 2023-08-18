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


      public int? SenderID { get; set; }
      public int? ReceiverID { get; set; }
      public CustomerAccount SenderCustomer { get; set; }
      public CustomerAccount ReceiverCustomer { get; set; }

      public string Description { get; set; }
   }
}

/*
	ID - Type of Transaction (send/receive/payment) - Amount - Date - Receiver - Sender
 */