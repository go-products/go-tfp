using System;
using System.Collections.Generic;

namespace TFP.Domain.Entities
{
    public class TfpEvent
    {
        public TfpEvent()
        {
            Responded = new HashSet<Responded>();
            TfpEventPhoto = new HashSet<TfpEventPhoto>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public string Description { get; set; }
        public DateTime HeldOn { get; set; }
        public Guid? PhotoId { get; set; }
        public int CityId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid ModifiedId { get; set; }
        

        public Individual Author { get; set; }
        public City City { get; set; }
        public Individual Modified { get; set; }
        public Photo Photo { get; set; }
        public ICollection<Responded> Responded { get; set; }
        public ICollection<TfpEventPhoto> TfpEventPhoto { get; set; }
    }
}
