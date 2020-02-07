namespace OwnGiveSave.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using OwnGiveSave.Data.Common.Models;

    public class Donor : BaseDeletableModel<string>
    {
        public Donor()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;

            this.DonorHospitals = new HashSet<DonorHospital>();
        }

        [Required]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        [ForeignKey("Blood")]
        public string BloodId { get; set; }
        public Blood Blood { get; set; }

        public DateTime LastBloodDonation { get; set; }

        public ICollection<DonorHospital> DonorHospitals { get; set; }
    }
}
