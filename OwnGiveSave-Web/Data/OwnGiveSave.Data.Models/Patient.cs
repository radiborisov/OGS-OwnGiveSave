namespace OwnGiveSave.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using OwnGiveSave.Data.Common.Models;

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

        [Required]
        [ForeignKey("Blood")]
        public string BloodId { get; set; }
        public Blood Blood { get; set; }

        [Required]
        public DateTime DeadlineOfTheDonations { get; set; }

        [Required]
        public int NeededDonators { get; set; }
    }
}
