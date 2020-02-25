namespace OwnGiveSave.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using OwnGiveSave.Data.Common.Models;
    using OwnGiveSave.Services.Mapping;

    public class DonorHospital : BaseDeletableModel<string>, IMapTo<DonorHospital>
    {
        public DonorHospital()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        [Required]
        public string DonorId { get; set; }
        public Donor Donor { get; set; }

        [Required]
        public string HospitalId { get; set; }
        public Hospital Hospital { get; set; }

        [Required]
        public double LitersOfDonatedBlood { get; set; }
    }
}
