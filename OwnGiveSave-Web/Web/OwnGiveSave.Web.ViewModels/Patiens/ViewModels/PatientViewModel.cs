namespace OwnGiveSave.Web.ViewModels.Patiens.ViewModels
{
    using System;
    using AutoMapper;
    using OwnGiveSave.Data.Models;
    using OwnGiveSave.Services.Mapping;
    using OwnGiveSave.Web.ViewModels.Bloods.ViewModels;

    public class PatientViewModel : IMapFrom<Patient>
    {
        public BloodViewModel Blood { get; set; }

        public DateTime DeadlineOfTheDonations { get; set; }

        public int NeededDonators { get; set; }

        public double LitersOfNeededBlood { get; set; }

    }
}
