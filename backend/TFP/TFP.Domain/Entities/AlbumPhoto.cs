using System;

namespace TFP.Domain.Entities
{
    public class AlbumPhoto
    {
        public Guid AlbumId { get; set; }
        public Guid PhotoId { get; set; }

        public Album Album { get; set; }
        public Photo Photo { get; set; }
    }
}
