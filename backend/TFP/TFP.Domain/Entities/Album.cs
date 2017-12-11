using System;
using System.Collections.Generic;

namespace TFP.Domain.Entities
{
    public class Album
    {
        public Album()
        {
            AlbumPhoto = new HashSet<AlbumPhoto>();
        }

        public Guid Id { get; set; }
        public Guid IndividualId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Nude { get; set; }
        public Guid PhotoId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid ModifiedId { get; set; }
        

        public Individual Individual { get; set; }
        public Individual Modified { get; set; }
        public Photo Photo { get; set; }
        public ICollection<AlbumPhoto> AlbumPhoto { get; set; }
    }
}
