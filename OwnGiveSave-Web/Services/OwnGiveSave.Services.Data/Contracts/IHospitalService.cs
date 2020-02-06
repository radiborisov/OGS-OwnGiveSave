namespace OwnGiveSave.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IHospitalService
    {
        Task AddHospitalAsync<TModel>(TModel donoredBlood);

        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<IEnumerable<TModel>> GetAllByHospitalIdAsync<TModel>();
    }
}
