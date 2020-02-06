namespace OwnGiveSave.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using OwnGiveSave.Data.Common.Repositories;
    using OwnGiveSave.Data.Models;
    using OwnGiveSave.Services.Data.Contracts;

    public class DonoredBloodService : IDonoredBloodService
    {
        private readonly IDeletableEntityRepository<DonoredBlood> donoredBloodRepository;

        public DonoredBloodService(IDeletableEntityRepository<DonoredBlood> donoredBloodRepository)
        {
            this.donoredBloodRepository = donoredBloodRepository;
        }

        public async Task AddDonoredBloodAsync<TModel>(TModel donoredBlood)
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
