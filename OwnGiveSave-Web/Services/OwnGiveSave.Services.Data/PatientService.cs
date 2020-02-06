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

        public async Task<IEnumerable<TModel>> GetAllByHospitalIdAsync<TModel>()
        {
            return await this.patientRepository
               .All()
               .To<TModel>()
               .ToListAsync();
        }
    }
}
