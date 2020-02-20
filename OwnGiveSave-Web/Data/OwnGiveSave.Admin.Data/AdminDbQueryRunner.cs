namespace OwnGiveSave.Admin.Data
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using OwnGiveSave.Data.Common;

    public class AdminDbQueryRunner : IDbQueryRunner
    {
        public AdminDbQueryRunner(OwnGiveSaveAdminDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public OwnGiveSaveAdminDbContext Context { get; set; }

        public Task RunQueryAsync(string query, params object[] parameters)
        {
            return this.Context.Database.ExecuteSqlRawAsync(query, parameters);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Context?.Dispose();
            }
        }
    }
}
