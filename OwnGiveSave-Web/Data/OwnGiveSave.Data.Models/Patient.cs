namespace OwnGiveSave.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using OwnGiveSave.Data.Common.Models;
    using OwnGiveSave.Data.Models.Enums;

    public class Patient : BaseDeletableModel<string>
    {
        public Patient()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        [Required]
        [ForeignKey("Hospital")]
        public string HospitalId { get; set; }
        public Hospital Hospital { get; set; }

        public TypeBlood TypeBlood { get; set; }

        public int NeededDonators { get; set; }
    }
}
