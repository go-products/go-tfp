using System;

namespace TFP.Domain.Entities
{
    public class PhotographerShootingGenre
    {
        public Guid PhotographerId { get; set; }
        public int ShootingGenreId { get; set; }

        public Photographer Photographer { get; set; }
        public ShootingGenre ShootingGenre { get; set; }
    }
}
