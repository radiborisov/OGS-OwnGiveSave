namespace OwnGiveSave.Data
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using OwnGiveSave.Data.Models;

    public class OwnGiveSaveUserStore : UserStore<
       OwnGiveSaveUser,
        OwnGiveSaveRole,
        OwnGiveSaveDbContext,
        string,
        IdentityUserClaim<string>,
        IdentityUserRole<string>,
        IdentityUserLogin<string>,
        IdentityUserToken<string>,
        IdentityRoleClaim<string>>
    {
        public OwnGiveSaveUserStore(OwnGiveSaveDbContext context, IdentityErrorDescriber describer = null)
            : base(context, describer)
        {
        }

        protected override IdentityUserRole<string> CreateUserRole(OwnGiveSaveUser user, OwnGiveSaveRole role)
        {
            return new IdentityUserRole<string> { RoleId = role.Id, UserId = user.Id };
        }

        protected override IdentityUserClaim<string> CreateUserClaim(OwnGiveSaveUser user, Claim claim)
        {
            var identityUserClaim = new IdentityUserClaim<string> { UserId = user.Id };
            identityUserClaim.InitializeFromClaim(claim);
            return identityUserClaim;
        }

        protected override IdentityUserLogin<string> CreateUserLogin(OwnGiveSaveUser user, UserLoginInfo login) =>
            new IdentityUserLogin<string>
            {
                UserId = user.Id,
                ProviderKey = login.ProviderKey,
                LoginProvider = login.LoginProvider,
                ProviderDisplayName = login.ProviderDisplayName,
            };

        protected override IdentityUserToken<string> CreateUserToken(
            OwnGiveSaveUser user,
            string loginProvider,
            string name,
            string value)
        {
            var token = new IdentityUserToken<string>
            {
                UserId = user.Id,
                LoginProvider = loginProvider,
                Name = name,
                Value = value,
            };
            return token;
        }
    }
}
