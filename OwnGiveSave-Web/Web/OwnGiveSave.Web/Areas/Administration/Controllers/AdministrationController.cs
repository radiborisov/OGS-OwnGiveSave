namespace OwnGiveSave.Web.Areas.Administration.Controllers
{
    using OwnGiveSave.Common;
    using OwnGiveSave.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
