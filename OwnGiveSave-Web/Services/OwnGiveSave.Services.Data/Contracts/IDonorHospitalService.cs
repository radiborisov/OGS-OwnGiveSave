﻿namespace OwnGiveSave.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDonorHospitalService
    {
        Task AddDonorHospitalAsync<TModel>(TModel model);

        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<IEnumerable<TModel>> GetAllByDonorHospitalIdAsync<TModel>();
    }
}
