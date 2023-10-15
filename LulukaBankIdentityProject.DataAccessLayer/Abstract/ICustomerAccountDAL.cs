using LulukaBankIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulukaBankIdentityProject.DataAccessLayer.Abstract
{
	public interface ICustomerAccountDAL : IGenericDAL<CustomerAccount>
	{
		List<CustomerAccount> GetCustomerAccountsList(int id);
	}
}
