using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TFP.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            UserPermission = new HashSet<UserPermission>();
        }

        public string Login { get; set; }
        public int? InitialPermissionSetId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Comment { get; set; }

        public Individual IdNavigation { get; set; }
        public PermissionSet InitialPermissionSet { get; set; }
        public ICollection<UserPermission> UserPermission { get; set; }
    }

    public class Role : IdentityRole<Guid>
    {

    }
}
