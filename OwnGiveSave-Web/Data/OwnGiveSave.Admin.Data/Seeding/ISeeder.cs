namespace OwnGiveSave.Admin.Data.Seeding
{
    using System;
    using System.Threading.Tasks;
    using OwnGiveSave.Admin.Data;

    public interface ISeeder
    {
        Task SeedAsync(ApplicationAdminDbContext dbContext, IServiceProvider serviceProvider);
    }
}
