using System;

namespace TFP.Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public Guid RecipientId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Text { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid ModifiedId { get; set; }
        

        public Individual Author { get; set; }
        public Individual Modified { get; set; }
        public Individual Recipient { get; set; }
    }
}
