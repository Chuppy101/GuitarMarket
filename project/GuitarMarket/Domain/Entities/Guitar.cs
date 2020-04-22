using System.Collections.Generic;
using Domain.Contracts;

namespace Domain.Entities
{
    public class Guitar: GuitarIdentity
    {
        public int? GuitarId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Composition> Compositions { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}