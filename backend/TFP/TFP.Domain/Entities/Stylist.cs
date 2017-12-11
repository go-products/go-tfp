using System;

namespace TFP.Domain.Entities
{
    public class Stylist
    {
        public Guid Id { get; set; }
        public int StylistSpecializationId { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid ModifiedId { get; set; }
        

        public Individual IdNavigation { get; set; }
        public Individual Modified { get; set; }
        public StylistSpecialization StylistSpecialization { get; set; }
    }
}
