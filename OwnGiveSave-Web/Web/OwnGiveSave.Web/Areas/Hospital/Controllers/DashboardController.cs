namespace OwnGiveSave.Web.Areas.Hospital.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using OwnGiveSave.Services.Data.Contracts;
    using OwnGiveSave.Web.ViewModels.Hospitals.ViewModels;

    public class DashboardController : HospitalController
    {
        private readonly IHospitalService hospitalService;

        public DashboardController(IHospitalService hospitalService)
        {
            this.hospitalService = hospitalService;
        }

        public async Task<IActionResult> Index()
        {
            var hospitalName = this.User.Identity.Name;
            var hospitalInfo = await this.hospitalService.GetHospitalByHospitalUsername<HospitalPatientViewModel>(hospitalName);

            return this.View(hospitalInfo);
        }

        public async Task<IActionResult> EditPatient()
        {
            return this.View();
        }
    }
}
