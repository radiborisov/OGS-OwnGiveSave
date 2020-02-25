namespace OwnGiveSave.Data.Models
{
    using OwnGiveSave.Data.Common.Models;
    using OwnGiveSave.Services.Mapping;

    public class Setting : BaseDeletableModel<int>, IMapTo<Setting>
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
