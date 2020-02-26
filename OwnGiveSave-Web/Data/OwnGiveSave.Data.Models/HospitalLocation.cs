namespace OwnGiveSave.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using OwnGiveSave.Data.Common.Models;
    using OwnGiveSave.Services.Mapping;

    public class HospitalLocation : BaseDeletableModel<string>, IMapTo<HospitalLocation>
    {
        public HospitalLocation()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        [Required]
        [ForeignKey("Hospital")]
        public string HospitalId { get; set; }
        public virtual Hospital Hospital { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        [Required]
        public decimal Altitude { get; set; }
    }
}
