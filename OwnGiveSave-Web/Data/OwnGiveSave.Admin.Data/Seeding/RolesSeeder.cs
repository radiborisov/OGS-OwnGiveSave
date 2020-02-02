namespace OwnGiveSave.Admin.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    using OwnGiveSave.Admin.Data;
    using OwnGiveSave.Admin.Data.Models;
    using OwnGiveSave.Common;

    internal class RolesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationAdminDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationAdminRole>>();

            await SeedRoleAsync(roleManager, GlobalConstants.AdministratorRoleName);
        }

        private static async Task SeedRoleAsync(RoleManager<ApplicationAdminRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                var result = await roleManager.CreateAsync(new ApplicationAdminRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
