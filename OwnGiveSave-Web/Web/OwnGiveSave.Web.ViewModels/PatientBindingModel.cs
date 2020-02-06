namespace OwnGiveSave.Web.ViewModels
{
    using OwnGiveSave.Data.Models;
    using OwnGiveSave.Services.Mapping;

    public class PatientBindingModel : IMapTo<Patient>
    {
        public int TypeBlood { get; set; }

        public int NeededDonators { get; set; }
    }
}
