using System;
using System.Collections.Generic;

namespace TFP.Domain.Entities
{
    public class Photo
    {
        public Photo()
        {
            Album = new HashSet<Album>();
            AlbumPhoto = new HashSet<AlbumPhoto>();
            TfpEvent = new HashSet<TfpEvent>();
            TfpEventPhoto = new HashSet<TfpEventPhoto>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid ModifiedId { get; set; }
        

        public Individual Modified { get; set; }
        public ICollection<Album> Album { get; set; }
        public ICollection<AlbumPhoto> AlbumPhoto { get; set; }
        public ICollection<TfpEvent> TfpEvent { get; set; }
        public ICollection<TfpEventPhoto> TfpEventPhoto { get; set; }
    }
}
