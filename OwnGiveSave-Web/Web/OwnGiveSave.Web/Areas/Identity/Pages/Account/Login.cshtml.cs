namespace OwnGiveSave.Web.Areas.Identity.Pages.Account
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using OwnGiveSave.Admin.Data.Models;

    public class LoginModel : PageModel
    {
        private readonly SignInManager<OwnGiveSaveAdminUser> signInManager;

        public LoginModel(SignInManager<OwnGiveSaveAdminUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required]
            [Display(Name = "Password")]
            public string Password { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(this.ErrorMessage))
            {
                this.ModelState.AddModelError(string.Empty, this.ErrorMessage);
            }

            this.ReturnUrl = returnUrl ?? this.Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = "/Home/Index";

            if (this.ModelState.IsValid)
            {
                var result = await this.signInManager.PasswordSignInAsync(this.Input.Username, this.Input.Password, false, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    return this.Redirect(returnUrl);
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return this.Page();
                }
            }

            return this.Page();
        }
    }
}
