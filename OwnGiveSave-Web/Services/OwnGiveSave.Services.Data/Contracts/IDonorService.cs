namespace OwnGiveSave.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using OwnGiveSave.Data.Models.Enums;

    public interface IDonorService
    {
        Task AddDonorAsync<TModel>(TModel model);

        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<IEnumerable<TModel>> GetAllByHospitalIdAsync<TModel>(string hospitalId);

        Task<IEnumerable<TModel>> GetAllByBloodTypeAsync<TModel>(TypeBlood typeBlood);

        Task<IEnumerable<TModel>> GetAllByHospitalIdAndBloodTypeAsync<TModel>(string hospitalId, TypeBlood typeBlood);
    }
}
