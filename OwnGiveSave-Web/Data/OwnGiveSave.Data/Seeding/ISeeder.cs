namespace OwnGiveSave.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(OwnGiveSaveDbContext dbContext, IServiceProvider serviceProvider);
    }
}
