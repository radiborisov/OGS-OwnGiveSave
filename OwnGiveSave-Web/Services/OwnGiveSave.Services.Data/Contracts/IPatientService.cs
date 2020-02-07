namespace OwnGiveSave.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPatientService
    {
        Task AddPatientAsync<TModel>(TModel model);

        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<IEnumerable<TModel>> GetAllByHospitalIdAsync<TModel>(string hospitalId);

        Task<IEnumerable<TModel>> GetAllInNeedByHospitalIdAsync<TModel>(string hospitalId);
    }
}
