namespace OwnGiveSave.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using OwnGiveSave.Data.Common.Models;
    using OwnGiveSave.Services.Mapping;

    public class DonorHospitalPatient : BaseDeletableModel<string>, IMapTo<DonorHospitalPatient>
    {
        public DonorHospitalPatient()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        [Required]
        public string DonorId { get; set; }
        public virtual Donor Donor { get; set; }

        [Required]
        public string HospitalId { get; set; }
        public virtual Hospital Hospital { get; set; }

        [Required]
        public string PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        [Required]
        public double LitersOfDonatedBlood { get; set; }
    }
}
