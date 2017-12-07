using System;

namespace TFP.Domain.Entities
{
    public class Social
    {
        public Guid IndividualId { get; set; }
        public int SocialTypeId { get; set; }

        public Individual Individual { get; set; }
        public SocialType SocialType { get; set; }
    }
}
