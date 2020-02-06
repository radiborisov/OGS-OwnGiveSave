namespace OwnGiveSave.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using OwnGiveSave.Data.Common.Repositories;
    using OwnGiveSave.Data.Models;
    using OwnGiveSave.Services.Data.Contracts;

    public class HospitalService : IHospitalService
    {
        private readonly IDeletableEntityRepository<Hospital> hospitalRepository;

        public HospitalService(IDeletableEntityRepository<Hospital> hospitalRepository)
        {
            this.hospitalRepository = hospitalRepository;
        }

        public async Task AddHospitalAsync<TModel>(TModel donoredBlood)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TModel>> GetAllByHospitalIdAsync<TModel>()
        {
            throw new NotImplementedException();
        }
    }
}
