using System.Collections.Generic;

namespace TFP.Domain.Entities
{
    public class Photo 
    {
        public string Title { get; set; }
        public string Path { get; set; }

        public List<AlbumPhoto> AlbumPhotos { get; set; }
    }
}