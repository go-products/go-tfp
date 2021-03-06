﻿using System.Collections.Generic;

namespace TFP.Domain.Entities
{
    public class StylistSpecialization
    {
        public StylistSpecialization()
        {
            Stylist = new HashSet<Stylist>();
        }

        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Stylist> Stylist { get; set; }
    }
}
