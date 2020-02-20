namespace OwnGiveSave.Admin.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using OwnGiveSave.Admin.Data;
    using OwnGiveSave.Admin.Data.Models;
    using OwnGiveSave.Common;

    internal class RolesSeeder : ISeeder
    {
        public async Task SeedAsync(OwnGiveSaveAdminDbContext dbContext, IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<OwnGiveSaveAdminRole>>();

            await SeedRoleAsync(roleManager, GlobalConstants.AdministratorRoleName);
            await SeedRoleAsync(roleManager, GlobalConstants.HospitalRoleName);
        }

        private static async Task SeedRoleAsync(RoleManager<OwnGiveSaveAdminRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                var result = await roleManager.CreateAsync(new OwnGiveSaveAdminRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
