using System.Collections.Generic;

namespace TFP.Domain.Entities
{
    public class City
    {
        public City()
        {
            Individual = new HashSet<Individual>();
            TfpEvent = new HashSet<TfpEvent>();
        }

        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Individual> Individual { get; set; }
        public ICollection<TfpEvent> TfpEvent { get; set; }
    }
}
