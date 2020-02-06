namespace OwnGiveSave.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using OwnGiveSave.Data.Common.Repositories;
    using OwnGiveSave.Data.Models;
    using OwnGiveSave.Services.Data.Contracts;
    using OwnGiveSave.Services.Mapping;

    public class DonoredBloodService : IDonoredBloodService
    {
        private readonly IDeletableEntityRepository<DonoredBlood> donoredBloodRepository;

        public DonoredBloodService(IDeletableEntityRepository<DonoredBlood> donoredBloodRepository)
        {
            this.donoredBloodRepository = donoredBloodRepository;
        }

        public async Task AddDonoredBloodAsync<TModel>(TModel model)
        {
            var donoredBlood = AutoMapperConfig.MapperInstance.Map<DonoredBlood>(model);

            await this.donoredBloodRepository.AddAsync(donoredBlood);
            await this.donoredBloodRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
        {
            return await this.donoredBloodRepository
                .All()
                .To<TModel>()
                .ToListAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllByDonorIdAsync<TModel>(string id)
        {
            return await this.donoredBloodRepository
               .All()
               .Where(x => x.DonorId == id)
               .To<TModel>()
               .ToListAsync();
        }
    }
}
