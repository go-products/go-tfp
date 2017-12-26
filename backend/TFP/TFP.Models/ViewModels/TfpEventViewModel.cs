using System;

namespace TFP.Models.ViewModels
{
    public class TfpEventViewModel
    {
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
    }
}
