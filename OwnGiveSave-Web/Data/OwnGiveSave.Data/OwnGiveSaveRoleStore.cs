namespace OwnGiveSave.Data
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using OwnGiveSave.Data.Models;

    public class OwnGiveSaveRoleStore : RoleStore<
       ApplicationRole,
       ApplicationDbContext,
        string,
        IdentityUserRole<string>,
        IdentityRoleClaim<string>>
    {
        public OwnGiveSaveRoleStore(ApplicationDbContext context, IdentityErrorDescriber describer = null)
            : base(context, describer)
        {
        }

        protected override IdentityRoleClaim<string> CreateRoleClaim(ApplicationRole role, Claim claim) =>
            new IdentityRoleClaim<string>
            {
                RoleId = role.Id,
                ClaimType = claim.Type,
                ClaimValue = claim.Value,
            };
    }
}
