﻿namespace OwnGiveSave.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IHospitalService
    {
        Task AddHospitalAsync<TModel>(TModel model);

        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<IEnumerable<TModel>> GetAllByDonorIdAsync<TModel>(string donorId);

        Task<TModel> GetHospitalByHospitalUsername<TModel>(string hospitalUsername);

    }
}
