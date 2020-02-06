namespace OwnGiveSave.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using OwnGiveSave.Data.Common.Repositories;
    using OwnGiveSave.Data.Models;
    using OwnGiveSave.Services.Data.Contracts;
    using OwnGiveSave.Services.Mapping;

    public class DonorService : IDonorService
    {
        private readonly IDeletableEntityRepository<Donor> donorRepository;

        public DonorService(IDeletableEntityRepository<Donor> donorRepository)
        {
            this.donorRepository = donorRepository;
        }

        public async Task AddDonorAsync<TModel>(TModel model)
        {
            var donor = AutoMapperConfig.MapperInstance.Map<Donor>(model);

            await this.donorRepository.AddAsync(donor);

            await this.donorRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
        {
            return await this.donorRepository
                .All()
                .To<TModel>()
                .ToListAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllByHospitalIdAsync<TModel>(string hospitalId)
        {
            return await this.donorRepository
                .All()
                .Where(x => x.DonorHospitals
                .Any(x => x.HospitalId == hospitalId))
                .To<TModel>()
                .ToListAsync();
        }
    }
}
