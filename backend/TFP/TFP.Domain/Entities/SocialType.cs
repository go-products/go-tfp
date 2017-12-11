using System.Collections.Generic;

namespace TFP.Domain.Entities
{
    public class SocialType
    {
        public SocialType()
        {
            Social = new HashSet<Social>();
        }

        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Social> Social { get; set; }
    }
}
