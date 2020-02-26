namespace OwnGiveSave.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using OwnGiveSave.Data.Models.Enums;

    public interface IBloodService
    {
        Task AddBloodAsync<TModel>(TModel model);

        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<IEnumerable<TModel>> GetAllByBloodTypeAsync<TModel>(TypeBlood typeBlood);

        Task<IEnumerable<TModel>> GetAllByBloodTypeAndPositivityAsync<TModel>(TypeBlood typeBlood, bool isPositive);
    }
}
