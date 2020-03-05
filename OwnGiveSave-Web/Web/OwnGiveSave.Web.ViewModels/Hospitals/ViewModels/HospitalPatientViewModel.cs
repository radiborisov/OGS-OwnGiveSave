namespace OwnGiveSave.Web.ViewModels.Hospitals.ViewModels
{
    using System.Collections.Generic;

    using OwnGiveSave.Data.Models;
    using OwnGiveSave.Services.Mapping;
    using OwnGiveSave.Web.ViewModels.Patiens.ViewModels;

    public class HospitalPatientViewModel : IMapFrom<Hospital>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string TypeOfTheHospital { get; set; }

        public IEnumerable<PatientViewModel> Patients { get; set; }
    }
}
