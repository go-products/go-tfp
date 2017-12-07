using System.Collections.Generic;
using Colibri.Domain.Membership;

namespace Colibri.Domain.Lookup
{
    public class Permission
    {
        public int PermissionGroupId { get; set; }

        public PermissionGroup PermissionGroup { get; set; }
        public List<PermissionSetPermission> PermissionSetPermissions { get; set; }
        public List<UserPermission> UserPermissions { get; set; }
    }
}