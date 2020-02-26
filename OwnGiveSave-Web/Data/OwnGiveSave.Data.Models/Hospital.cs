namespace OwnGiveSave.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using OwnGiveSave.Data.Common.Models;
    using OwnGiveSave.Services.Mapping;

    public class Hospital : BaseDeletableModel<string>, IMapTo<Hospital>
    {
        public Hospital()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;

            this.HospitalDonors = new HashSet<DonorHospitalPatient>();
            this.Patients = new HashSet<Patient>();
        }

        [Required]
        public string HospitalName { get; set; }

        [Required]
        public string Name { get; set; }

        public string LocationId { get; set; }
        public virtual HospitalLocation Location { get; set; }

        [Required]
        public string TypeOfTheHospital { get; set; }

        public virtual IEnumerable<Patient> Patients { get; set; }

        public virtual IEnumerable<DonorHospitalPatient> HospitalDonors { get; set; }
    }
}
