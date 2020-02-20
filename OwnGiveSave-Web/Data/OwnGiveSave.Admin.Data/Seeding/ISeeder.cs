namespace OwnGiveSave.Admin.Data.Seeding
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using OwnGiveSave.Admin.Data;

    public interface ISeeder
    {
        Task SeedAsync(OwnGiveSaveAdminDbContext dbContext, IServiceProvider serviceProvider, IConfiguration configuration);
    }
}
