namespace OwnGiveSave.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using OwnGiveSave.Data.Models;
    using OwnGiveSave.Services.Data.Contracts;
    using OwnGiveSave.Web.ViewModels.Patiens.BindingModels;
    using OwnGiveSave.Web.ViewModels.User;

    [AllowAnonymous]
    public class AccountController : ApiBasicController
    {
        private readonly UserManager<OwnGiveSaveUser> userManager;
        private readonly IPatientService patientService;

        public AccountController(UserManager<OwnGiveSaveUser> userManager, IPatientService patientService)
        {
            this.userManager = userManager;
            this.patientService = patientService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]UserRegisterBindingModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var user = new OwnGiveSaveUser { Email = model.Email, UserName = model.Email };
            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return this.Ok();
            }

            return this.BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody]PatientBindingModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.patientService.Create<PatientBindingModel>(model);

            return this.Ok();
        }
    }
}
