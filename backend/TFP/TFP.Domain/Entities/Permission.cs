using System;
using System.Collections.Generic;

namespace TFP.Domain.Entities
{
    public class Permission
    {
        public Permission()
        {
            PermissionSetPermission = new HashSet<PermissionSetPermission>();
            UserPermission = new HashSet<UserPermission>();
        }

        public Guid Id { get; set; }
        public Guid PermissionGroupId { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public PermissionGroup PermissionGroup { get; set; }
        public ICollection<PermissionSetPermission> PermissionSetPermission { get; set; }
        public ICollection<UserPermission> UserPermission { get; set; }
    }
}
