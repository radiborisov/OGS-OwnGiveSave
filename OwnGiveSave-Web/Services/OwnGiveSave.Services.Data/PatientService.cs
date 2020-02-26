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

    public class PatientService : IPatientService
    {
        private readonly IDeletableEntityRepository<Patient> patientRepository;

        public PatientService(IDeletableEntityRepository<Patient> patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public async Task Create<TModel>(TModel model)
        {
            var patient = AutoMapperConfig.MapperInstance.Map<Patient>(model);

            await this.patientRepository.AddAsync(patient);
            await this.patientRepository.SaveChangesAsync();
        }

        public async Task<TModel> GetPatientById<TModel>(string id)
            => AutoMapperConfig.MapperInstance.Map<TModel>(await this.patientRepository.All().FirstOrDefaultAsync(x => x.Id == id));

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
        {
            return await this.patientRepository
                .All()
                .To<TModel>()
                .ToListAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllInNeedByAsync<TModel>()
        {
            return await this.patientRepository
              .All()
              .Where(x => !x.IsReady)
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
               .Where(x => x.HospitalId == hospitalId && !x.IsReady)
               .To<TModel>()
               .ToListAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllInNeedByHospitalIdAndTypeBloodAsync<TModel>(string hospitalId, TypeBlood typeBlood)
        {
            return await this.patientRepository
               .All()
               .Where(x => x.HospitalId == hospitalId && !x.IsReady && x.Blood.TypeBlood == typeBlood)
               .To<TModel>()
               .ToListAsync();
        }

        public async Task ChangePatientDonors(string patientId, int donors)
        {
            var patient = await this.patientRepository.All().FirstOrDefaultAsync(x => x.Id == patientId);

            patient.NeededDonators = donors;

            this.patientRepository.Update(patient);
            await this.patientRepository.SaveChangesAsync();
        }

        public async Task ChangePatientStatus(string patientId, bool status)
        {
            var patient = await this.patientRepository.All().FirstOrDefaultAsync(x => x.Id == patientId);

            patient.IsReady = status;

            this.patientRepository.Update(patient);
            await this.patientRepository.SaveChangesAsync();
        }

        public async Task ChangePatientLitersPerDonor(string patientId, int liters)
        {
            var patient = await this.patientRepository.All().FirstOrDefaultAsync(x => x.Id == patientId);

            patient.LitersOfBloodPerDonor = liters;

            this.patientRepository.Update(patient);
            await this.patientRepository.SaveChangesAsync();
        }
    }
}
