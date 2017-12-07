using System;
using System.Collections.Generic;
using Colibri.Common.Helpers;

namespace Colibri.Domain.Membership
{
    public class User
    {
        public string Login { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastLoginOn { get; set; }
        public DateTime? LastBlockedOn { get; set; }
        public DateTime? LastPasswordChangedOn { get; set; }
        public string Comment { get; set; }
    }
}