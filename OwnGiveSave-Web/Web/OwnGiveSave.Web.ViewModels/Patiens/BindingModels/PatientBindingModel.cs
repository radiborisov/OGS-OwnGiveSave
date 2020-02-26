namespace OwnGiveSave.Web.ViewModels.Patiens.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using OwnGiveSave.Data.Models;
    using OwnGiveSave.Services.Mapping;

    public class PatientBindingModel : IMapTo<Patient>
    {
        [Required]
        public string HospitalId { get; set; }

        [Required]
        public string BloodId { get; set; }

        [Required]
        public DateTime DeadlineOfTheDonations { get; set; }

        [Required]
        public int NeededDonators { get; set; }

        [Required]
        public double LitersOfBloodPerDonor { get; set; }
    }
}
