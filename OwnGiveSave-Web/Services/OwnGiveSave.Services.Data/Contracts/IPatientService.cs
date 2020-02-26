namespace OwnGiveSave.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using OwnGiveSave.Data.Models.Enums;

    public interface IPatientService
    {
        Task Create<TModel>(TModel model);

        Task<TModel> GetPatientById<TModel>(string id);

        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<IEnumerable<TModel>> GetAllInNeedByAsync<TModel>();

        Task<IEnumerable<TModel>> GetAllByHospitalIdAsync<TModel>(string hospitalId);

        Task<IEnumerable<TModel>> GetAllInNeedByHospitalIdAsync<TModel>(string hospitalId);

        Task<IEnumerable<TModel>> GetAllInNeedByHospitalIdAndTypeBloodAsync<TModel>(string hospitalId, TypeBlood typeBlood);

        Task Edit(string patientId, int donors);

    }
}
