namespace OwnGiveSave.Web.Areas.Identity.Pages.Account
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using OwnGiveSave.Admin.Data.Models;

    public class LogoutModel : PageModel
    {
        private readonly SignInManager<OwnGiveSaveAdminUser> signInManager;

        public LogoutModel(SignInManager<OwnGiveSaveAdminUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> OnGet()
        {
            await this.signInManager.SignOutAsync();

            return this.Redirect("/Identity/Account/Login");
        }
    }
}
