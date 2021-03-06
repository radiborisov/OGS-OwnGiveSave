﻿namespace OwnGiveSave.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using OwnGiveSave.Data.Common.Repositories;
    using OwnGiveSave.Data.Models;
    using OwnGiveSave.Services.Data.Contracts;
    using OwnGiveSave.Services.Mapping;

    public class LocationService : ILocationService
    {
        private readonly IDeletableEntityRepository<HospitalLocation> locationRepository;

        public LocationService(IDeletableEntityRepository<HospitalLocation> locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public async Task AddLocationAsync<TModel>(TModel model)
        {
            var location = AutoMapperConfig.MapperInstance.Map<HospitalLocation>(model);

            await this.locationRepository.AddAsync(location);
            await this.locationRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
        {
            return await this.locationRepository
                .All()
                .To<TModel>()
                .ToListAsync();
        }

        public async Task<IEnumerable<TModel>> GetLocationByHospitalIdAsync<TModel>(string hospitalId)
        {
            return await this.locationRepository
                .All()
                .Where(x => x.HospitalId == hospitalId)
                .To<TModel>()
                .ToListAsync();
        }
    }
}
