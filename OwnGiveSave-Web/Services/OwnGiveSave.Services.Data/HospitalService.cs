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

    public class HospitalService : IHospitalService
    {
        private readonly IDeletableEntityRepository<Hospital> hospitalRepository;

        public HospitalService(IDeletableEntityRepository<Hospital> hospitalRepository)
        {
            this.hospitalRepository = hospitalRepository;
        }

        public async Task AddHospitalAsync<TModel>(TModel model)
        {
            var hospital = AutoMapperConfig.MapperInstance.Map<Hospital>(model);

            await this.hospitalRepository.AddAsync(hospital);
            await this.hospitalRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
        {
            return await this.hospitalRepository
                .All()
                .To<TModel>()
                .ToListAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllByDonorIdAsync<TModel>()
        {
            return await this.hospitalRepository
               .All()
               .To<TModel>()
               .ToListAsync();
        }
    }
}
