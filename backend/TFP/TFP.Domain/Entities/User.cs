using System;
using System.Collections.Generic;

namespace TFP.Domain.Entities
{
    public class User
    {
        public User()
        {
            UserPermission = new HashSet<UserPermission>();
        }

        public Guid Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int? InitialPermissionSetId { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastLoginOn { get; set; }
        public DateTime? LastBlockedOn { get; set; }
        public DateTime? LastPasswordChangedOn { get; set; }
        public string Comment { get; set; }

        public Individual IdNavigation { get; set; }
        public PermissionSet InitialPermissionSet { get; set; }
        public ICollection<UserPermission> UserPermission { get; set; }
    }
}
