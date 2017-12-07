using System;

namespace TFP.Domain.Entities
{
    public class UserPermission
    {
        public Guid UserId { get; set; }
        public int PermissionId { get; set; }

        public Permission Permission { get; set; }
        public User User { get; set; }
    }
}
