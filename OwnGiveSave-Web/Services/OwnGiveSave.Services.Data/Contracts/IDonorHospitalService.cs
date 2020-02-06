namespace OwnGiveSave.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDonorHospitalService
    {
        Task AddDonorHospitalAsync<TModel>(TModel model);

        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<IEnumerable<TModel>> GetAllByDonorIdAsync<TModel>(string donorId);

        Task<IEnumerable<TModel>> GetAllByHospitalIdAsync<TModel>(string hospitalId);
    }
}
