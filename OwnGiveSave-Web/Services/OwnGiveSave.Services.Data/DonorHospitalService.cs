namespace OwnGiveSave.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using OwnGiveSave.Data.Common.Repositories;
    using OwnGiveSave.Data.Models;
    using OwnGiveSave.Services.Data.Contracts;

    public class DonorHospitalService : IDonorHospitalService
    {
        private readonly IDeletableEntityRepository<DonorHospital> donorHospitalRepository;

        public DonorHospitalService(IDeletableEntityRepository<DonorHospital> donorHospitalRepository)
        {
            this.donorHospitalRepository = donorHospitalRepository;
        }

        public async Task AddDonorHospitalAsync<TModel>(TModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TModel>> GetAllByDonorHospitalIdAsync<TModel>()
        {
            throw new NotImplementedException();
        }

    }
}
