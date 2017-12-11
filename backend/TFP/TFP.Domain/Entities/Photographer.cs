using System;
using System.Collections.Generic;

namespace TFP.Domain.Entities
{
    public class Photographer
    {
        public Photographer()
        {
            PhotographerShootingGenre = new HashSet<PhotographerShootingGenre>();
        }

        public Guid Id { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid ModifiedId { get; set; }
        

        public Individual IdNavigation { get; set; }
        public Individual Modified { get; set; }
        public ICollection<PhotographerShootingGenre> PhotographerShootingGenre { get; set; }
    }
}
