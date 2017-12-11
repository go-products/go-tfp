using System;
using System.Collections.Generic;

namespace TFP.Domain.Entities
{
    public class PermissionGroup
    {
        public PermissionGroup()
        {
            Permission = new HashSet<Permission>();
        }

        public Guid Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Permission> Permission { get; set; }
    }
}
