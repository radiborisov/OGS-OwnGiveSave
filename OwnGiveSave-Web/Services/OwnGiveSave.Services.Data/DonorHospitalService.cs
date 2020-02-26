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

    public class DonorHospitalService : IDonorHospitalService
    {
        private readonly IDeletableEntityRepository<DonorHospitalPatient> donorHospitalRepository;

        public DonorHospitalService(IDeletableEntityRepository<DonorHospitalPatient> donorHospitalRepository)
        {
            this.donorHospitalRepository = donorHospitalRepository;
        }

        public async Task AddDonorHospitalAsync<TModel>(TModel model)
        {
            var donorHospital = AutoMapperConfig.MapperInstance.Map<DonorHospitalPatient>(model);

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

        public async Task<IEnumerable<TModel>> GetAllByDonorIdAsync<TModel>(string donorId)
        {
            return await this.donorHospitalRepository
               .All()
               .Where(x => x.DonorId == donorId)
               .To<TModel>()
               .ToListAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllByHospitalIdAsync<TModel>(string hospitalId)
        {
            return await this.donorHospitalRepository
              .All()
              .Where(x => x.HospitalId == hospitalId)
              .To<TModel>()
              .ToListAsync();
        }
    }
}
