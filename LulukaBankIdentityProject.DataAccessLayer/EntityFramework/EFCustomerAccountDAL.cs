using LulukaBankIdentityProject.DataAccessLayer.Abstract;
using LulukaBankIdentityProject.DataAccessLayer.Concrete;
using LulukaBankIdentityProject.DataAccessLayer.Repositories;
using LulukaBankIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulukaBankIdentityProject.DataAccessLayer.EntityFramework
{
	public class EFCustomerAccountDAL : GenericRepository<CustomerAccount>, ICustomerAccountDAL
	{
		public List<CustomerAccount> GetCustomerAccountsList(int id)
		{
			using var context = new Context();
			var values = context.CustomerAccounts.Where(c => c.AppUserID == id).ToList();

			return values;
		}
	}
}
