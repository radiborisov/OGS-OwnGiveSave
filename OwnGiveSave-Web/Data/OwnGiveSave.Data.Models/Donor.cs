namespace OwnGiveSave.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using OwnGiveSave.Data.Common.Models;
    using OwnGiveSave.Services.Mapping;

    public class Donor : BaseDeletableModel<string>, IMapTo<Donor>
    {
        public Donor()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;

            this.DonorHospitals = new HashSet<DonorHospitalPatient>();
        }

        [Required]
        [ForeignKey("ApplicationUser")]
        public string OwnGiveSaveUserId { get; set; }
        public virtual OwnGiveSaveUser OwnGiveSaveUser { get; set; }

        [Required]
        [ForeignKey("Blood")]
        public string BloodId { get; set; }
        public virtual Blood Blood { get; set; }

        public DateTime LastBloodDonation { get; set; }

        public virtual IEnumerable<DonorHospitalPatient> DonorHospitals { get; set; }
    }
}
