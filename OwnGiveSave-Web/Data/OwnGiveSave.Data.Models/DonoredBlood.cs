namespace OwnGiveSave.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using OwnGiveSave.Data.Common.Models;
    using OwnGiveSave.Data.Models.Enums;

    public class DonoredBlood : BaseDeletableModel<string>
    {
        public DonoredBlood()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        [Required]
        public TypeBlood TypeBlood { get; set; }

        [Required]
        public bool IsBloodPositive { get; set; }

        [Required]
        public decimal Quantity { get; set; }
    }
}
