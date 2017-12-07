using System.Collections.Generic;

namespace TFP.Domain.Entities
{
    public class HairColor
    {
        public HairColor()
        {
            Model = new HashSet<Model>();
        }

        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Model> Model { get; set; }
    }
}
