namespace OwnGiveSave.Admin.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using OwnGiveSave.Admin.Data.Models;
    using OwnGiveSave.Common;

    public class UserSeeder : ISeeder
    {
        public async Task SeedAsync(OwnGiveSaveAdminDbContext dbContext, IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<OwnGiveSaveAdminUser>>();

            var userName = configuration[GlobalConstants.AdministartorJsonUserName];
            var userPassword = configuration[GlobalConstants.AdministartorJsonUserPassword];

            await SeedUserAsync(userManager, userName, userPassword);
        }

        private static async Task SeedUserAsync(UserManager<OwnGiveSaveAdminUser> userManager, string username, string password)
        {
            var user = new OwnGiveSaveAdminUser { Email = null, UserName = username };

            var userResult = await userManager.CreateAsync(user, password);

            if (!userResult.Succeeded)
            {
                throw new Exception(string.Join(Environment.NewLine, userResult.Errors.Select(e => e.Description)));
            }

            var addToUserResult = await userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);

            if (!addToUserResult.Succeeded)
            {
                throw new Exception(string.Join(Environment.NewLine, addToUserResult.Errors.Select(e => e.Description)));
            }
        }
    }
}
