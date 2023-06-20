using LulukaBankIdentityProject.BusinessLayer.Abstract;
using LulukaBankIdentityProject.DataAccessLayer.Abstract;
using LulukaBankIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulukaBankIdentityProject.BusinessLayer.Concrete
{
	public class CustomerAccountManager : ICustomerAccountService
	{
		#region dependency injection
		// apply dependency injection
		// Dependency injection is a design pattern used to invoke one class while not refreshing the other class. Especially for the changes made as the projects grow, we do not need to make changes in all the classes that that class depends on one by one.
		// Dependency injection is often used to keep code in-line with the dependency inversion principle.
		// Dependency injection aims to separate the concerns of constructing objects and using them, leading to loosely coupled programs.
		// With this injection, you dont need to write the whole code when you want to change or add something.
		// It makes the code flexible and improves performence of the program. 
		private readonly ICustomerAccountDAL _customerAccountDAL;

		public CustomerAccountManager(ICustomerAccountDAL customerAccountDAL)
		{
			_customerAccountDAL = customerAccountDAL;
		} 
		#endregion

		public void BDelete(CustomerAccount t)
		{
			_customerAccountDAL.Delete(t);	
		}

		public CustomerAccount BGetById(int id)
		{
			return _customerAccountDAL.GetById(id);
		}

		public List<CustomerAccount> BGetList()
		{
			return _customerAccountDAL.GetList();
		}

		public void BInsert(CustomerAccount t)
		{
			_customerAccountDAL.Insert(t);
		}

		public void BUpdate(CustomerAccount t)
		{
			_customerAccountDAL.Update(t);
		}
	}
}
