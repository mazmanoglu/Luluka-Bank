using LulukaBankIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulukaBankIdentityProject.DataAccessLayer.Concrete
{
	public class Context : IdentityDbContext<AppUser,AppRole,int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-R8U20SQ\\SQLEXPRESS; initial catalog=LukakuBankDB; integrated Security=true");
		}
		public DbSet<CustomerAccount> CustomerAccounts { get; set; }
		public DbSet<CustomerAccountTransaction> CustomerAccountTransactions { get; set; }


      protected override void OnModelCreating(ModelBuilder builder)
      {
			builder.Entity<CustomerAccountTransaction>()
				.HasOne(x => x.SenderCustomer)
				.WithMany(y => y.CustomerSender)
				.HasForeignKey(z => z.SenderID)
				.OnDelete(DeleteBehavior.ClientSetNull);

			builder.Entity<CustomerAccountTransaction>()
				.HasOne(x => x.ReceiverCustomer)
				.WithMany(y => y.CustomerReceiver)
				.HasForeignKey(z => z.ReceiverID)
				.OnDelete(DeleteBehavior.ClientSetNull);

			base.OnModelCreating(builder);
      }
   }
}
