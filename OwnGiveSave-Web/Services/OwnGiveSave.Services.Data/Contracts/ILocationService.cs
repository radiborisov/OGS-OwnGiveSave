namespace OwnGiveSave.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILocationService
    {
        Task AddLocationAsync<TModel>(TModel model);

        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<IEnumerable<TModel>> GetAllByLocationIdAsync<TModel>();
    }
}
