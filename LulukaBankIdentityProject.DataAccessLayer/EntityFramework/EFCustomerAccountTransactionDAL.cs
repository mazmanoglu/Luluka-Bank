using LulukaBankIdentityProject.DataAccessLayer.Abstract;
using LulukaBankIdentityProject.DataAccessLayer.Concrete;
using LulukaBankIdentityProject.DataAccessLayer.Repositories;
using LulukaBankIdentityProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulukaBankIdentityProject.DataAccessLayer.EntityFramework
{
   public class EFCustomerAccountTransactionDAL : GenericRepository<CustomerAccountTransaction>, ICustomerAccountTransactionDAL
   {
      public List<CustomerAccountTransaction> MyLastTransaction(int id)
      {
         using var context = new Context();
         var values = context.CustomerAccountTransactions.Include(x => x.SenderCustomer).Include(a=>a.ReceiverCustomer).ThenInclude(z => z.AppUser).Where(t=>t.ReceiverID== id || t.SenderID==id).ToList();

         return values;
      }
   }
}
