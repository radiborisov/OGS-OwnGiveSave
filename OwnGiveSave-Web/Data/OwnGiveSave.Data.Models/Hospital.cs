namespace OwnGiveSave.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using OwnGiveSave.Data.Common.Models;
    using OwnGiveSave.Services.Mapping;

    public class Hospital : BaseDeletableModel<string>, IMapTo<Hospital>
    {
        public Hospital()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;

            this.HospitalDonors = new HashSet<DonorHospital>();
            this.Patients = new HashSet<Patient>();
        }

        [Required]
        public string HospitalName { get; set; }

        [Required]
        public string Name { get; set; }

        public string LocationId { get; set; }
        public HospitalLocation Location { get; set; }

        [Required]
        public string TypeOfTheHospital { get; set; }

        public ICollection<Patient> Patients { get; set; }

        public ICollection<DonorHospital> HospitalDonors { get; set; }
    }
}
