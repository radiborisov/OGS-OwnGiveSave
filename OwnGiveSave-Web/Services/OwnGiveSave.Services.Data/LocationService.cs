namespace OwnGiveSave.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using OwnGiveSave.Data.Common.Repositories;
    using OwnGiveSave.Data.Models;
    using OwnGiveSave.Services.Data.Contracts;

    public class LocationService : ILocationService
    {
        private readonly IDeletableEntityRepository<Location> locationRepository;

        public LocationService(IDeletableEntityRepository<Location> locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public async Task AddLocationAsync<TModel>(TModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TModel>> GetAllByLocationIdAsync<TModel>()
        {
            throw new NotImplementedException();
        }
    }
}
