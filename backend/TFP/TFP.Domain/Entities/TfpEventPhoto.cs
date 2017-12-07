using System;

namespace TFP.Domain.Entities
{
    public class TfpEventPhoto
    {
        public Guid TfpEventId { get; set; }
        public Guid PhotoId { get; set; }

        public Photo Photo { get; set; }
        public TfpEvent TfpEvent { get; set; }
    }
}
