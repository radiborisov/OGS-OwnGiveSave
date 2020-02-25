namespace OwnGiveSave.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using OwnGiveSave.Data.Common.Models;
    using OwnGiveSave.Data.Models.Enums;
    using OwnGiveSave.Services.Mapping;

    public class Blood : BaseDeletableModel<string>, IMapTo<Blood>
    {
        public Blood()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        [ForeignKey("Donor")]
        public string DonorId { get; set; }
        public Donor Donor { get; set; }

        [ForeignKey("Patient")]
        public string PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required]
        public TypeBlood TypeBlood { get; set; }

        [Required]
        public bool IsBloodPositive { get; set; }
    }
}
