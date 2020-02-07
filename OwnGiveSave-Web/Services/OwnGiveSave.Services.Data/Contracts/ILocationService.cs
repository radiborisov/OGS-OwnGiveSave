namespace OwnGiveSave.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILocationService
    {
        Task AddLocationAsync<TModel>(TModel model);

        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        // TODO Logic for location/hospital
        Task<IEnumerable<TModel>> GetLocationByHospitalIdAsync<TModel>(string hospitalId);
    }
}
