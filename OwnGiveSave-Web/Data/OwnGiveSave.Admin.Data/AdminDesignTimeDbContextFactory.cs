namespace OwnGiveSave.Admin.Data
{
    using System.IO;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    public class AdminDesignTimeDbContextFactory : IDesignTimeDbContextFactory<OwnGiveSaveAdminDbContext>
    {
        public OwnGiveSaveAdminDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var builder = new DbContextOptionsBuilder<OwnGiveSaveAdminDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);

            return new OwnGiveSaveAdminDbContext(builder.Options);
        }
    }
}
