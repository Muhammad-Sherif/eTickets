using eTickets.Data;
using eTickets.Data.Repositories.Implementations;
using eTickets.Data.Repositories.Interfaces;
using eTickets.Data.Services.Implementation;
using eTickets.Data.Services.Interfaces;
using eTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("Default")));

			services.AddIdentity<AppUser, IdentityRole>(options =>
				options.SignIn.RequireConfirmedAccount = false)
				.AddDefaultUI()
				.AddEntityFrameworkStores<AppDbContext>();

			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IMovieServices, MovieServices>();
			services.AddScoped<IShoppingCartService, ShoppingCartService>();
			services.AddAutoMapper(typeof(Startup));
			services.AddControllersWithViews().AddRazorRuntimeCompilation();
			services.AddAuthentication();
			services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
			{
				ProgressBar = true,
				PositionClass = ToastPositions.TopRight,
				PreventDuplicates = true,
				CloseButton = true
			});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();

			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{

				endpoints.MapRazorPages();
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});

			  AppDbInitializer.SeddingRolesAndUsersAsync(app).Wait();

		}
	}
}
