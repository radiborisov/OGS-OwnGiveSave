// ReSharper disable VirtualMemberCallInConstructor
namespace OwnGiveSave.Admin.Data.Models
{
    using System;

    using Microsoft.AspNetCore.Identity;

    using OwnGiveSave.Data.Common.Models;

    public class ApplicationAdminRole : IdentityRole, IAuditInfo, IDeletableEntity
    {
        public ApplicationAdminRole()
            : this(null)
        {
        }

        public ApplicationAdminRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
