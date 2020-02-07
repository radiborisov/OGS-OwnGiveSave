namespace OwnGiveSave.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using OwnGiveSave.Data.Common.Models;

    public class HospitalLocation : BaseDeletableModel<string>
    {
        public HospitalLocation()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        [Required]
        [ForeignKey("Hospital")]
        public string HospitalId { get; set; }
        public Hospital Hospital { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        [Required]
        public decimal Altitude { get; set; }
    }
}
