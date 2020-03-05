namespace OwnGiveSave.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using OwnGiveSave.Data.Common.Models;
    using OwnGiveSave.Services.Mapping;

    public class Patient : BaseDeletableModel<string>, IMapTo<Patient>
    {
        public Patient()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        [ForeignKey("Hospital")]
        public string HospitalId { get; set; }
        public virtual Hospital Hospital { get; set; }

        //[Required]
        //[ForeignKey("Blood")]
        //public string BloodId { get; set; }
        //public virtual Blood Blood { get; set; }

        [Required]
        public DateTime DeadlineOfTheDonations { get; set; }

        [Required]
        public int NeededDonators { get; set; }

        [Required]
        public double LitersOfBloodPerDonor { get; set; }

        [Required]
        public bool IsReady { get; set; }
    }
}
