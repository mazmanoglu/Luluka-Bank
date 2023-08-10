using LulukaBankIdentityProject.DataAccessLayer.Abstract;
using LulukaBankIdentityProject.DataAccessLayer.Repositories;
using LulukaBankIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulukaBankIdentityProject.DataAccessLayer.EntityFramework
{
   public class EFCustomerAccountTransactionDAL:GenericRepository<CustomerAccountTransaction>,ICustomerAccountTransactionDAL
   {
   }
}
