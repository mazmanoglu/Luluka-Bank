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
	public class CustomerAccountTransactionManager : ICustomerAccountTransactionService
	{
		private readonly ICustomerAccountTransactionDAL _customerAccountTransactionDAL;

		public CustomerAccountTransactionManager(ICustomerAccountTransactionDAL customerAccountTransactionDAL)
		{
			_customerAccountTransactionDAL = customerAccountTransactionDAL;
		}

		public void BDelete(CustomerAccountTransaction t)
		{
			_customerAccountTransactionDAL.Delete(t);
		}

		public CustomerAccountTransaction BGetById(int id)
		{
			return _customerAccountTransactionDAL.GetById(id);
		}

		public List<CustomerAccountTransaction> BGetList()
		{
			return _customerAccountTransactionDAL.GetList();
		}

		public void BInsert(CustomerAccountTransaction t)
		{
			_customerAccountTransactionDAL.Insert(t);
		}

		public void BUpdate(CustomerAccountTransaction t)
		{
			_customerAccountTransactionDAL.Update(t);
		}

      public List<CustomerAccountTransaction> BMyLastTransaction(int id)
      {
         return _customerAccountTransactionDAL.MyLastTransaction(id);
      }
   }
}
