namespace OwnGiveSave.Web.Areas.Hospital.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using OwnGiveSave.Services.Data.Contracts;
    using OwnGiveSave.Web.ViewModels;
    using OwnGiveSave.Web.ViewModels.Bloods.ViewModels;
    using OwnGiveSave.Web.ViewModels.Hospitals.ViewModels;
    using OwnGiveSave.Web.ViewModels.Patiens.BindingModels;
    using OwnGiveSave.Web.ViewModels.Patiens.ViewModels;

    public class PatientController : HospitalController
    {
        private readonly IHospitalService hospitalService;
        private readonly IPatientService patientService;
        private readonly IBloodService bloodService;

        public PatientController(IHospitalService hospitalService,IPatientService patientService, IBloodService bloodService)
        {
            this.hospitalService = hospitalService;
            this.patientService = patientService;
            this.bloodService = bloodService;
        }

        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create()
        {
            var allBloodTypes = await this.bloodService.GetAllAsync<BloodViewModel>();

            this.ViewData["types"] = allBloodTypes;

            return this.View();
        }

        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create(PatientBindingModel patientBindingModel)
        {
            //TODO find the url.
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Hospital/Patient/Create");
            }

            var hospitalName = this.User.Identity.Name;
            var hospitalInfo = await this.hospitalService.GetHospitalByHospitalUsername<HospitalPatientViewModel>(hospitalName);

            patientBindingModel.HospitalId = hospitalInfo.Id;
            //patientBindingModel.BloodId = ;

            await this.patientService.Create<PatientBindingModel>(patientBindingModel);

            return this.Redirect("/Hospital/Dashboard/Index");
        }

        [HttpGet(Name = "Edit")]
        public async Task<IActionResult> Edit(string id)
        {
            var patient = await this.patientService.GetPatientById<PatientViewModel>(id);

            return this.View(patient);
        }

        [HttpPost(Name = "Edit")]
        public async Task<IActionResult> Edit(string id, PatientBindingModel patientBinding)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Hospital/Patient/Edit");
            }

            await this.patientService.Edit<PatientBindingModel>(id, patientBinding);

            return this.Redirect("/Hospital/Dashboard/Index");
        }
    }
}
