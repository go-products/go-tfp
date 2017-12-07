using System.Collections.Generic;

namespace TFP.Domain.Entities
{
    public class ShootingGenre
    {
        public ShootingGenre()
        {
            PhotographerShootingGenre = new HashSet<PhotographerShootingGenre>();
        }

        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<PhotographerShootingGenre> PhotographerShootingGenre { get; set; }
    }
}
