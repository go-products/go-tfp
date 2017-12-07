using System.Collections.Generic;

namespace TFP.Domain.Entities
{
    public class PermissionSet
    {
        public PermissionSet()
        {
            PermissionSetPermission = new HashSet<PermissionSetPermission>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        

        public ICollection<PermissionSetPermission> PermissionSetPermission { get; set; }
        public ICollection<User> User { get; set; }
    }
}
