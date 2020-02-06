﻿namespace OwnGiveSave.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDonorService
    {
        Task AddDonorAsync<TModel>(TModel model);

        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<IEnumerable<TModel>> GetAllByHospitalIdAsync<TModel>(string id);
    }
}
