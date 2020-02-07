namespace OwnGiveSave.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using OwnGiveSave.Data.Common.Models;
    using OwnGiveSave.Data.Models.Enums;

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
        public TypeBlood TypeBlood { get; set; }

        [Required]
        public bool IsBloodPositive { get; set; }

        public ICollection<DonorHospital> DonorHospitals { get; set; }
    }
}
