namespace OwnGiveSave.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using OwnGiveSave.Data.Common.Models;

    public class PatientHospital : BaseDeletableModel<string>
    {
        public PatientHospital()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        [Required]
        public string PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required]
        public string HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}
