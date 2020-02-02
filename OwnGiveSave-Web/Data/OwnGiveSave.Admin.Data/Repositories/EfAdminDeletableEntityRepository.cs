namespace OwnGiveSave.Admin.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using OwnGiveSave.Admin.Data;
    using OwnGiveSave.Data.Common.Models;
    using OwnGiveSave.Data.Common.Repositories;

    public class EfAdminDeletableEntityRepository<TEntity> : EfAdminRepository<TEntity>, IDeletableEntityRepository<TEntity>
        where TEntity : class, IDeletableEntity
    {
        public EfAdminDeletableEntityRepository(ApplicationAdminDbContext context)
            : base(context)
        {
        }

        public override IQueryable<TEntity> All() => base.All().Where(x => !x.IsDeleted);

        public override IQueryable<TEntity> AllAsNoTracking() => base.AllAsNoTracking().Where(x => !x.IsDeleted);

        public IQueryable<TEntity> AllWithDeleted() => base.All().IgnoreQueryFilters();

        public IQueryable<TEntity> AllAsNoTrackingWithDeleted() => base.AllAsNoTracking().IgnoreQueryFilters();

        public Task<TEntity> GetByIdWithDeletedAsync(params object[] id)
        {
            var getByIdPredicate = EfAdminExpressionHelper.BuildByIdPredicate<TEntity>(this.Context, id);
            return this.AllWithDeleted().FirstOrDefaultAsync(getByIdPredicate);
        }

        public void HardDelete(TEntity entity) => base.Delete(entity);

        public void Undelete(TEntity entity)
        {
            entity.IsDeleted = false;
            entity.DeletedOn = null;
            this.Update(entity);
        }

        public override void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
            this.Update(entity);
        }
    }
}
