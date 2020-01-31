namespace OwnGiveSave.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDonoredBloodService
    {
        Task<IEnumerable<TModel>> GetAll<TModel>();

        Task<IEnumerable<TModel>> GetAllByHospitalId<TModel>();

        Task AddDonoredBlood<TModel>(TModel donoredBlood);
    }
}
