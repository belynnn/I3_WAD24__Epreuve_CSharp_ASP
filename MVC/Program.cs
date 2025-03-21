using MVC.Handlers;
using Common.Repositories;

namespace MVC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			// Ajout d'impl�mentation du service d'acc�s � l'HttpContext
			// (dans le but d'atteindre nos variables de session en dehors du controller ou de la vue)
			builder.Services.AddHttpContextAccessor();

			// Ajout d'impl�mentation des services n�cessaires � l'utilisation de session :
			// AddDistributedMemoryCache : Pour le d�veloppment et debbugage
			builder.Services.AddDistributedMemoryCache();

			// AddDistributedSqlServerCache : Pour un projet client, une release fonctionnelle
			/*
			builder.Services.AddDistributedSqlServerCache(
				options =>
				{
					options.ConnectionString = builder.Configuration.GetConnectionString("Session-DB");
					options.SchemaName = "dbo";
					options.TableName = "Session";
				}
				);
			*/
			builder.Services.AddSession(
				options => {
					options.Cookie.Name = "CookieWad24";
					options.Cookie.HttpOnly = true;
					options.Cookie.IsEssential = true;
					options.IdleTimeout = TimeSpan.FromMinutes(10);
				});
			builder.Services.Configure<CookiePolicyOptions>(options => {
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
				options.Secure = CookieSecurePolicy.Always;
			});
			

			// Ajout du service de sessionManager
			builder.Services.AddScoped<SessionManager>();

			//Ajout des services : BLL & DAL
			builder.Services.AddScoped<IUserRepository<BLL.Entities.User>, BLL.Services.UserService>();
			builder.Services.AddScoped<IUserRepository<DAL.Entities.User>, DAL.Services.UserService>();
			builder.Services.AddScoped<IGameRepository<BLL.Entities.Game>, BLL.Services.GameService>();
			builder.Services.AddScoped<IGameRepository<DAL.Entities.Game>, DAL.Services.GameService>();
			builder.Services.AddScoped<ILoanRepository<BLL.Entities.Loan>, BLL.Services.LoanService>();
			builder.Services.AddScoped<ILoanRepository<DAL.Entities.Loan>, DAL.Services.LoanService>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseSession();
			app.UseCookiePolicy();

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}