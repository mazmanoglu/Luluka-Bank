using LulukaBankIdentityProject.BusinessLayer.Abstract;
using LulukaBankIdentityProject.BusinessLayer.Concrete;
using LulukaBankIdentityProject.DataAccessLayer.Abstract;
using LulukaBankIdentityProject.DataAccessLayer.Concrete;
using LulukaBankIdentityProject.DataAccessLayer.EntityFramework;
using LulukaBankIdentityProject.EntityLayer.Concrete;
using LulukaBankIdentityProject.PresentationLayer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>(); //new added
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>(); //new added

builder.Services.AddScoped<ICustomerAccountTransactionDAL, EFCustomerAccountTransactionDAL>();
builder.Services.AddScoped<ICustomerAccountTransactionService, CustomerAccountTransactionManager>();

builder.Services.AddScoped<ICustomerAccountDAL, EFCustomerAccountDAL>();
builder.Services.AddScoped<ICustomerAccountService, CustomerAccountManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); //new added
app.UseAuthorization();

app.MapControllerRoute(
	 name: "default",
	 pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
