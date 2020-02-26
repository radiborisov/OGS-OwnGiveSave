namespace OwnGiveSave.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore.Infrastructure;
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

        [Required]
        public TypeBlood TypeBlood { get; set; }

        [Required]
        public bool IsBloodPositive { get; set; }
    }
}
