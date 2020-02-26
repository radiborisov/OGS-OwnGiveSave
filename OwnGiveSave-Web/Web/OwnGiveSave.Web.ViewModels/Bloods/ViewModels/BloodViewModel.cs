namespace OwnGiveSave.Web.ViewModels.Bloods.ViewModels
{
    using OwnGiveSave.Data.Models;
    using OwnGiveSave.Data.Models.Enums;
    using OwnGiveSave.Services.Mapping;

    public class BloodViewModel : IMapFrom<Blood>
    {
        public TypeBlood TypeBlood { get; set; }

        public bool IsBloodPositive { get; set; }
    }
}
