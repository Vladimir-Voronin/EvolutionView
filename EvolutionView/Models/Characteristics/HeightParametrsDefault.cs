using EvolutionView.Infrastructure.Interfaces;

namespace EvolutionView.Models.Characteristics
{
    class HeightParametrsDefault : ICharacteristicParametrsDefault
    {
        public static bool IsActive = true;
        public static string Name = "Height";
        public static readonly int min_height = 156;
        public static readonly int max_height = 210;
        public static readonly int min_genes = 8;
        public static readonly int max_genes = 24;

        public static int CurrentGenes
        {
            get { return CurrentGenes; }
            set
            {
                if (value < min_genes) CurrentGenes = min_genes;
                else if(value > max_genes) CurrentGenes = max_genes;
                else CurrentGenes = value;
            }
        }
    }
}
