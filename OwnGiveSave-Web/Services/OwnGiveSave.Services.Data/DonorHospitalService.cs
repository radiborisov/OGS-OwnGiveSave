namespace OwnGiveSave.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using OwnGiveSave.Data.Common.Repositories;
    using OwnGiveSave.Data.Models;
    using OwnGiveSave.Services.Data.Contracts;
    using OwnGiveSave.Services.Mapping;

    public class DonorHospitalService : IDonorHospitalService
    {
        private readonly IDeletableEntityRepository<DonorHospital> donorHospitalRepository;

        public DonorHospitalService(IDeletableEntityRepository<DonorHospital> donorHospitalRepository)
        {
            this.donorHospitalRepository = donorHospitalRepository;
        }

        public async Task AddDonorHospitalAsync<TModel>(TModel model)
        {
            var donorHospital = AutoMapperConfig.MapperInstance.Map<DonorHospital>(model);

            await this.donorHospitalRepository.AddAsync(donorHospital);
            await this.donorHospitalRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
        {
            return await this.donorHospitalRepository
                .All()
                .To<TModel>()
                .ToListAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllByDonorIdAsync<TModel>()
        {
            return await this.donorHospitalRepository
               .All()
               .To<TModel>()
               .ToListAsync();
        }

    }
}
