using System;

namespace TFP.Domain.Entities
{
    public class PermissionSetPermission
    {
        public int PermissionSetId { get; set; }
        public Guid PermissionId { get; set; }

        public Permission Permission { get; set; }
        public PermissionSet PermissionSet { get; set; }
    }
}
