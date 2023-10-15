using LulukaBankIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulukaBankIdentityProject.BusinessLayer.Abstract
{
	public interface ICustomerAccountTransactionService : IGenericService<CustomerAccountTransaction>
	{
      List<CustomerAccountTransaction> BMyLastTransaction(int id);

   }
}
