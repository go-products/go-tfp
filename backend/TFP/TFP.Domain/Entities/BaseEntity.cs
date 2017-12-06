using System;

namespace TFP.Domain.Entities
{
    public class BaseEntity
    {
        public DateTime CreatedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid? ModifiedBy { get; set; }

        public bool Deleted { get; set; }
    }
}
