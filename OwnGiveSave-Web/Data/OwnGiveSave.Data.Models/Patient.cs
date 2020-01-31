﻿namespace OwnGiveSave.Data.Models
{
    using System;

    using OwnGiveSave.Data.Common.Models;
    using OwnGiveSave.Data.Models.Enums;

    public class Patient : BaseDeletableModel<string>
    {
        public Patient()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        public TypeBlood TypeBlood { get; set; }

        public int NeededDonators { get; set; }
    }
}
