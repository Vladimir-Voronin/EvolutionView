using EvolutionView.Infrastructure.Interfaces;

namespace EvolutionView.Models.Characteristics
{
    class ExtroversionParametrsDefault : ICharacteristicParametrsDefault
    {
        public static bool IsActive = true;
        public static string Name = "Extroversion";
        public static readonly int min_value = 0;
        public static readonly int max_value = 100;
        public static readonly int min_genes = 5;
        public static readonly int max_genes = 20;

        public static int StartIndex { get; set; }
        public static int EndIndex { get; set; }

        private static int current_genes;

        public static int CurrentGenes
        {
            get { return current_genes; }
            set
            {
                if (value < min_genes) current_genes = min_genes;
                else if (value > max_genes) current_genes = max_genes;
                else current_genes = value;
            }
        }

        public static Extroversion ReturnNewCharacteristic()
        {
            GeneSeries g = new GeneSeries(CurrentGenes);
            return new Extroversion(g);
        }
    }
}
