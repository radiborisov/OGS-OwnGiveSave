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

    public class PatientService : IPatientService
    {
        private readonly IDeletableEntityRepository<Patient> patientRepository;

        public PatientService(IDeletableEntityRepository<Patient> patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public async Task AddPatientAsync<TModel>(TModel model)
        {
            var patient = AutoMapperConfig.MapperInstance.Map<Patient>(model);

            await this.patientRepository.AddAsync(patient);
            await this.patientRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
        {
            return await this.patientRepository
                .All()
                .To<TModel>()
                .ToListAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllByHospitalIdAsync<TModel>(string hospitalId)
        {
            return await this.patientRepository
               .All()
               .Where(x => x.HospitalId == hospitalId)
               .To<TModel>()
               .ToListAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllInNeedByHospitalIdAsync<TModel>(string hospitalId)
        {
            return await this.patientRepository
               .All()
               .Where(x => x.HospitalId == hospitalId && x.NeededDonators > 0)
               .To<TModel>()
               .ToListAsync();
        }
    }
}
