using System;

namespace TFP.Domain.Entities
{
    public class Model
    {
        public Guid Id { get; set; }
        public bool Nude { get; set; }
        public int HairColorId { get; set; }
        public int Growth { get; set; }
        public int Weight { get; set; }
        public int Thighs { get; set; }
        public int Waist { get; set; }
        public int Breast { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid ModifiedId { get; set; }
        

        public HairColor HairColor { get; set; }
        public Individual IdNavigation { get; set; }
        public Individual Modified { get; set; }
    }
}
