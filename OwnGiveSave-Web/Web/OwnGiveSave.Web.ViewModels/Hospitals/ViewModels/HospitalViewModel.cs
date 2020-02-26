namespace OwnGiveSave.Web.ViewModels.Hospitals.ViewModels
{
    using OwnGiveSave.Data.Models;
    using OwnGiveSave.Services.Mapping;

    public class HospitalViewModel : IMapFrom<Hospital>
    {
        public string Name { get; set; }

        public string TypeOfTheHospital { get; set; }
    }
}
