using LulukaBankIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulukaBankIdentityProject.DataAccessLayer.Abstract
{
	public interface ICustomerAccountTransactionDAL : IGenericDAL<CustomerAccountTransaction>
	{
		List<CustomerAccountTransaction> MyLastTransaction(int id);

	}
}
