namespace OwnGiveSave.Web.Areas.Hospital.Controllers
{

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using OwnGiveSave.Common;
    using OwnGiveSave.Web.Controllers;

    [Authorize(Roles = GlobalConstants.HospitalRoleName)]
    [Area("Hospital")]
    public class HospitalController : BaseController
    {
    }
}
