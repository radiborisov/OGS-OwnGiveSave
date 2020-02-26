namespace OwnGiveSave.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using OwnGiveSave.Data.Common.Repositories;
    using OwnGiveSave.Data.Models;
    using OwnGiveSave.Data.Models.Enums;
    using OwnGiveSave.Services.Data.Contracts;
    using OwnGiveSave.Services.Mapping;

    public class BloodService : IBloodService
    {
        private readonly IDeletableEntityRepository<Blood> bloodRepository;

        public BloodService(IDeletableEntityRepository<Blood> bloodRepository)
        {
            this.bloodRepository = bloodRepository;
        }

        public async Task AddBloodAsync<TModel>(TModel model)
        {
            var blood = AutoMapperConfig.MapperInstance.Map<Blood>(model);

            await this.bloodRepository.AddAsync(blood);
            await this.bloodRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
        {
            return await this.bloodRepository
                .All()
                .To<TModel>()
                .ToListAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllByBloodTypeAsync<TModel>(TypeBlood typeBlood)
        {
            return await this.bloodRepository
               .All()
               .Where(x => x.TypeBlood == typeBlood)
               .To<TModel>()
               .ToListAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllByBloodTypeAndPositivityAsync<TModel>(TypeBlood typeBlood, bool isPositive)
        {
            return await this.bloodRepository
               .All()
               .Where(x => x.TypeBlood == typeBlood && x.IsBloodPositive == isPositive)
               .To<TModel>()
               .ToListAsync();
        }
    }
}
