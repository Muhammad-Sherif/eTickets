using eTickets.Data.Enums;
using eTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Data
{
	public class AppDbInitializer
	{
		public static async Task SeddingRolesAndUsersAsync(IApplicationBuilder app)
		{
			using (var serviceScope = app.ApplicationServices.CreateScope())
			{

				//Roles 
				var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
				if (!await roleManager.RoleExistsAsync(UserRoles.Admin.ToString()))
					await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin.ToString()));

				if (!await roleManager.RoleExistsAsync(UserRoles.User.ToString()))
					await roleManager.CreateAsync(new IdentityRole(UserRoles.User.ToString()));

				// Users 
				var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
				string adminUserEmail = "admin@etickets.com";

				var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
				if (adminUser == null)
				{
					var newAdminUser = new AppUser()
					{
						FirstName = "Admin",
						LastName = "User",
						UserName = adminUserEmail,
						Email = adminUserEmail,
						EmailConfirmed = true
					};
					await userManager.CreateAsync(newAdminUser, "Coding@1234?");
					await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin.ToString());
					await userManager.AddToRoleAsync(newAdminUser, UserRoles.User.ToString());

				}


				string appUserEmail = "user@etickets.com";

				var appUser = await userManager.FindByEmailAsync(appUserEmail);
				if (appUser == null)
				{
					var newAppUser = new AppUser()
					{
						FirstName = "Application",
						LastName = "User",
						UserName = appUserEmail,
						Email = appUserEmail,
						EmailConfirmed = true
					};
					await userManager.CreateAsync(newAppUser, "Coding@1234?");
					await userManager.AddToRoleAsync(newAppUser, UserRoles.User.ToString());
				}
			}
		}


	}
}
