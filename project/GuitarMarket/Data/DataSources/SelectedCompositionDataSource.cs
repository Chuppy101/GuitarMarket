using System.ComponentModel.DataAnnotations;

namespace Data.DataSources
{
    public partial class SelectedCompositionDataSource
    {
        public int GuitarId { get; set; }
        public int CompositionId { get; set; }
        
        public GuitarDataSource Guitar { get; set; }
        public CompositionDataSource Composition { get; set; }
    }
}