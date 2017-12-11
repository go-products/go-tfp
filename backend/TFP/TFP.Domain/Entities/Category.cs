using System.Collections.Generic;

namespace TFP.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Individual = new HashSet<Individual>();
        }

        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Individual> Individual { get; set; }
    }
}
