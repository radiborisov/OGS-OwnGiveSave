namespace OwnGiveSave.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using OwnGiveSave.Data.Common.Models;

    public class Hospital : BaseDeletableModel<string>
    {
        public Hospital()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;

            this.HospitalDonors = new HashSet<DonorHospital>();
            this.Patients = new HashSet<Patient>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LocationId { get; set; }
        public HospitalLocation Location { get; set; }

        [Required]
        public string TypeOfTheHospital { get; set; }

        public ICollection<Patient> Patients { get; set; }

        public ICollection<DonorHospital> HospitalDonors { get; set; }
    }
}
