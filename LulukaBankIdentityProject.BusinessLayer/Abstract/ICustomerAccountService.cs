using LulukaBankIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulukaBankIdentityProject.BusinessLayer.Abstract
{
	public interface ICustomerAccountService : IGenericService<CustomerAccount>
	{
		public List<CustomerAccount> BGetCustomerAccountsList(int id);
	}
}
