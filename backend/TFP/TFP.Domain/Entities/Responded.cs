using System;

namespace TFP.Domain.Entities
{
    public class Responded
    {
        public Guid TfpEventId { get; set; }
        public Guid IndividualId { get; set; }
        public DateTime CreatedOn { get; set; }

        public Individual Individual { get; set; }
        public TfpEvent TfpEvent { get; set; }
    }
}
