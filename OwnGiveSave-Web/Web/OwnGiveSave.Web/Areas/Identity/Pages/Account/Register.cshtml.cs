namespace OwnGiveSave.Web.Areas.Identity.Pages.Account
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using OwnGiveSave.Admin.Data.Models;
    using OwnGiveSave.Data.Models;
    using OwnGiveSave.Services.Data.Contracts;

    public class RegisterModel : PageModel
    {
        private readonly SignInManager<OwnGiveSaveAdminUser> signInManager;
        private readonly RoleManager<OwnGiveSaveAdminRole> roleManager;
        private readonly UserManager<OwnGiveSaveAdminUser> userManager;
        private readonly IEmailSender emailSender;
        private readonly IHospitalService hospitalService;

        public RegisterModel(
            UserManager<OwnGiveSaveAdminUser> userManager,
            RoleManager<OwnGiveSaveAdminRole> roleManager,
            SignInManager<OwnGiveSaveAdminUser> signInManager,
            IHospitalService hospitalService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.hospitalService = hospitalService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Hospital username")]
            public string HospitalUsername { get; set; }

            [Required]
            [Display(Name = "Hospital name")]
            public string HospitalName { get; set; }

            [Required]
            [Display(Name = "TypeOfTheHospital")]
            public string TypeOfTheHospital { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            this.ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = "/Administration/DashBoard/Index";

            if (this.ModelState.IsValid)
            {
                var isRoot = !this.userManager.Users.Any();
                var user = new OwnGiveSaveAdminUser { UserName = this.Input.HospitalUsername, Email = this.Input.Email };
                var result = await this.userManager.CreateAsync(user, this.Input.Password);

                if (result.Succeeded)
                {
                    if (isRoot)
                    {
                        await this.userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        await this.userManager.AddToRoleAsync(user, "Hospital");
                    }

                    #region Email Functionality
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { userId = user.Id, code = code },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                    #endregion

                    var hospital = new Hospital();
                    hospital.HospitalName = user.UserName;
                    hospital.Name = this.Input.HospitalName;
                    hospital.TypeOfTheHospital = this.Input.TypeOfTheHospital;

                    await this.hospitalService.AddHospitalAsync<Hospital>(hospital);

                    return this.Redirect(returnUrl);
                }

                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return this.Page();
        }
    }
}
