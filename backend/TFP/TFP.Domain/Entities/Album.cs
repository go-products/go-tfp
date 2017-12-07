using System;
using System.Collections.Generic;

namespace TFP.Domain.Entities
{
    public class Album 
    {
        public int IndividualId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Nude { get; set; }
        public int PhotoId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }

        public Photo Photo { get; set; }
        public List<AlbumPhoto> AlbumPhotos { get; set; }
    }
}